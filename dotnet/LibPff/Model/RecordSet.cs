using LibPff.Interop;
using System.Text;

namespace LibPff.Model
{
    internal class RecordSet
    {
        protected readonly RecordSetHandle Handle;
        protected readonly INativeAdapter Native;

        internal nint RawHandle
        {
            get
            {
                if (Handle.IsInvalid || Handle.IsClosed)
                    throw new ObjectDisposedException(nameof(File));

                return Handle.DangerousGetHandle();
            }
        }

        public RecordSet(nint handle, INativeAdapter native, bool ownsHandle)
        {
            Handle = new RecordSetHandle(handle, native, ownsHandle);
            Native = native ?? throw new ArgumentNullException(nameof(native));
        }

        /// <summary>
        /// Returns the number of entries in the RecordSet.
        /// </summary>
        public int EntriesCount
        {
            get
            {
                int rc = Native.RecordSetGetNumberOfEntries(RawHandle, out int numberOfEntries, nint.Zero);
                if (rc != 1)
                    throw new PffException($"RecordSetGetNumberOfEntries failed: {rc}", rc);

                return numberOfEntries;
            }
        }

        public IReadOnlyList<RecordEntry> Entries
        {
            get
            {
                var list = new List<RecordEntry>();
                int count = EntriesCount;
                for (var i = 0; i < count; i++)
                {
                    list.Add(GetEntry(i));
                }
                return list;
            }
        }

        /// <summary>
        /// Returns the entry by given index.
        /// </summary>
        public RecordEntry GetEntry(int index)
        {
            int rc = Native.RecordSetGetEntryByIndex(RawHandle, index, out var entryHandle, nint.Zero);
            if (rc != 1 || entryHandle == nint.Zero)
                throw new PffException($"RecordSetGetEntryByIndex({index}) failed: {rc}", rc);

            return new RecordEntry(entryHandle, Native, ownsHandle: true);
        }

        /// <summary>
        /// Returns the entry by given type.
        /// </summary>
        public RecordEntry GetEntryByType(uint entryType, uint valueType, byte flags = 0)
        {
            int rc = Native.RecordSetGetEntryByType(RawHandle, entryType, valueType, out var entryHandle, flags, nint.Zero);
            if (rc != 1 || entryHandle == nint.Zero)
                throw new PffException($"RecordSetGetEntryByType({entryType}, {valueType}) failed: {rc}", rc);

            return new RecordEntry(entryHandle, Native, ownsHandle: true);
        }

        /// <summary>
        /// Returns the entry by given UTF8-Name.
        /// </summary>
        public RecordEntry GetEntryByUtf8Name(string name, uint valueType, byte flags = 0)
        {
            var utf8Bytes = Encoding.UTF8.GetBytes(name);
            int rc = Native.RecordSetGetEntryByUtf8Name(RawHandle, utf8Bytes, (nuint)utf8Bytes.Length,
                valueType, out var entryHandle, flags, nint.Zero);

            if (rc != 1 || entryHandle == nint.Zero)
                throw new PffException($"RecordSetGetEntryByUtf8Name({name}) failed: {rc}", rc);

            return new RecordEntry(entryHandle, Native, ownsHandle: true);
        }

        /// <summary>
        /// Returns the entry by given UTF16-Name.
        /// </summary>
        public RecordEntry GetEntryByUtf16Name(string name, uint valueType, byte flags = 0)
        {
            var utf16Bytes = Encoding.Unicode.GetBytes(name);
            var utf16Array = new ushort[utf16Bytes.Length / 2];
            Buffer.BlockCopy(utf16Bytes, 0, utf16Array, 0, utf16Bytes.Length);

            int rc = Native.RecordSetGetEntryByUtf16Name(RawHandle, utf16Array, (nuint)utf16Array.Length,
                valueType, out var entryHandle, flags, nint.Zero);

            if (rc != 1 || entryHandle == nint.Zero)
                throw new PffException($"RecordSetGetEntryByUtf16Name({name}) failed: {rc}", rc);

            return new RecordEntry(entryHandle, Native, ownsHandle: true);
        }
    }
}
