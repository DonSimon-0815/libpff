// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System.Runtime.InteropServices;

namespace LibPff.Interop
{
    public static class NativeAdapterFactory
    {
        public static INativeAdapter Create()
        {
            INativeAdapter adapter;
            if (!Environment.Is64BitOperatingSystem && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                adapter = new NativeAdapterWin32();
            }
            else if (Environment.Is64BitOperatingSystem && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                adapter = new NativeAdapterWin64();
            }
            else
            {
                throw new PffException($"Operating system {RuntimeInformation.OSDescription} not supported.");
            }
            return adapter;
        }
    }
}