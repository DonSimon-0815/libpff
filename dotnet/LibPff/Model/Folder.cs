using LibPff.Interop;
using System.Text;

namespace LibPff.Model
{
    internal class Folder : Item, IFolder
    {
        public Folder(nint handle, INativeAdapter native, bool ownsHandle) : base(handle, native, ownsHandle)
        {
        }

        public string Name
        {
            get
            {
                // try UTF8 name
                int rc = Native.FolderGetUtf8NameSize(RawHandle, out nuint size, nint.Zero);
                if (rc != 1) throw new PffException($"FolderGetUtf8NameSize failed: {rc}", rc);
                int len = (int)size;
                if (len == 0) return string.Empty;
                var buf = new byte[len];
                rc = Native.FolderGetUtf8Name(RawHandle, buf, (nuint)buf.Length, nint.Zero);
                if (rc != 1) throw new PffException($"FolderGetUtf8Name failed: {rc}", rc);
                // Remove possible null terminator
                int valid = buf.Length;
                if (buf[buf.Length - 1] == 0) valid = buf.Length - 1;
                return Encoding.UTF8.GetString(buf, 0, valid);
            }
        }

        public int SubFolderCount
        {
            get
            {
                int rc = Native.FolderGetNumberOfSubFolders(RawHandle, out int number, nint.Zero);
                if (rc != 1) throw new PffException($"FolderGetNumberOfSubFolders failed: {rc}", rc);
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
                {
                    list.Add(GetSubFolder(i));
                }
                return list;
            }
        }

        private IFolder GetSubFolder(int index)
        {
            int rc = Native.FolderGetSubFolder(RawHandle, index, out var subHandle, nint.Zero);
            if (rc == 1 && subHandle != nint.Zero)
                return new Folder(subHandle, Native, ownsHandle: true);

            throw new InvalidOperationException($"Unable to read subfolder {index}.");
        }

        public int MessageCount
        {
            get
            {
                int rc = Native.FolderGetNumberOfSubMessages(RawHandle, out int number, nint.Zero);
                if (rc != 1) throw new PffException($"FolderGetNumberOfSubMessages failed: {rc}", rc);
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
                {
                    list.Add(GetMessage(i));
                }
                return list;
            }
        }

        private IMessage GetMessage(int index)
        {
            int rc = Native.FolderGetSubMessage(RawHandle, index, out nint message, nint.Zero);
            if (rc == 1 && message != nint.Zero)
                return new Message(message, Native, ownsHandle: true);

            throw new InvalidOperationException($"Unable to read message {index}.");
        }

        public IFolder? GetSubFolderByUtf8Name(string utf8Name)
        {
            var buf = Encoding.UTF8.GetBytes(utf8Name ?? string.Empty);
            int rc = Native.FolderGetSubFolderByUtf8Name(RawHandle, buf, (nuint)buf.Length, out nint sub, nint.Zero);
            if (rc != 1 || sub == nint.Zero) return null;
            return new Folder(sub, Native, ownsHandle: true);
        }

        public IMessage? GetSubMessageByUtf8Name(string utf8Name)
        {
            var buf = Encoding.UTF8.GetBytes(utf8Name ?? string.Empty);
            int rc = Native.FolderGetSubMessageByUtf8Name(RawHandle, buf, (nuint)buf.Length, out nint msg, nint.Zero);
            if (rc != 1 || msg == nint.Zero) return null;
            return new Message(msg, Native, ownsHandle: true);
        }
    }
}