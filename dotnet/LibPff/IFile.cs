namespace LibPff
{
    /// <summary>
    /// High-level abstraction of a PST file.
    /// Implementations should wrap the native backend and provide safe, managed access.
    /// </summary>
    public interface IFile : IDisposable
    {
        /// <summary>
        /// The path used to open the file (if known).
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Root folder of the PST (message store root).
        /// </summary>
        IFolder RootFolder { get; }

        /// <summary>
        /// Returns the total size of the file in bytes, if available.
        /// </summary>
        long GetSize();

        /// <summary>
        /// Returns whether the file appears to be corrupted according to the backend.
        /// </summary>
        bool IsCorrupted();

        /// <summary>
        /// Signal the backend to abort long-running operations (optional).
        /// </summary>
        void SignalAbort();

        /// <summary>
        /// Recover items (if backend supports it). Returns number of recovered items or -1 on unsupported.
        /// </summary>
        int RecoverItems(byte recoveryFlags);

        /// <summary>
        /// Get an item by its identifier, or null if not found.
        /// </summary>
        IItem? GetItemByIdentifier(uint itemIdentifier);

        /// <summary>
        /// Number of orphan items in the file, if supported.
        /// </summary>
        int GetNumberOfOrphanItems();

        /// <summary>
        /// Get an orphan item by index.
        /// </summary>
        IItem? GetOrphanItemByIndex(int orphanItemIndex);

        /// <summary>
        /// Get the codepage currently in use by the backend (if supported).
        /// </summary>
        int GetAsciiCodepage();

        /// <summary>
        /// Set the ascii codepage used by the backend (if supported).
        /// </summary>
        void SetAsciiCodepage(int codepage);
    }
}