using LibPff.Interop;
using LibPff.Utility;
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
                    throw new ObjectDisposedException(nameof(RecordSet));

                return Handle.DangerousGetHandle();
            }
        }

        public RecordSet(nint handle, INativeAdapter native, bool ownsHandle)
        {
            Handle = new RecordSetHandle(handle, native, ownsHandle);
            Native = native ?? throw new ArgumentNullException(nameof(native));
        }

        public int EntriesCount
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.RecordSetGetNumberOfEntries(RawHandle, out int numberOfEntries, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.RecordSetGetNumberOfEntries),
                    ptr =>
                    {
                        var sb = new StringBuilder(256);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return numberOfEntries;
            }
        }

        public IReadOnlyList<RecordEntry> Entries
        {
            get
            {
                var list = new List<RecordEntry>();
                int count = EntriesCount;

                for (int i = 0; i < count; i++)
                    list.Add(GetEntry(i));

                return list;
            }
        }

        public RecordEntry GetEntry(int index)
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.RecordSetGetEntryByIndex(RawHandle, index, out var entryHandle, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordSetGetEntryByIndex),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return new RecordEntry(entryHandle, Native, ownsHandle: true);
        }

        public RecordEntry GetEntryByType(uint entryType, uint valueType, byte flags = 0)
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.RecordSetGetEntryByType(
                RawHandle,
                entryType,
                valueType,
                out var entryHandle,
                flags,
                out error
            );

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordSetGetEntryByType),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return new RecordEntry(entryHandle, Native, ownsHandle: true);
        }

        public RecordEntry GetEntryByUtf8Name(string name, uint valueType, byte flags = 0)
        {
            var utf8Bytes = Encoding.UTF8.GetBytes(name ?? string.Empty);
            IntPtr error = IntPtr.Zero;

            int rc = Native.RecordSetGetEntryByUtf8Name(
                RawHandle,
                utf8Bytes,
                (nuint)utf8Bytes.Length,
                valueType,
                out var entryHandle,
                flags,
                out error
            );

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordSetGetEntryByUtf8Name),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return new RecordEntry(entryHandle, Native, ownsHandle: true);
        }

        public RecordEntry GetEntryByUtf16Name(string name, uint valueType, byte flags = 0)
        {
            var utf16Bytes = Encoding.Unicode.GetBytes(name ?? string.Empty);
            var utf16Array = new ushort[utf16Bytes.Length / 2];
            Buffer.BlockCopy(utf16Bytes, 0, utf16Array, 0, utf16Bytes.Length);

            IntPtr error = IntPtr.Zero;

            int rc = Native.RecordSetGetEntryByUtf16Name(
                RawHandle,
                utf16Array,
                (nuint)utf16Array.Length,
                valueType,
                out var entryHandle,
                flags,
                out error
            );

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordSetGetEntryByUtf16Name),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return new RecordEntry(entryHandle, Native, ownsHandle: true);
        }
    }
}
