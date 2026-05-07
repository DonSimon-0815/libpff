// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System.Runtime.InteropServices;
using LibPff.Utility;

namespace LibPff.Interop
{
    internal sealed class ErrorHandle : SafeHandle
    {
        private readonly INativeAdapter _native;

        public override bool IsInvalid => handle == nint.Zero;

        public ErrorHandle(nint handle, INativeAdapter native, bool ownsHandle)
            : base(nint.Zero, ownsHandle)
        {
            _native = native;
            SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            _native.ErrorFree(out handle);
            return true;
        }
    }
}