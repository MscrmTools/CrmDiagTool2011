using System;
using System.ServiceProcess;

namespace CrmDiagTool2011.Helpers
{
    /// <summary>
    ///  This class is used to retrieve information from Windows Services
    /// </summary>
    class ServiceHelper
    {
        /// <summary>
        /// Retrieves the status of a specific Windows service
        /// </summary>
        /// <param name="serviceName">Name of the Windows service</param>
        /// <returns></returns>
        internal static string GetServiceStatus(string serviceName)
        {
            try
            {
                using (ServiceController sc = new ServiceController(serviceName))
                {
                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            return "Running";
                        case ServiceControllerStatus.Stopped:
                            return "Stopped";
                        case ServiceControllerStatus.Paused:
                            return "Paused";
                        default:
                            return "Ambiguous(?)";
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving status of the Windows service: " + error.Message, error);
            }
        }
    }
}
