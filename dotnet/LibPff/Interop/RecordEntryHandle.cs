// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System.Runtime.InteropServices;
using LibPff.Utility;

namespace LibPff.Interop
{
    internal sealed class RecordEntryHandle : SafeHandle
    {
        private readonly INativeAdapter _native;

        public RecordEntryHandle(nint handle, INativeAdapter native, bool ownsHandle)
            : base(nint.Zero, ownsHandle)
        {
            _native = native;
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == nint.Zero;

        protected override bool ReleaseHandle()
        {
			IntPtr error = IntPtr.Zero;
            nint tmp = handle;

            int rc = _native.RecordEntryFree(out tmp, out error);

            handle = nint.Zero;

            ReturnCode.Check(
                rc,
                error,
                "RecordEntryFree(out tmp, out error)",
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