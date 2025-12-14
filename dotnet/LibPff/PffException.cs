namespace LibPff
{
    /// <summary>
    /// Pff exception
    /// </summary>
    public class PffException : Exception
    {
        /// <summary>
        /// Numeric error code
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// Constructor. Creates the PffException.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="errorCode">Numeric error code</param>
        public PffException(string message, int errorCode = 0) : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Constructor. Creates the PffException with an inner exception.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exception</param>
        /// <param name="errorCode">Numeric error code</param>
        public PffException(string message, Exception inner, int errorCode = 0) : base(message, inner)
        {
            ErrorCode = errorCode;
        }
    }
}