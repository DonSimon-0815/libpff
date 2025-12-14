// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System.Runtime.InteropServices;

namespace LibPff.Interop
{
    internal sealed class ErrorHandle : SafeHandle
    {
        private INativeAdapter _native;

        public ErrorHandle(nint handle, INativeAdapter native, bool ownsHandle)
            : base(nint.Zero, ownsHandle)
        {
            _native = native;
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == nint.Zero;

        protected override bool ReleaseHandle()
        {
            _native.ErrorFree(out handle);
            return true;
        }
    }
}