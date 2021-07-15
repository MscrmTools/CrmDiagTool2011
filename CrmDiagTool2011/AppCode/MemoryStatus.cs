using System.Runtime.InteropServices;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// Memory status information (interop data structure).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal class MemoryStatus
    {
        public uint dwLength;
        public uint dwMemoryLoad;
        public ulong ullTotalPhys;
        public ulong ullAvailPhys;
        public ulong ullTotalPageFile;
        public ulong ullAvailPageFile;
        public ulong ullTotalVirtual;
        public ulong ullAvailVirtual;
        public ulong ullAvailExtendedVirtual;

        public MemoryStatus()
        {
            this.dwLength = (uint)Marshal.SizeOf(typeof(MemoryStatus));
        }
    }
}
