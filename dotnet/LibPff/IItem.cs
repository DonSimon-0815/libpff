namespace LibPff
{
    /// <summary>
    /// Common abstraction for PST items (folders, messages, attachments).
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Unique identifier for the item in the PST (backend identifier).
        /// </summary>
        int Identifier { get; }

        /// <summary>
        /// Type of the item.
        /// </summary>
        ItemType Type { get; }
    }
}