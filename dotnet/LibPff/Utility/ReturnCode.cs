namespace LibPff.Utility
{
    internal static class ReturnCode
    {
        public static void Check(
            int rc,
            IntPtr errorPtr,
            string apiName,
            Func<IntPtr, string> getErrorMessage,
            Action<IntPtr> freeError)
        {
            if (rc == 1)
                return;

            string message = $"{apiName} failed";

            if (errorPtr != IntPtr.Zero)
            {
                string nativeMessage = getErrorMessage(errorPtr);
                freeError(errorPtr);

                if (!string.IsNullOrWhiteSpace(nativeMessage))
                    message += $": {nativeMessage}";
            }

            throw new PffException(message);
        }
    }
}
