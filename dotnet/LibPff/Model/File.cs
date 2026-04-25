using LibPff.Interop;
using LibPff.Utility;
using System.Text;

namespace LibPff.Model
{
    internal class File : IFile
    {
        private readonly FileHandle Handle;
        private readonly INativeAdapter Native;

        private nint RawHandle
        {
            get
            {
                if (Handle.IsInvalid || Handle.IsClosed)
                    throw new ObjectDisposedException(nameof(File));

                return Handle.DangerousGetHandle();
            }
        }

        public string Path { get; }

        public File(string path)
        {
            Native = NativeAdapterFactory.Create();
            Path = path ?? throw new ArgumentNullException(nameof(path));

            IntPtr error = IntPtr.Zero;

            // initialize
            int rc = Native.FileInitialize(out nint fh, out error);
            ReturnCode.Check(
                rc,
                error,
                nameof(Native.FileInitialize),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            Handle = new FileHandle(fh, Native, ownsHandle: true);

            // open read-only
            int flags = Native.GetAccessFlagsRead();
            rc = Native.FileOpen(RawHandle, path, flags, out error);

            if (rc != 1)
            {
                Handle.Dispose();
                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.FileOpen),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );
            }
        }

        public void Dispose()
        {
            Handle.Dispose();
        }

        public IFolder RootFolder
        {
            get
            {
                IntPtr error = IntPtr.Zero;
                int rc = Native.FileGetRootFolder(RawHandle, out nint root, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.FileGetRootFolder),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return new Folder(root, Native, ownsHandle: true);
            }
        }

        public long GetSize()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.FileGetSize(RawHandle, out long size, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.FileGetSize),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return size;
        }

        public bool IsCorrupted()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.FileIsCorrupted(RawHandle, out error);

            if (error != IntPtr.Zero)
            {
                Native.ErrorFree(out error);
                throw new PffException("FileIsCorrupted failed");
            }

            return rc == 1;
        }

        public void SignalAbort()
        {
            IntPtr error = IntPtr.Zero;
            Native.FileSignalAbort(RawHandle, out error);

            if (error != IntPtr.Zero)
            {
                Native.ErrorFree(out error);
                throw new PffException("FileSignalAbort failed");
            }
        }

        public int RecoverItems(byte recoveryFlags)
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.FileRecoverItems(RawHandle, recoveryFlags, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.FileRecoverItems),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return rc;
        }

        public IItem? GetItemByIdentifier(uint itemIdentifier)
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.FileGetItemByIdentifier(RawHandle, itemIdentifier, out nint item, out error);

            if (rc != 1 || item == IntPtr.Zero)
            {
                if (error != IntPtr.Zero)
                    Native.ErrorFree(out error);

                return null;
            }

            return CreateItemFromHandle(item, ownsHandle: true);
        }

        public int GetNumberOfOrphanItems()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.FileGetNumberOfOrphanItems(RawHandle, out int number, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.FileGetNumberOfOrphanItems),
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

        public IItem? GetOrphanItemByIndex(int orphanItemIndex)
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.FileGetOrphanItemByIndex(RawHandle, orphanItemIndex, out nint item, out error);

            if (rc != 1 || item == IntPtr.Zero)
            {
                if (error != IntPtr.Zero)
                    Native.ErrorFree(out error);

                return null;
            }

            return CreateItemFromHandle(item, ownsHandle: true);
        }

        public int GetAsciiCodepage()
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.GetCodepage(out int codepage, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.GetCodepage),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return codepage;
        }

        public void SetAsciiCodepage(int codepage)
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.SetCodepage(codepage, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.SetCodepage),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );
        }

        private IItem CreateItemFromHandle(nint itemHandle, bool ownsHandle)
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.ItemGetType(itemHandle, out byte itemType, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.ItemGetType),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return itemType switch
            {
                1 => new Folder(itemHandle, Native, ownsHandle),
                2 => new Message(itemHandle, Native, ownsHandle),
                3 => new Attachment(itemHandle, Native, ownsHandle),
                _ => throw new PffException($"Unknown item type: {itemType}")
            };
        }
    }
}
