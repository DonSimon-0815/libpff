// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System.Runtime.InteropServices;

namespace LibPff.Interop
{
    internal sealed class RecordEntryHandle : SafeHandle
    {
        private INativeAdapter _native;

        public RecordEntryHandle(nint handle, INativeAdapter native, bool ownsHandle)
            : base(nint.Zero, ownsHandle)
        {
            _native = native;
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == nint.Zero;

        protected override bool ReleaseHandle()
        {
            nint tmp = handle;
            int rc = _native.RecordEntryFree(out tmp, nint.Zero);
            handle = nint.Zero;
            return rc == 1;
        }
    }
}