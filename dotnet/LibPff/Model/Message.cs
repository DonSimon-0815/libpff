using HtmlAgilityPack;
using LibPff.Interop;
using LibPff.Utility;
using System.Text;
using System.Text.RegularExpressions;

namespace LibPff.Model
{
    internal class Message : Item, IMessage
    {
        public Message(nint handle, INativeAdapter native, bool ownsHandle)
            : base(handle, native, ownsHandle)
        {
        }

        public string Subject
        {
            get
            {
                return TryGetEntryValueUtf8((uint)EntryType.MessageSubject, out var subject)
                    && !string.IsNullOrWhiteSpace(subject)
                    ? subject
                    : "<no subject>";
            }
        }

        public string? BodyPlainText
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.MessageGetPlainTextBodySize(RawHandle, out nuint size, out error);
                if (rc == 1 && size > 0)
                {
                    var buf = new byte[(int)size];
                    rc = Native.MessageGetPlainTextBody(RawHandle, buf, size, out error);

                    if (rc == 1)
                    {
                        int valid = buf.Length;
                        if (valid > 0 && buf[valid - 1] == 0)
                            valid--;

                        return DecodeBestEffort(buf[..valid]);
                    }

                    if (error != IntPtr.Zero)
                        Native.ErrorFree(out error);
                }

                const uint PR_BODY = 0x1000;
                if (TryGetRecordValue(PR_BODY, out string? bodyProp) && !string.IsNullOrWhiteSpace(bodyProp))
                    return bodyProp;

                return null;
            }
        }

        public string? BodyHtml
        {
            get
            {
                if (BodyRtf is { } rtf)
                {
                    var html = RtfToHtml(rtf);
                    if (!string.IsNullOrWhiteSpace(html))
                        return WrapHtmlUtf8(html);
                }

                IntPtr error = IntPtr.Zero;
                int rc = Native.MessageGetHtmlBodySize(RawHandle, out nuint size, out error);

                if (rc == 1 && size > 0)
                {
                    var buf = new byte[(int)size];
                    rc = Native.MessageGetHtmlBody(RawHandle, buf, size, out error);

                    if (rc == 1)
                    {
                        int valid = buf.Length;
                        if (valid > 0 && buf[valid - 1] == 0)
                            valid--;

                        var html = DecodeBestEffort(buf[..valid]);
                        if (!string.IsNullOrWhiteSpace(html))
                            return WrapHtmlUtf8(html);
                    }

                    if (error != IntPtr.Zero)
                        Native.ErrorFree(out error);
                }

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
                IntPtr error = IntPtr.Zero;

                int rc = Native.MessageGetRtfBodySize(RawHandle, out nuint size, out error);
                if (rc != 1 || size == 0)
                {
                    if (error != IntPtr.Zero)
                        Native.ErrorFree(out error);
                    return null;
                }

                var buf = new byte[(int)size];
                rc = Native.MessageGetRtfBody(RawHandle, buf, size, out error);

                if (rc != 1)
                {
                    if (error != IntPtr.Zero)
                        Native.ErrorFree(out error);
                    return null;
                }

                return Encoding.ASCII.GetString(buf);
            }
        }

        public string? BodyText
        {
            get
            {
                if (BodyRtf is { } rtf)
                {
                    var html = RtfToHtml(rtf);
                    var text = HtmlToText(html);
                    if (!string.IsNullOrWhiteSpace(text))
                        return text;
                }

                if (BodyHtml is { } html2)
                {
                    var text = HtmlToText(html2);
                    if (!string.IsNullOrWhiteSpace(text))
                        return text;
                }

                if (BodyPlainText is { } plain && !string.IsNullOrWhiteSpace(plain))
                    return plain;

                return null;
            }
        }
        
        public string? MimeBody
        {
            get
            {
                // 1) Original MIME-Body from PR_INTERNET_MESSAGE_BODY (if available)
                const uint PR_INTERNET_MESSAGE_BODY = 0x1009;

                if (TryGetRecordValue(PR_INTERNET_MESSAGE_BODY, out string? rawMime) &&
                    !string.IsNullOrWhiteSpace(rawMime))
                {
                    // Assumption: Property only contains body but no transport header
                    return rawMime;
                }

                // 2) multipart? MIME body is located in attachment 0
                if (TransportHeaders?.Contains("multipart/", StringComparison.OrdinalIgnoreCase) == true)
                {
                    var att = GetAttachment(0);
                    if (att != null)
                    {
                        using var s = att.OpenDataStream();
                        if (s != null)
                        {
                            using var r = new StreamReader(s, Encoding.ASCII, detectEncodingFromByteOrderMarks: true);
                            var mime = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(mime))
                                return mime;
                        }
                    }

                    // Fallback: multipart sythesis with boundaries from headers
                    var boundary = ExtractBoundaryFromHeaders(TransportHeaders);
                    var plain = BodyPlainText;
                    var html = BodyHtml;

                    if (!string.IsNullOrWhiteSpace(boundary) &&
                        (!string.IsNullOrWhiteSpace(plain) || !string.IsNullOrWhiteSpace(html)))
                    {
                        var sb = new StringBuilder();

                        // IMPORTANT: No top-level content type, because it's part of the transport header
                        if (!string.IsNullOrWhiteSpace(plain))
                        {
                            sb.Append("--").Append(boundary).Append("\r\n");
                            sb.Append("Content-Type: text/plain; charset=utf-8\r\n\r\n");
                            sb.Append(plain).Append("\r\n\r\n");
                        }

                        if (!string.IsNullOrWhiteSpace(html))
                        {
                            sb.Append("--").Append(boundary).Append("\r\n");
                            sb.Append("Content-Type: text/html; charset=utf-8\r\n\r\n");
                            sb.Append(html).Append("\r\n\r\n");
                        }

                        sb.Append("--").Append(boundary).Append("--\r\n");
                        return sb.ToString();
                    }
                }

                // 3) No mime structure, synthetic boy without top-level content type
                var plainFallback = BodyPlainText;
                var htmlFallback = BodyHtml;

                if (!string.IsNullOrWhiteSpace(plainFallback) && !string.IsNullOrWhiteSpace(htmlFallback))
                {
                    var boundary = "----=_Part_" + Guid.NewGuid().ToString("N");
                    var sb = new StringBuilder();

                    // Hier gibt es keinen bestehenden Content-Type in den TransportHeaders,
                    // d.h. der EML-Builder sollte in diesem Fall selbst einen passenden Header setzen.
                    // Wenn du strikt bei "Headers + Body" bleiben willst, kannst du hier
                    // optional einen Default-Header außerhalb dieser Property erzeugen.

                    sb.Append("--").Append(boundary).Append("\r\n");
                    sb.Append("Content-Type: text/plain; charset=utf-8\r\n\r\n");
                    sb.Append(plainFallback).Append("\r\n\r\n");

                    sb.Append("--").Append(boundary).Append("\r\n");
                    sb.Append("Content-Type: text/html; charset=utf-8\r\n\r\n");
                    sb.Append(htmlFallback).Append("\r\n\r\n");

                    sb.Append("--").Append(boundary).Append("--\r\n");

                    return sb.ToString();
                }

                if (!string.IsNullOrWhiteSpace(htmlFallback))
                    return htmlFallback;

                if (!string.IsNullOrWhiteSpace(plainFallback))
                    return plainFallback;

                return null;
            }
        }

        private static string? ExtractBoundaryFromHeaders(string headers)
        {
            // Very simple boundary extraction from content type row
            // for example boundary="----=_NextPart_000_0147_01D89324.DF97C180"
            var match = Regex.Match(headers, @"boundary\s*=\s*(""(?<b>[^""]+)""|(?<b>[^\r\n;]+))",
                RegexOptions.IgnoreCase);
            if (match.Success)
                return match.Groups["b"].Value.Trim();

            return null;
        }

        public async Task<string?> GetBodyPlainTextAsync()
        {
            return await Task.FromResult(BodyPlainText);
        }

        public Stream? OpenPlainTextBodyStream()
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.MessageGetPlainTextBodySize(RawHandle, out nuint size, out error);
            if (rc != 1)
            {
                if (error != IntPtr.Zero)
                    Native.ErrorFree(out error);
                return null;
            }

            int total = (int)size;
            if (total == 0)
                return Stream.Null;

            var buf = new byte[total];
            rc = Native.MessageGetPlainTextBody(RawHandle, buf, size, out error);

            if (rc != 1)
            {
                if (error != IntPtr.Zero)
                    Native.ErrorFree(out error);
                return null;
            }

            int valid = buf.Length;
            if (buf[^1] == 0)
                valid--;

            return new MemoryStream(buf, 0, valid, writable: false);
        }

        public DateTimeOffset? SentTime
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.MessageGetClientSubmitTime(RawHandle, out ulong filetime, out error);
                if (rc != 1)
                {
                    if (error != IntPtr.Zero)
                        Native.ErrorFree(out error);
                    return null;
                }

                try { return DateTimeOffset.FromFileTime((long)filetime); }
                catch { return null; }
            }
        }

        public DateTimeOffset? ReceivedTime
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.MessageGetDeliveryTime(RawHandle, out ulong filetime, out error);
                if (rc != 1)
                {
                    if (error != IntPtr.Zero)
                        Native.ErrorFree(out error);
                    return null;
                }

                try { return DateTimeOffset.FromFileTime((long)filetime); }
                catch { return null; }
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
                var raw = headers + "\r\n\r\n";
                using var ms = new MemoryStream(Encoding.ASCII.GetBytes(raw));
                var msg = MimeKit.MimeMessage.Load(ms);

                IEnumerable<MimeKit.InternetAddress> addrs = field switch
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
                IntPtr error = IntPtr.Zero;

                int rc = Native.MessageGetNumberOfAttachments(RawHandle, out int number, out error);
                if (rc != 1 && number == 0)
                    return 0;

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.MessageGetNumberOfAttachments),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

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
                    var att = GetAttachment(i);
                    if (att != null)
                        list.Add(att);
                }

                return list;
            }
        }

        public IAttachment? GetAttachment(int index)
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.MessageGetAttachment(RawHandle, index, out nint attachment, out error);
            if (rc == -1)
                return null;

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.MessageGetAttachment),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return new Attachment(attachment, Native, ownsHandle: true);
        }

        public bool TryGetEntryValueUtf8(uint entryType, out string? value)
        {
            value = null;

            IntPtr error = IntPtr.Zero;

            int rc = Native.MessageGetEntryValueUtf8StringSize(RawHandle, entryType, out nuint size, out error);
            if (rc != 1 || size == 0)
            {
                if (error != IntPtr.Zero)
                    Native.ErrorFree(out error);
                return false;
            }

            var buf = new byte[(int)size];

            rc = Native.MessageGetEntryValueUtf8String(RawHandle, entryType, buf, size, out error);
            if (rc != 1)
            {
                if (error != IntPtr.Zero)
                    Native.ErrorFree(out error);
                return false;
            }

            int valid = buf.Length;
            if (buf[^1] == 0)
                valid--;

            value = DecodeBestEffort(buf[..valid]);
            return true;
        }

        public bool TryGetEntryValueInt32(uint entryType, out int? value)
        {
            value = null;

            if (TryGetRecordValue(entryType, out int v))
            {
                value = v;
                return true;
            }

            return false;
        }

        public bool TryGetEntryValueFiletime(uint entryType, out DateTimeOffset? value)
        {
            value = null;

            if (TryGetRecordValue(entryType, out DateTime dt))
            {
                value = new DateTimeOffset(dt, TimeSpan.Zero);
                return true;
            }

            return false;
        }

        private string? RtfToHtml(string? rtf)
        {
            if (string.IsNullOrWhiteSpace(rtf))
                return null;

            try { return RtfPipe.Rtf.ToHtml(rtf); }
            catch { return null; }
        }

        private string? HtmlToText(string? html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return null;

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var text = doc.DocumentNode.InnerText;
            return string.IsNullOrWhiteSpace(text) ? null : text.Trim();
        }

        private static string DecodeBestEffort(byte[] data)
        {
            // 1. UTF-8 BOM
            if (data.Length >= 3 &&
                data[0] == 0xEF && data[1] == 0xBB && data[2] == 0xBF)
                return Encoding.UTF8.GetString(data, 3, data.Length - 3);

            // 2. UTF-16 LE BOM
            if (data.Length >= 2 &&
                data[0] == 0xFF && data[1] == 0xFE)
                return Encoding.Unicode.GetString(data, 2, data.Length - 2);

            // 3. UTF-16 BE BOM
            if (data.Length >= 2 &&
                data[0] == 0xFE && data[1] == 0xFF)
                return Encoding.BigEndianUnicode.GetString(data, 2, data.Length - 2);

            // 4. UTF-8 Heuristic
            try
            {
                var utf8 = Encoding.UTF8.GetString(data);
                if (Encoding.UTF8.GetBytes(utf8).SequenceEqual(data))
                    return utf8;
            }
            catch { }

            // 5. Windows-1252
            try { return Encoding.GetEncoding(1252).GetString(data); }
            catch { }

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
