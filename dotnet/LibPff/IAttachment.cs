namespace LibPff
{
    /// <summary>
    /// Abstraction for an attachment. Implementations should avoid loading full payloads
    /// unless requested (support streaming).
    /// </summary>
    public interface IAttachment : IItem
    {
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the MIME type of the attachment, if known.
        /// </summary>
        string? MimeType { get; }

        /// <summary>
        /// Gets the size of the attachment in bytes.
        /// </summary>
        long Size { get; }

        /// <summary>
        /// Return the data as a byte array. Implementations may fetch it lazily.
        /// Can be expensive for large attachments.
        /// </summary>
        byte[]? Data { get; }

        /// <summary>
        /// Open a read-only stream for the attachment data. Caller must dispose.
        /// Return null if streaming is unsupported.
        /// </summary>
        Stream? OpenDataStream();

        /// <summary>
        /// Asynchronously read all data into memory.
        /// </summary>
        Task<byte[]?> ReadAllDataAsync();

        /// <summary>
        /// Gets a value indicating whether the content is inline, such as an embedded image or body part.
        /// </summary>
        bool IsInline { get; }

        /// <summary>
        /// Gets the content identifier for HTML references, if available.
        /// </summary>
        string? ContentId { get; }
    }
}