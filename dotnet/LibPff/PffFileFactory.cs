namespace LibPff
{
    /// <summary>
    /// Factory to create IFile instances. Default factory will use the libpff backend.
    /// Providing your own factory allows swapping the backend implementation.
    /// </summary>
    public class PffFileFactory
    {
        /// <summary>
        /// Open the PST file at <paramref name="path"/> and return an implementation of <see cref="IFile"/>.
        /// Caller owns and must dispose the returned IFile.
        /// </summary>
        public static IFile Create(string path)
        {
            return new Model.File(path);
        }
    }
}