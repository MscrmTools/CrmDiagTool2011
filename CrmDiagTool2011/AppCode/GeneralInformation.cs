using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using CrmDiagTool2011.Helpers;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// This class gathers general information about the local server
    /// </summary>
    class GeneralInformation
    {
        /// <summary>
        /// Retrieves information about the local server
        /// </summary>
        /// <returns></returns>
        internal Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            MemoryStatus memoryStatus = new MemoryStatus();
            NativeMethods.GlobalMemoryStatusEx(memoryStatus);

            values.Add("Computer Name", SystemInformation.ComputerName);
            values.Add("Computer System Product Name", WMIHelper.ComputerSystemProductName);
            values.Add("Mother Board Manufacturer", WMIHelper.MotherBoardManufacturer);
            values.Add("Is it a DC", WMIHelper.IsDomainControler.ToString());
            values.Add("Domain Name", SystemInformation.UserDomainName);
            values.Add("User Domain Name", Environment.UserDomainName);
            values.Add("User Name", Environment.UserName);
            values.Add("Operating System Version", Environment.OSVersion.VersionString);
            values.Add("Operating System Language", WMIHelper.OSLanguage);
            values.Add(".NET Framework", Environment.Version.ToString());
            values.Add("Processor Count", Environment.ProcessorCount.ToString());
            values.Add("Processor Speed (MHz)", SystemHealth.ProcessorSpeed.ToString());
            values.Add("System Directory", Environment.SystemDirectory);
            values.Add("Application Data Directory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            values.Add("Program Files Directory", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            values.Add("Connected", WMIHelper.Network.ToString());
            values.Add("Boot Mode", SystemInformation.BootMode.ToString());
            values.Add("Battery Charge", SystemInformation.PowerStatus.BatteryChargeStatus.ToString());
            values.Add("Battery Life %", SystemInformation.PowerStatus.BatteryLifePercent.ToString());
            values.Add("Power Status", SystemInformation.PowerStatus.PowerLineStatus.ToString());
            values.Add("Monitor Height", SystemInformation.PrimaryMonitorSize.Height.ToString());
            values.Add("Monitor Width", SystemInformation.PrimaryMonitorSize.Width.ToString());
            values.Add("Terminal Server Session", SystemInformation.TerminalServerSession.ToString());
            values.Add("Memory Load %", memoryStatus.dwMemoryLoad.ToString());
            values.Add("Total Physical Memory (Megs)", ((int)(memoryStatus.ullTotalPhys / (1024 * 1024))).ToString());
            values.Add("Total Virtual Memory (Megs)", ((int)(memoryStatus.ullTotalVirtual / (1024 * 1024))).ToString());
            values.Add("Available Virtual Memory (Megs)", ((int)(memoryStatus.ullAvailVirtual / (1024 * 1024))).ToString());

            List<string> disks = new List<string>();
            foreach (string logicalDrive in Environment.GetLogicalDrives())
            {
                disks.Add(logicalDrive + ": " + SystemHealth.GetFreeDiskSpace(logicalDrive));
            }

            values.Add("Free Disk Space (Megs):", string.Join("\r\n", disks));
            values.Add("Host Name", Dns.GetHostName());
            
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            values.Add("Aliases", string.Join("\r\n", ipHostEntry.Aliases));

            List<string> ips = new List<string>();
            foreach (IPAddress ipAddress in ipHostEntry.AddressList)
            {
                ips.Add(ipAddress.ToString());
            }

            values.Add("IP Addresses", string.Join("\r\n", ips)); 

            return values;
        }
    }
}
