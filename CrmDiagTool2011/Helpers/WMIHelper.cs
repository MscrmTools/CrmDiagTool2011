using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;

namespace CrmDiagTool2011.Helpers
{
    class WMIHelper
    {
        /// <summary>
        /// The WMI Class About NIC.
        /// </summary>
        public static string WMI_Win32_NetworkAdapter = "Win32_NetworkAdapter";
        /// <summary>
        /// The WMI Class About MotherBoard.
        /// </summary>
        public static string WMI_Win32_BaseBoard = "Win32_BaseBoard";
        ///<summary>
        ///The WMI Class About Processor.
        ///</summary>
        public static string WMI_Win32_Processor = "Win32_Processor";
        ///<summary>
        ///The WMI Class About Computer Machine.
        ///</summary>
        public static string WMI_Win32_ComputerSystem = "Win32_ComputerSystem";
        ///<summary>
        ///The WMI Class About Computer Machine Product.
        ///</summary>
        public static string WMI_Win32_ComputerSystemProduct = "Win32_ComputerSystemProduct";
        ///<summary>
        ///The WMI Class About Computer OS.
        ///</summary>
        public static string WMI_Win32_OperatingSystem = "Win32_OperatingSystem";


        /// <summary>
        /// Network access.
        /// </summary>
        private static object network;
        
        /// <summary>
        /// Object to store the ReportServer WMI Settings Dictionary in memory.
        /// </summary>
        private static object reportservercollection;
       
        /// <summary>
        /// Object to store the ReportManager WMI Settings Dictionary in memory.
        /// </summary>
        private static object reportmanagercollection;

        /// <summary>
        /// Return singleton WMI property as a string.
        /// </summary>
        /// <param name="strWmiClass">WMI Class like "Win32_Processor"</param>
        /// <param name="strPropName">WMI Property of this class like "Name"</param>
        public static string GetWMIProp(string strWmiClass, string strPropName)
        {
                ManagementClass mc = new ManagementClass(strWmiClass);
                ManagementObjectCollection moc = mc.GetInstances();

                String strMyProperty = null;
                foreach (ManagementObject mo in moc)
                {
                    strMyProperty = mo.Properties[strPropName].Value.ToString().Trim();
                    break;
                }
                return strMyProperty;
        }

        /// <summary>
        /// Returns the full collection of a particular WMI Class as a Dictionnary.
        /// </summary>
        /// <param name="strWMINameSpace">The WMI Namespace to connect to</param>
        /// <param name="strWMIClass">The WMI Class to retrieve information from</param>
        /// <returns></returns>
        public static IDictionary<string, string> GetWMIPropCollection(string strWMINameSpace, string strWMIClass)
        {
            ManagementClass serverClass;
            ManagementScope scope;
            IDictionary<string, string> WMIPropertyCollection = new Dictionary<string, string>();

            try
            {

                scope = new ManagementScope(strWMINameSpace);
                // Connect to the namespace.
                scope.Connect();
                // Create the server class.
                serverClass = new ManagementClass(strWMIClass);
                // Connect to the management object.
                serverClass.Get();
                // Loop through the instances of the server class.
                ManagementObjectCollection instances = serverClass.GetInstances();

                foreach (ManagementObject instance in instances)
                {
                    PropertyDataCollection instProps = instance.Properties;
                    foreach (PropertyData prop in instProps)
                    {
                        string name = prop.Name;
                        object val = prop.Value;
                        Console.Out.Write("Property Name: " + name);
                        if (val != null)
                            WMIPropertyCollection.Add(name, val.ToString());
                        else
                            WMIPropertyCollection.Add(name, "<NULL>");
                    }
                }
            }
            catch (Exception e)
            {
                WMIPropertyCollection.Add("Error", e.StackTrace);
            }

            return WMIPropertyCollection;
        }

        /// <summary>
        /// Get the Machine CPU Information (Ex: CPU: Intel(R) Xeon(TM) CPU 3.40GHz)
        /// </summary>
        public static string CPUGeneralInfo
        {
            get { return WMIHelper.GetWMIProp(WMI_Win32_Processor,"Name"); }
        }

        /// <summary>
        /// Get the Machine CPU Architecture (Ex: x86,x64,Itanium, etc...)
        /// </summary>
        public static string CPUArchitectureInfo
        {
            get
            {
                string sArchi = WMIHelper.GetWMIProp(WMI_Win32_Processor, "Architecture");
                switch (sArchi)
                {
                    case "0":
                        return "x86";
                    case "6":
                        return "Intel Itanium Processor Family (IPF)";
                    case "9":
                        return "x64";
                    default:
                        return "Invalid Processor Architecture";
                }
            }
        }

        /// <summary>
        /// Get the Machine Total RAM Information in MB
        /// </summary>
        public static string RAMInfo
        {
            get
            {
                string strRAM = WMIHelper.GetWMIProp(WMI_Win32_ComputerSystem, "TotalPhysicalMemory");
                long intRAM = Convert.ToInt64(strRAM) / 1048576 + 1;
                return intRAM.ToString();
            }
        }

        /// <summary>
        /// Get the Operation System LanguageID
        /// </summary>
        public static string OSLanguage
        {
            get { return WMIHelper.GetWMIProp(WMI_Win32_OperatingSystem, "OSLanguage"); }
        }

        /// <summary>
        /// Get the OS Architecture Info (32 or 64 bits?)
        /// </summary>
        public static string OSArchitecture
        {
            get { return WMIHelper.GetWMIProp(WMI_Win32_OperatingSystem, "OSArchitecture"); }
        }

        /// <summary>
        /// Check if the CRM Server is a Domain Controller.
        /// </summary>
        public static bool IsDomainControler
        {
           get
           {
               string sRole = WMIHelper.GetWMIProp(WMI_Win32_ComputerSystem, "DomainRole");
               if (int.Parse(sRole) > 3) return true;
               else return false;
           } 
        }

        /// <summary>
        /// Check if the machine is a Virtual Machine or not (works for MS Virtual Machine)
        /// </summary>
        public static string ComputerSystemProductName 
        {
            get
            {
                return WMIHelper.GetWMIProp(WMI_Win32_ComputerSystemProduct, "Name");
            }
        }

        /// <summary>
        /// Check if the machine is a Virtual Machine or not (works for MS Virtual Machine + WMWare)
        /// </summary>
        public static string MotherBoardManufacturer
        {
            get
            {
                return WMIHelper.GetWMIProp(WMI_Win32_BaseBoard, "Manufacturer");
            }
        }

        /// <summary>
        /// Check of we have Network....
        /// </summary>
        public static bool Network
        {
            get 
            {
                // Check if the state of the Network is already know.
                if (null != WMIHelper.network)
                    return (bool)WMIHelper.network;

                //Cache the state of the Network
                // Do not use SystemInformation.Network as it just don't work!
                WMIHelper.network = false;

                try
                {
                    if (Convert.ToInt32(WMIHelper.GetWMIProp(WMI_Win32_NetworkAdapter, "NetConnectionStatus"), CultureInfo.InvariantCulture) == 2)
                    {
                        WMIHelper.network = true;
                    }
                }
                catch
                {
                    // On error, assume there is connectivity unless really proven otherwise
                    // Tests reporting authentication failure will report issues
                    WMIHelper.network = true;
                }

                return (bool)WMIHelper.network;
            }
        }
    }
}
