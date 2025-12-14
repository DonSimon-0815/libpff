namespace LibPff
{
    /// <summary>
    /// High-level abstraction for a message in a PST file.
    /// Implementations should hide native pointer handling and provide managed access.
    /// </summary>
    public interface IMessage : IItem
    {
        /// <summary>
        /// Gets the subject of the message.
        /// </summary>
        string Subject { get; }

        /// <summary>
        /// Gets the plain text body of the message, if available.
        /// </summary>
        string? BodyPlainText { get; }

        /// <summary>
        /// Gets the HTML body of the message, if available.
        /// </summary>
        string? BodyHtml { get; }

        /// <summary>
        /// Asynchronously retrieve the plain text body. Implementations may load lazily.
        /// </summary>
        Task<string?> GetBodyPlainTextAsync();

        /// <summary>
        /// Open a stream to read the plain text body content. Caller must dispose the stream.
        /// Returns null when no body is available or streaming unsupported.
        /// </summary>
        Stream? OpenPlainTextBodyStream();

        /// <summary>
        /// Returns the sent time of the message, if available.
        /// </summary>
        DateTimeOffset? SentTime { get; }

        /// <summary>
        /// Returns the received time of the message, if available.
        /// </summary>
        DateTimeOffset? ReceivedTime { get; }

        /// <summary>
        /// Returns the sender's email address, if available.
        /// </summary>
        string? Sender { get; }

        /// <summary>
        /// List of "To" recipients.
        /// </summary>
        IReadOnlyList<string> RecipientsTo { get; }

        /// <summary>
        /// List of "Cc" recipients.
        /// </summary>
        IReadOnlyList<string> RecipientsCc { get; }

        /// <summary>
        /// List of "Bcc" recipients.
        /// </summary>
        IReadOnlyList<string> RecipientsBcc { get; }

        /// <summary>
        /// Number of attachments
        /// </summary>
        int AttachmentCount { get; }

        /// <summary>
        /// List of attachments
        /// </summary>
        IReadOnlyList<IAttachment> Attachments { get; }

        /// <summary>
        /// Gets the attachment at the specified index.
        /// </summary>
        /// <param name="index">Zero based index of the attachment</param>
        /// <returns>Attachment</returns>
        IAttachment? GetAttachment(int index);

        /// <summary>
        /// Try to get an entry value interpreted as UTF8 string.
        /// </summary>
        bool TryGetEntryValueUtf8(uint entryType, out string? value);

        /// <summary>
        /// Try to get an entry value interpreted as a 32-bit integer.
        /// </summary>
        bool TryGetEntryValueInt32(uint entryType, out int? value);

        /// <summary>
        /// Try to get an entry value interpreted as a filetime (DateTimeOffset).
        /// </summary>
        bool TryGetEntryValueFiletime(uint entryType, out DateTimeOffset? value);
    }
}