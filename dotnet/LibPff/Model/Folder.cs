using LibPff.Interop;
using LibPff.Utility;
using System.Text;

namespace LibPff.Model
{
    internal class Folder : Item, IFolder
    {
        public Folder(nint handle, INativeAdapter native, bool ownsHandle)
            : base(handle, native, ownsHandle)
        {
        }

        public string Name
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                // Query UTF‑8 name size
                int rc = Native.FolderGetUtf8NameSize(RawHandle, out nuint size, out error);
                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.FolderGetUtf8NameSize),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                int len = (int)size;
                if (len == 0)
                    return string.Empty;

                var buf = new byte[len];

                rc = Native.FolderGetUtf8Name(RawHandle, buf, (nuint)buf.Length, out error);
                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.FolderGetUtf8Name),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                int valid = buf.Length;
                if (buf[^1] == 0)
                    valid--;

                return Encoding.UTF8.GetString(buf, 0, valid);
            }
        }

        public int SubFolderCount
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.FolderGetNumberOfSubFolders(RawHandle, out int number, out error);
                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.FolderGetNumberOfSubFolders),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return number;
            }
        }

        public IReadOnlyList<IFolder> SubFolders
        {
            get
            {
                var list = new List<IFolder>();
                int count = SubFolderCount;

                for (int i = 0; i < count; i++)
                    list.Add(GetSubFolder(i));

                return list;
            }
        }

        private IFolder GetSubFolder(int index)
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.FolderGetSubFolder(RawHandle, index, out nint subHandle, out error);

            if (rc == 1 && subHandle != IntPtr.Zero)
                return new Folder(subHandle, Native, ownsHandle: true);

            if (error != IntPtr.Zero)
                Native.ErrorFree(out error);

            throw new PffException($"Unable to read subfolder {index}");
        }

        public int MessageCount
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.FolderGetNumberOfSubMessages(RawHandle, out int number, out error);
                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.FolderGetNumberOfSubMessages),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return number;
            }
        }

        public IReadOnlyList<IMessage> Messages
        {
            get
            {
                var list = new List<IMessage>();
                int count = MessageCount;

                for (int i = 0; i < count; i++)
                    list.Add(GetMessage(i));

                return list;
            }
        }

        private IMessage GetMessage(int index)
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.FolderGetSubMessage(RawHandle, index, out nint msg, out error);

            if (rc == 1 && msg != IntPtr.Zero)
                return new Message(msg, Native, ownsHandle: true);

            if (error != IntPtr.Zero)
                Native.ErrorFree(out error);

            throw new PffException($"Unable to read message {index}");
        }

        public IFolder? GetSubFolderByUtf8Name(string utf8Name)
        {
            var buf = Encoding.UTF8.GetBytes(utf8Name ?? string.Empty);
            IntPtr error = IntPtr.Zero;

            int rc = Native.FolderGetSubFolderByUtf8Name(RawHandle, buf, (nuint)buf.Length, out nint sub, out error);

            if (rc == 1 && sub != IntPtr.Zero)
                return new Folder(sub, Native, ownsHandle: true);

            if (error != IntPtr.Zero)
                Native.ErrorFree(out error);

            return null;
        }

        public IMessage? GetSubMessageByUtf8Name(string utf8Name)
        {
            var buf = Encoding.UTF8.GetBytes(utf8Name ?? string.Empty);
            IntPtr error = IntPtr.Zero;

            int rc = Native.FolderGetSubMessageByUtf8Name(RawHandle, buf, (nuint)buf.Length, out nint msg, out error);

            if (rc == 1 && msg != IntPtr.Zero)
                return new Message(msg, Native, ownsHandle: true);

            if (error != IntPtr.Zero)
                Native.ErrorFree(out error);

            return null;
        }
    }
}
