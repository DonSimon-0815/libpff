namespace LibPff
{
    /// <summary>
    /// Pff exception
    /// </summary>
    public class PffException : Exception
    {
        /// <summary>
        /// Constructor. Creates the PffException.
        /// </summary>
        /// <param name="message">Exception message</param>
        public PffException(string message) : base(message)
        {
        }
    }
}