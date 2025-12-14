using LibPff.Interop;

namespace LibPff.Model
{
    internal class Attachment : Item, IAttachment
    {
        private long? _sizeCache;
        public Attachment(nint handle, INativeAdapter native, bool ownsHandle) : base(handle, native, ownsHandle)
        {
        }

        public string FileName
        {
            get
            {
                // TODO: get entry EntryType.AttachmentFilenameLong from record
                //EntryType.AttachmentFilenameShort
                //EntryType.AttachmentFilenameLong

                //var record = GetRecordByIdentifier(ATTACH_FILENAME);
                //Console.WriteLine($"### file-name identifier: {record.Identifier}, filename: {record.ValueUtf8}");
                //return record.ValueUtf8!;

                // Attachment name might be an entry; without mapping we'll return empty string.
                return string.Empty;
            }
        }

        public string? MimeType => null;

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

        public byte[]? Data
        {
            get
            {
                return ReadAllDataAsync().GetAwaiter().GetResult();
            }
        }

        public Stream? OpenDataStream()
        {
            // Implement chunked read into MemoryStream (simple variant).
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

        public bool IsInline => false;
        public string? ContentId => null;
    }
}