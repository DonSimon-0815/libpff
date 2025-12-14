namespace LibPff
{
    /// <summary>
    /// Represents a folder within the PST (can contain messages and subfolders).
    /// </summary>
    public interface IFolder : IItem
    {
        /// <summary>
        /// Name of the folder.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Number of direct subfolders.
        /// </summary>
        int SubFolderCount { get; }

        /// <summary>
        /// Enumerate direct subfolders.
        /// </summary>
        IReadOnlyList<IFolder> SubFolders { get; }

        /// <summary>
        /// Number of messages in this folder.
        /// </summary>
        int MessageCount { get; }

        /// <summary>
        /// Enumerate messages in this folder.
        /// </summary>
        IReadOnlyList<IMessage> Messages { get; }

        /// <summary>
        /// Try to get a subfolder by utf8 name. Returns null if not found.
        /// </summary>
        IFolder? GetSubFolderByUtf8Name(string utf8Name);

        /// <summary>
        /// Try to get a sub-message by utf8 name. Returns null if not found.
        /// </summary>
        IMessage? GetSubMessageByUtf8Name(string utf8Name);
    }
}