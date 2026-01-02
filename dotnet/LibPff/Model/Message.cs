using HtmlAgilityPack;
using LibPff.Interop;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LibPff.Model
{
    internal class Message : Item, IMessage
    {
        public Message(nint handle, INativeAdapter native, bool ownsHandle) : base(handle, native, ownsHandle)
        {
        }

        public string Subject
        {
            get
            {
                var result = TryGetEntryValueUtf8(EntryType.MessageSubject, out var subject);
                return result && subject != null ? subject : "<no subject>";
            }
        }
        public string? BodyPlainText
        {
            get
            {
                try
                {
                    return GetBodyPlainTextAsync().GetAwaiter().GetResult();
                }
                catch
                {
                    return null;
                }
            }
        }

        public string? BodyHtml
        {
            get
            {
                // 1) RTF → HTML (beste Qualität)
                if (BodyRtf is { } rtf)
                {
                    var htmlFromRtf = RtfToHtml(rtf);
                    if (!string.IsNullOrWhiteSpace(htmlFromRtf))
                        return WrapHtmlUtf8(htmlFromRtf);
                }

                // 2) HTML aus PST (Fallback)
                int rc = Native.MessageGetHtmlBodySize(RawHandle, out nuint size, nint.Zero);
                if (rc == 1 && size > 0)
                {
                    int len = checked((int)size);
                    var buf = new byte[len];

                    rc = Native.MessageGetHtmlBody(RawHandle, buf, (nuint)buf.Length, nint.Zero);
                    if (rc == 1)
                    {
                        int valid = buf.Length;
                        if (valid > 0 && buf[valid - 1] == 0)
                            valid--;

                        var html = DecodeBestEffort(buf[..valid]);
                        if (!string.IsNullOrWhiteSpace(html))
                            return WrapHtmlUtf8(html);
                    }
                }

                // 3) Plaintext → HTML (Notlösung)
                if (BodyPlainText is { } plain && !string.IsNullOrWhiteSpace(plain))
                {
                    var html = "<pre>" + System.Net.WebUtility.HtmlEncode(plain) + "</pre>";
                    return WrapHtmlUtf8(html);
                }

                return null;
            }
        }

        public string? BodyRtf
        {
            get
            {
                int rc = Native.MessageGetRtfBodySize(RawHandle, out nuint size, nint.Zero);
                if (rc != 1 || size == 0)
                    return null;

                var buf = new byte[(int)size];
                rc = Native.MessageGetRtfBody(RawHandle, buf, size, nint.Zero);
                if (rc != 1)
                    return null;

                return Encoding.ASCII.GetString(buf);
            }
        }

        public string? BodyText
        {
            get
            {
                // 1) RTF → HTML → Text (beste Qualität)
                if (BodyRtf is { } rtf)
                {
                    var htmlFromRtf = RtfToHtml(rtf);
                    var textFromRtf = HtmlToText(htmlFromRtf);
                    if (!string.IsNullOrWhiteSpace(textFromRtf))
                        return textFromRtf;
                }

                // 2) HTML aus PST → Text
                if (BodyHtml is { } html)
                {
                    var text = HtmlToText(html);
                    if (!string.IsNullOrWhiteSpace(text))
                        return text;
                }

                // 3) Plaintext aus PST
                if (BodyPlainText is { } plain && !string.IsNullOrWhiteSpace(plain))
                    return plain;

                // 4) Optional: MIME-Fallbacks über Attachments

                return null;
            }
        }

        public async Task<string?> GetBodyPlainTextAsync()
        {
            // 1) Versuche libpff-Plaintext-Body
            int rc = Native.MessageGetPlainTextBodySize(RawHandle, out nuint size, nint.Zero);
            if (rc == 1 && size > 0)
            {
                int len = checked((int)size);
                var buf = new byte[len];

                rc = Native.MessageGetPlainTextBody(RawHandle, buf, (nuint)buf.Length, nint.Zero);
                if (rc == 1)
                {
                    int valid = buf.Length;
                    if (valid > 0 && buf[valid - 1] == 0)
                        valid--;

                    var text = DecodeBestEffort(buf[..valid]);
                    return await Task.FromResult(text);
                }
            }

            // 2) Fallback: PR_BODY (0x1000) als Unicode/String
            const uint PR_BODY = 0x1000;
            if (TryGetRecordValue(PR_BODY, out string? bodyProp) && !string.IsNullOrWhiteSpace(bodyProp))
                return bodyProp;

            return null;
        }


        public Stream? OpenPlainTextBodyStream()
        {
            int rc = Native.MessageGetPlainTextBodySize(RawHandle, out nuint size, nint.Zero);
            if (rc != 1) return null;
            int total = (int)size;
            if (total == 0) return Stream.Null;

            // Create a MemoryStream by reading the body in one go (simpler).
            // For large bodies you can implement chunked streaming using libpff_message_get_plain_text_body with offsets.
            var buf = new byte[total];
            rc = Native.MessageGetPlainTextBody(RawHandle, buf, (nuint)buf.Length, nint.Zero);
            if (rc != 1) return null;
            int valid = buf.Length;
            if (buf[buf.Length - 1] == 0) valid = buf.Length - 1;
            return new MemoryStream(buf, 0, valid, writable: false);
        }

        public DateTimeOffset? SentTime
        {
            get
            {
                int rc = Native.MessageGetClientSubmitTime(RawHandle, out ulong filetime, nint.Zero);
                if (rc != 1) return null;
                // FILETIME to DateTimeOffset conversion (Windows FILETIME is 100-nanosecond since 1601)
                try
                {
                    long ft = (long)filetime;
                    var dt = DateTimeOffset.FromFileTime(ft);
                    return dt;
                }
                catch
                {
                    return null;
                }
            }
        }

        public DateTimeOffset? ReceivedTime
        {
            get
            {
                int rc = Native.MessageGetDeliveryTime(RawHandle, out ulong filetime, nint.Zero);
                if (rc != 1) return null;
                try
                {
                    long ft = (long)filetime;
                    var dt = DateTimeOffset.FromFileTime(ft);
                    return dt;
                }
                catch
                {
                    return null;
                }
            }
        }

        public string? Sender
        {
            get
            {
                // PR_SENDER_EMAIL_ADDRESS
                const uint SENDER_EMAIL = 0x0C1F;
                if (TryGetRecordValue(SENDER_EMAIL, out string? email) && !string.IsNullOrWhiteSpace(email))
                    return email;

                // PR_SENDER_NAME
                const uint SENDER_NAME = 0x0C1A;
                if (TryGetRecordValue(SENDER_NAME, out string? name) && !string.IsNullOrWhiteSpace(name))
                    return name;

                return null;
            }
        }

        public string? TransportHeaders
        {
            get
            {
                const uint HEADERS = 0x007D; // PR_TRANSPORT_MESSAGE_HEADERS
                return TryGetRecordValue(HEADERS, out string? headers) ? headers : null;
            }
        }

        public IReadOnlyList<string> RecipientsTo => GetRecipients("to");
        public IReadOnlyList<string> RecipientsCc => GetRecipients("cc");
        public IReadOnlyList<string> RecipientsBcc => GetRecipients("bcc");

        private IReadOnlyList<string> GetRecipients(string field)
        {
            var headers = TransportHeaders;
            if (string.IsNullOrWhiteSpace(headers))
                return Array.Empty<string>();

            try
            {
                // künstliche Minimal-Mail: Header + Leerzeile
                var raw = headers + "\r\n\r\n";
                using var ms = new MemoryStream(Encoding.ASCII.GetBytes(raw));
                var msg = MimeKit.MimeMessage.Load(ms);

                IEnumerable<MimeKit.InternetAddress> addrs = field.ToLowerInvariant() switch
                {
                    "to" => msg.To,
                    "cc" => msg.Cc,
                    "bcc" => msg.Bcc,
                    _ => Array.Empty<MimeKit.InternetAddress>()
                };

                return addrs
                    .OfType<MimeKit.MailboxAddress>()
                    .Select(a => a.Address)
                    .Where(a => !string.IsNullOrWhiteSpace(a))
                    .ToArray();
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        public int AttachmentCount
        {
            get
            {
                int rc = Native.MessageGetNumberOfAttachments(RawHandle, out int number, nint.Zero);
                if (rc != 1 && number != 0) throw new PffException($"MessageGetNumberOfAttachments failed: {rc}", rc);
                return number;
            }
        }

        public IReadOnlyList<IAttachment> Attachments
        {
            get
            {
                var list = new List<IAttachment>();
                int count = AttachmentCount;
                for (int i = 0; i < count; i++)
                {
                    list.Add(GetAttachment(i)!);
                }
                return list;
            }
        }

        public IAttachment? GetAttachment(int index)
        {
            int rc = Native.MessageGetAttachment(RawHandle, index, out nint attachment, nint.Zero);
            //if (rc != 1 || attachment == nint.Zero) return null;
            if (rc != 1 || attachment == nint.Zero) throw new PffException($"MessageGetAttachment({index}) failed: {rc}", rc); ;
            return new Attachment(attachment, Native, ownsHandle: true);
        }

        public bool TryGetEntryValueUtf8(EntryType entryType, out string? value)
        {
            return TryGetEntryValueUtf8((uint)entryType, out value);
        }

        public bool TryGetEntryValueUtf8(uint entryType, out string? value)
        {
            value = null;
            int rc = Native.MessageGetEntryValueUtf8StringSize(RawHandle, entryType, out nuint size, nint.Zero);
            if (rc != 1 || (int)size == 0) return false;
            var buf = new byte[(int)size];
            rc = Native.MessageGetEntryValueUtf8String(RawHandle, entryType, buf, (nuint)buf.Length, nint.Zero);
            if (rc != 1) return false;
            int valid = buf.Length;
            if (buf[buf.Length - 1] == 0) valid = buf.Length - 1;
            //value = Encoding.UTF8.GetString(buf, 0, valid);
            value = DecodeBestEffort(buf[..valid]);
            return true;
        }

        public bool TryGetEntryValueInt32(uint entryType, out int? value)
        {
            value = null;
            // Without exact api for int entries at message level, try to use libpff_item_get_entry_value_32bit? May need adjustments.
            return false;
        }

        public bool TryGetEntryValueFiletime(uint entryType, out DateTimeOffset? value)
        {
            value = null;
            // not implemented generically here
            return false;
        }

        private string? ExtractTextFromMimeAttachment(byte[] data)
        {
            try
            {
                var msg = MimeKit.MimeMessage.Load(new MemoryStream(data));

                string? Extract(MimeKit.MimeEntity part)
                {
                    switch (part)
                    {
                        case MimeKit.TextPart text:
                            return text.Text;

                        case MimeKit.Multipart multipart:
                            foreach (var sub in multipart)
                            {
                                var result = Extract(sub);
                                if (result != null)
                                    return result;
                            }
                            break;
                    }
                    return null;
                }

                return Extract(msg.Body);
            }
            catch
            {
                return null;
            }
        }

        private string? RtfToHtml(string? rtf)
        {
            if (string.IsNullOrWhiteSpace(rtf))
                return null;

            try
            {
                return RtfPipe.Rtf.ToHtml(rtf);
            }
            catch
            {
                return null;
            }
        }

        private string? HtmlToText(string? html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return null;

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var text = doc.DocumentNode.InnerText;
            return string.IsNullOrWhiteSpace(text) ? null : text.Trim();
        }

        private static string DecodeBestEffort(byte[] data)
        {
            // 1. UTF-8 BOM
            if (data.Length >= 3 &&
                data[0] == 0xEF && data[1] == 0xBB && data[2] == 0xBF)
            {
                return Encoding.UTF8.GetString(data, 3, data.Length - 3);
            }

            // 2. UTF-16 LE BOM
            if (data.Length >= 2 &&
                data[0] == 0xFF && data[1] == 0xFE)
            {
                return Encoding.Unicode.GetString(data, 2, data.Length - 2);
            }

            // 3. UTF-16 BE BOM
            if (data.Length >= 2 &&
                data[0] == 0xFE && data[1] == 0xFF)
            {
                return Encoding.BigEndianUnicode.GetString(data, 2, data.Length - 2);
            }

            // 4. UTF-8 Heuristik
            try
            {
                var utf8 = Encoding.UTF8.GetString(data);
                var roundtrip = Encoding.UTF8.GetBytes(utf8);

                if (roundtrip.SequenceEqual(data))
                    return utf8;
            }
            catch { }

            // 5. Windows-1252 (häufigster PST-Fall)
            try
            {
                return Encoding.GetEncoding(1252).GetString(data);
            }
            catch { }

            // 6. ISO-8859-1 fallback
            return Encoding.Latin1.GetString(data);
        }

        private static string WrapHtmlUtf8(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return html;

            return
                "<!DOCTYPE html><html><head>" +
                "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />" +
                "</head><body>" +
                html +
                "</body></html>";
        }
    }
}