using LibPff.Interop;
using LibPff.Utility;
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
                    throw new ObjectDisposedException(nameof(RecordEntry));

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
                IntPtr error = IntPtr.Zero;
                int rc = Native.RecordEntryGetEntryType(RawHandle, out var entryType, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.RecordEntryGetEntryType),
                    ptr =>
                    {
                        var sb = new StringBuilder(256);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return entryType;
            }
        }

        public uint ValueType
        {
            get
            {
                IntPtr error = IntPtr.Zero;
                int rc = Native.RecordEntryGetValueType(RawHandle, out var valueType, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.RecordEntryGetValueType),
                    ptr =>
                    {
                        var sb = new StringBuilder(256);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return valueType;
            }
        }

        public nuint DataSize
        {
            get
            {
                IntPtr error = IntPtr.Zero;
                int rc = Native.RecordEntryGetDataSize(RawHandle, out var size, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.RecordEntryGetDataSize),
                    ptr =>
                    {
                        var sb = new StringBuilder(256);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return size;
            }
        }

        public byte[] GetRawData()
        {
            var size = DataSize;
            var buffer = new byte[size];

            IntPtr error = IntPtr.Zero;
            int rc = Native.RecordEntryGetData(RawHandle, buffer, size, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetData),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return buffer;
        }

        public bool GetBoolean()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.RecordEntryGetDataAsBoolean(RawHandle, out var value, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAsBoolean),
                ptr =>
                {
                    var sb = new StringBuilder(128);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return value != 0;
        }

        public ushort GetInt16()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.RecordEntryGetDataAs16bitInteger(RawHandle, out var value, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAs16bitInteger),
                ptr =>
                {
                    var sb = new StringBuilder(128);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return value;
        }

        public uint GetInt32()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.RecordEntryGetDataAs32bitInteger(RawHandle, out var value, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAs32bitInteger),
                ptr =>
                {
                    var sb = new StringBuilder(128);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return value;
        }

        public ulong GetInt64()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.RecordEntryGetDataAs64bitInteger(RawHandle, out var value, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAs64bitInteger),
                ptr =>
                {
                    var sb = new StringBuilder(128);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return value;
        }

        public DateTime GetFileTime()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.RecordEntryGetDataAsFiletime(RawHandle, out var filetime, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAsFiletime),
                ptr =>
                {
                    var sb = new StringBuilder(128);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return DateTime.FromFileTimeUtc((long)filetime);
        }

        public double GetDouble()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.RecordEntryGetDataAsFloatingPoint(RawHandle, out var value, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAsFloatingPoint),
                ptr =>
                {
                    var sb = new StringBuilder(128);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return value;
        }

        public string GetUtf8String()
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.RecordEntryGetDataAsUtf8StringSize(RawHandle, out var size, out error);
            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAsUtf8StringSize),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            var buffer = new byte[size];

            rc = Native.RecordEntryGetDataAsUtf8String(RawHandle, buffer, size, out error);
            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAsUtf8String),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return Encoding.UTF8.GetString(buffer);
        }

        public string GetUtf16String()
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.RecordEntryGetDataAsUtf16StringSize(RawHandle, out var size, out error);
            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAsUtf16StringSize),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            var buffer = new ushort[size];

            rc = Native.RecordEntryGetDataAsUtf16String(RawHandle, buffer, size, out error);
            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAsUtf16String),
                ptr =>
                {
                    var sb = new StringBuilder(256);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return Encoding.Unicode.GetString(
                System.Runtime.InteropServices.MemoryMarshal.AsBytes(buffer.AsSpan()));
        }

        public Guid GetGuid()
        {
            var buffer = new byte[16];

            IntPtr error = IntPtr.Zero;
            int rc = Native.RecordEntryGetDataAsGuid(RawHandle, buffer, (nuint)buffer.Length, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.RecordEntryGetDataAsGuid),
                ptr =>
                {
                    var sb = new StringBuilder(128);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return new Guid(buffer);
        }

        public long ReadBuffer(byte[] buffer)
        {
            IntPtr error = IntPtr.Zero;

            long rc = Native.RecordEntryReadBuffer(RawHandle, buffer, (nuint)buffer.Length, out error);

            if (rc < 0)
            {
                ReturnCode.Check(
                    (int)rc,
                    error,
                    nameof(Native.RecordEntryReadBuffer),
                    ptr =>
                    {
                        var sb = new StringBuilder(256);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );
            }

            return rc;
        }

        public long Seek(long offset, int whence)
        {
            IntPtr error = IntPtr.Zero;

            long rc = Native.RecordEntrySeekOffset(RawHandle, offset, whence, out error);

            if (rc < 0)
            {
                ReturnCode.Check(
                    (int)rc,
                    error,
                    nameof(Native.RecordEntrySeekOffset),
                    ptr =>
                    {
                        var sb = new StringBuilder(256);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );
            }

            return rc;
        }
    }
}
