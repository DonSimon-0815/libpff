using LibPff.Interop;
using System.Text;

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

        public string? BodyHtml => null;

        public async Task<string?> GetBodyPlainTextAsync()
        {
            // check size first
            int rc = Native.MessageGetPlainTextBodySize(RawHandle, out nuint size, nint.Zero);
            if (rc != 1) return null;
            int len = (int)size;
            if (len <= 0) return string.Empty;
            var buf = new byte[len];
            rc = Native.MessageGetPlainTextBody(RawHandle, buf, (nuint)buf.Length, nint.Zero);
            if (rc != 1) return null;
            int valid = buf.Length;
            if (buf[buf.Length - 1] == 0) valid = buf.Length - 1;
            return await Task.FromResult(Encoding.UTF8.GetString(buf, 0, valid));
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

        public string? Sender => null;

        public IReadOnlyList<string> RecipientsTo => Array.Empty<string>();
        public IReadOnlyList<string> RecipientsCc => Array.Empty<string>();
        public IReadOnlyList<string> RecipientsBcc => Array.Empty<string>();

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
            value = Encoding.UTF8.GetString(buf, 0, valid);
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
    }
}