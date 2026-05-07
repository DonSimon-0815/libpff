// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System.Runtime.InteropServices;
using LibPff.Utility;

namespace LibPff.Interop
{
    internal sealed class MultiValueHandle : SafeHandle
    {
        private readonly INativeAdapter _native;

        public override bool IsInvalid => handle == nint.Zero;

        public MultiValueHandle(nint handle, INativeAdapter native, bool ownsHandle)
            : base(nint.Zero, ownsHandle)
        {
            _native = native;
            SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
			IntPtr error = IntPtr.Zero;
            nint tmp = handle;

            int rc = _native.MultiValueFree(out tmp, out error);

            handle = nint.Zero;

            ReturnCode.Check(
                rc,
                error,
                "MultiValueFree(out tmp, out error)",
                ptr =>
                {
                    var sb = new System.Text.StringBuilder(512);
                    _native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => _native.ErrorFree(out ptr)
            );

            return rc == 1;
        }
    }
}