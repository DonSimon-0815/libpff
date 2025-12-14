// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System.Runtime.InteropServices;

namespace LibPff.Interop
{
    internal sealed class FileHandle : SafeHandle
    {
        private INativeAdapter _native;

        public FileHandle(nint handle, INativeAdapter native, bool ownsHandle)
            : base(nint.Zero, ownsHandle)
        {
            _native = native;
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == nint.Zero;

        protected override bool ReleaseHandle()
        {
            nint tmp = handle;
            int rc = _native.FileFree(out tmp, nint.Zero);
            handle = nint.Zero;
            return rc == 1;
        }
    }
}