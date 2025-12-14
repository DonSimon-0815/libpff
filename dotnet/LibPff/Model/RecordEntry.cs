using LibPff.Interop;
using System.Text;

namespace LibPff.Model
{
    internal class RecordEntry
    {
        protected readonly RecordEntryHandle Handle;
        protected readonly INativeAdapter Native;

        private nint RawHandle
        {
            get
            {
                if (Handle.IsInvalid || Handle.IsClosed)
                    throw new ObjectDisposedException(nameof(File));

                return Handle.DangerousGetHandle();
            }
        }

        public RecordEntry(nint handle, INativeAdapter native, bool ownsHandle)
        {
            Handle = new RecordEntryHandle(handle, native, ownsHandle);
            Native = native ?? throw new ArgumentNullException(nameof(native));
        }

        public uint EntryType
        {
            get
            {
                int rc = Native.RecordEntryGetEntryType(RawHandle, out var entryType, nint.Zero);
                if (rc != 1) throw new PffException($"RecordEntryGetEntryType failed: {rc}", rc);
                return entryType;
            }
        }

        public uint ValueType
        {
            get
            {
                int rc = Native.RecordEntryGetValueType(RawHandle, out var valueType, nint.Zero);
                if (rc != 1) throw new PffException($"RecordEntryGetValueType failed: {rc}", rc);
                return valueType;
            }
        }

        public nuint DataSize
        {
            get
            {
                int rc = Native.RecordEntryGetDataSize(RawHandle, out var size, nint.Zero);
                if (rc != 1) throw new PffException($"RecordEntryGetDataSize failed: {rc}", rc);
                return size;
            }
        }

        public byte[] GetRawData()
        {
            var size = DataSize;
            var buffer = new byte[size];
            int rc = Native.RecordEntryGetData(RawHandle, buffer, size, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetData failed: {rc}", rc);
            return buffer;
        }

        public bool GetBoolean()
        {
            int rc = Native.RecordEntryGetDataAsBoolean(RawHandle, out var value, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAsBoolean failed: {rc}", rc);
            return value != 0;
        }

        public ushort GetInt16()
        {
            int rc = Native.RecordEntryGetDataAs16bitInteger(RawHandle, out var value, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAs16bitInteger failed: {rc}", rc);
            return value;
        }

        public uint GetInt32()
        {
            int rc = Native.RecordEntryGetDataAs32bitInteger(RawHandle, out var value, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAs32bitInteger failed: {rc}", rc);
            return value;
        }

        public ulong GetInt64()
        {
            int rc = Native.RecordEntryGetDataAs64bitInteger(RawHandle, out var value, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAs64bitInteger failed: {rc}", rc);
            return value;
        }

        public DateTime GetFileTime()
        {
            int rc = Native.RecordEntryGetDataAsFiletime(RawHandle, out var filetime, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAsFiletime failed: {rc}", rc);
            return DateTime.FromFileTimeUtc((long)filetime);
        }

        public double GetDouble()
        {
            int rc = Native.RecordEntryGetDataAsFloatingPoint(RawHandle, out var value, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAsFloatingPoint failed: {rc}", rc);
            return value;
        }

        public string GetUtf8String()
        {
            int rc = Native.RecordEntryGetDataAsUtf8StringSize(RawHandle, out var size, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAsUtf8StringSize failed: {rc}", rc);

            var buffer = new byte[size];
            rc = Native.RecordEntryGetDataAsUtf8String(RawHandle, buffer, size, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAsUtf8String failed: {rc}", rc);

            return Encoding.UTF8.GetString(buffer);
        }

        public string GetUtf16String()
        {
            int rc = Native.RecordEntryGetDataAsUtf16StringSize(RawHandle, out var size, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAsUtf16StringSize failed: {rc}", rc);

            var buffer = new ushort[size];
            rc = Native.RecordEntryGetDataAsUtf16String(RawHandle, buffer, size, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAsUtf16String failed: {rc}", rc);

            return Encoding.Unicode.GetString(
                System.Runtime.InteropServices.MemoryMarshal.AsBytes(buffer.AsSpan()));
        }

        public Guid GetGuid()
        {
            var buffer = new byte[16];
            int rc = Native.RecordEntryGetDataAsGuid(RawHandle, buffer, (nuint)buffer.Length, nint.Zero);
            if (rc != 1) throw new PffException($"RecordEntryGetDataAsGuid failed: {rc}", rc);
            return new Guid(buffer);
        }

        public long ReadBuffer(byte[] buffer)
        {
            return Native.RecordEntryReadBuffer(RawHandle, buffer, (nuint)buffer.Length, nint.Zero);
        }

        public long Seek(long offset, int whence)
        {
            return Native.RecordEntrySeekOffset(RawHandle, offset, whence, nint.Zero);
        }
    }
}
