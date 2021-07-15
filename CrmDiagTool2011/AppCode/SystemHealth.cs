using System;
using System.Globalization;
using System.Management;
using Microsoft.Win32;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// System health.
    /// </summary>
    internal static class SystemHealth
    {
        /// <summary>
        /// Processor speed.
        /// </summary>
        public static int ProcessorSpeed
        {
            get
            {
                using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0"))
                {
                    return (int)regKey.GetValue("~MHz", 0);
                }
            }
        }

        /// <summary>
        /// Disk space.
        /// </summary>
        /// <param name="drive">Drive.</param>
        /// <returns>Free space (in megs).</returns>
        public static int GetFreeDiskSpace(string drive)
        {

            // Get free drive space from WMI
            drive = drive.TrimEnd(new char[] { '\\' });
            string query = String.Format(CultureInfo.InvariantCulture, "SELECT name, FreeSpace FROM Win32_LogicalDisk WHERE deviceId = '{0}'", drive);
            SelectQuery selectQuery = new SelectQuery(query);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
            foreach (ManagementObject mo in searcher.Get())
            {
                Object o = mo["FreeSpace"];
                return (int)((null == o) ? 0 : ((UInt64)mo["FreeSpace"] / (1024 * 1024)));
            }
            return 0;
        }
    }
}
