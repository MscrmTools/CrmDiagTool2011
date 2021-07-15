using System;
using System.Runtime.InteropServices;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// Native methods for PInvoke.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Memory status.
        /// </summary>
        /// <param name="lpBuffer">Memory status information.</param>
        /// <returns>True if success.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GlobalMemoryStatusEx([In, Out] MemoryStatus buffer);


        /// <summary>
        /// Security manager class ID.
        /// </summary>
        public readonly static Guid CLSIDSecurityManager = new Guid("7b8a2d94-0ac9-11d1-896c-00c04fb6bfc4");
    }
}
