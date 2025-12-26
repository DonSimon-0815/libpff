using LibPff.Interop;

namespace LibPff.Model
{
    // TODO: use MAPI enums

    internal class Attachment : Item, IAttachment
    {
        private long? _sizeCache;

        public Attachment(nint handle, INativeAdapter native, bool ownsHandle)
            : base(handle, native, ownsHandle)
        {
        }

        public string FileName
        {
            get
            {
                const uint SHORT = 0x3704; // PR_ATTACH_FILENAME
                const uint LONG = 0x3707; // PR_ATTACH_LONG_FILENAME
                const uint CID = 0x3712; // PR_ATTACH_CONTENT_ID

                if (TryGetRecordValue(LONG, out string? longName) && !string.IsNullOrWhiteSpace(longName))
                    return longName;

                if (TryGetRecordValue(SHORT, out string? shortName) && !string.IsNullOrWhiteSpace(shortName))
                    return shortName;

                if (TryGetRecordValue(CID, out string? cid) && !string.IsNullOrWhiteSpace(cid))
                    return cid;

                return "attachment.bin";
            }
        }


        public string? MimeType
        {
            get
            {
                const uint MIME = 0x370E; // PR_ATTACH_MIME_TAG
                return TryGetRecordValue(MIME, out string? mime) ? mime : null;
            }
        }


        public string? ContentId
        {
            get
            {
                const uint CID = 0x3712; // PR_ATTACH_CONTENT_ID
                return TryGetRecordValue(CID, out string? cid) ? cid : null;
            }
        }

        public bool IsInline
        {
            get
            {
                // Inline attachments typically have a ContentId
                const uint CID = 0x3712;
                if (TryGetRecordValue(CID, out string? cid) && !string.IsNullOrWhiteSpace(cid))
                    return true;

                // Some clients set PR_ATTACH_FLAGS (0x3714)
                const uint FLAGS = 0x3714;
                if (TryGetRecordValue(FLAGS, out uint flags))
                {
                    // Bit 0x00000004 = ATTACHMENT_IS_INLINE
                    if ((flags & 0x00000004) != 0)
                        return true;
                }

                return false;
            }
        }

        public long Size
        {
            get
            {
                if (_sizeCache.HasValue) return _sizeCache.Value;
                int rc = Native.AttachmentGetDataSize(RawHandle, out long size, nint.Zero);
                if (rc != 1) throw new PffException($"AttachmentGetDataSize failed: {rc}", rc);
                _sizeCache = size;
                return size;
            }
        }

        public byte[]? Data => ReadAllDataAsync().GetAwaiter().GetResult();

        public Stream? OpenDataStream()
        {
            long total = Size;
            if (total == 0) return Stream.Null;

            const int chunk = 64 * 1024;
            var ms = new MemoryStream((int)Math.Min(total, int.MaxValue));
            var buf = new byte[Math.Min(chunk, (int)total)];
            long read = 0;

            while (read < total)
            {
                int toRead = (int)Math.Min(buf.Length, total - read);
                long rc = Native.AttachmentDataReadBuffer(RawHandle, buf, (nuint)toRead, nint.Zero);
                if (rc < 0) break;
                int got = (int)rc;
                if (got == 0) break;
                ms.Write(buf, 0, got);
                read += got;
            }

            ms.Position = 0;
            return ms;
        }

        public async Task<byte[]?> ReadAllDataAsync()
        {
            using var s = OpenDataStream();
            if (s == null) return null;
            if (s == Stream.Null) return Array.Empty<byte>();
            using var ms = new MemoryStream();
            await s.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}