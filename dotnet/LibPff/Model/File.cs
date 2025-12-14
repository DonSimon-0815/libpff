using LibPff.Interop;

namespace LibPff.Model
{
    /// <summary>
    /// Managed wrapper for libpff file handle.
    /// </summary>
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
            // initialize file handle
            int rc = Native.FileInitialize(out nint fh, nint.Zero);
            if (rc != 1)
            {
                throw new PffException($"FileInitialize failed: {rc}", rc);
            }
            Handle = new FileHandle(fh, Native, true);

            // open read-only
            int flags = Native.GetAccessFlagsRead();
            rc = Native.FileOpen(RawHandle, path, flags, nint.Zero);
            if (rc != 1)
            {
                Handle.Dispose();
                throw new PffException($"FileOpen failed: {rc}", rc);
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
                int rc = Native.FileGetRootFolder(RawHandle, out nint root, nint.Zero);
                if (rc != 1)
                    throw new PffException($"FileGetRootFolder failed: {rc}", rc);
                return new Folder(root, Native, ownsHandle: true);
            }
        }

        public long GetSize()
        {
            int rc = Native.FileGetSize(RawHandle, out long size, nint.Zero);
            if (rc != 1) throw new PffException($"libpff_file_get_size failed: {rc}", rc);
            return size;
        }

        public bool IsCorrupted()
        {
            int rc = Native.FileIsCorrupted(RawHandle, nint.Zero);
            return rc == 1;
        }

        public void SignalAbort()
        {
            Native.FileSignalAbort(RawHandle, nint.Zero);
        }

        public int RecoverItems(byte recoveryFlags)
        {
            return Native.FileRecoverItems(RawHandle, recoveryFlags, nint.Zero);
        }

        public IItem? GetItemByIdentifier(uint itemIdentifier)
        {
            int rc = Native.FileGetItemByIdentifier(RawHandle, itemIdentifier, out nint item, nint.Zero);
            if (rc != 0 || item == nint.Zero) return null;
            return CreateItemFromHandle(item, ownsHandle: true);
        }

        public int GetNumberOfOrphanItems()
        {
            int rc = Native.FileGetNumberOfOrphanItems(RawHandle, out int number, nint.Zero);
            if (rc != 0) throw new PffException($"FileGetNumberOfOrphanItems failed: {rc}", rc);
            return number;
        }

        public IItem? GetOrphanItemByIndex(int orphanItemIndex)
        {
            int rc = Native.FileGetOrphanItemByIndex(RawHandle, orphanItemIndex, out nint item, nint.Zero);
            if (rc != 0 || item == nint.Zero) return null;
            return CreateItemFromHandle(item, ownsHandle: true);
        }

        public int GetAsciiCodepage()
        {
            int rc = Native.GetCodepage(out int codepage, nint.Zero);
            if (rc != 0) throw new PffException($"GetCodepage failed: {rc}", rc);
            return codepage;
        }

        public void SetAsciiCodepage(int codepage)
        {
            int rc = Native.SetCodepage(codepage, nint.Zero);
            if (rc != 0) throw new PffException($"SetCodepage failed: {rc}", rc);
        }

        /// <summary>
        /// Factory-Methode: erstellt das richtige Item-Objekt basierend auf dem Typ.
        /// </summary>
        private IItem CreateItemFromHandle(nint itemHandle, bool ownsHandle)
        {
            // Typ abfragen
            int rc = Native.ItemGetType(itemHandle, out byte itemType, nint.Zero);
            if (rc != 0)
                throw new PffException($"ItemGetType failed: {rc}", rc);

            return itemType switch
            {
                1 => new Folder(itemHandle, Native, ownsHandle),  // Folder
                2 => new Message(itemHandle, Native, ownsHandle), // Message
                3 => new Attachment(itemHandle, Native, ownsHandle), // Attachment
                //_ => new PffItem(itemHandle, _native, ownsHandle)      // Fallback: generic
                _ => throw new PffException($"Unknown item type: {itemType}", -1)
            };
        }
    }
}