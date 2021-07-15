using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmDiagTool2011.Helpers
{
    /// <summary>
    /// This class is used to retrieve information about CRM server roles
    /// </summary>
    class ServerRoleHelper
    {
        /// <summary>
        /// Enumerations of CRM Servers roles
        /// </summary>
        [Flags]
        internal enum Roles
        {
            AppServer = 0x1,
            AsyncService = 0x2,
            DiscoveryService = 0x8,
            WebService = 0x20,
            ApiServer = 0x8000,
            HelpServer = 0x40000,
            DeploymentService = 0x200000,
            AdminWebService = 0x2000,
            ConfigSqlServer = 0x10000,
            ConfigWitnessServer = 0x20000,
            DeploymentManagementTools = 0x4000000,
            Dns = 0x4000,
            EmailService = 0x10,
            LivePlatform = 0x800,
            Portal = 0x200,
            Provisioning = 0x400,
            SandboxServer = 0x1000000,
            ScaleGroupProvisioning = 0x800000,
            SqlGovernor = 0x40,
            SqlServer = 0x100,
            SrsDataConnector = 0x4,
            SrsSqlServer = 0x400000,
            StatsSqlServer = 0x80000,
            Support = 0x1000,
            TuningSqlServer = 0x100000,
            WitnessServer = 0x80
        }

        /// <summary>
        /// Finds a list of roles from an integer
        /// </summary>
        /// <param name="value">Interger value for role collection</param>
        /// <returns>List of roles</returns>
        internal static List<string> GetRoles(int value)
        {
            List<string> roles = new List<string>();
            
            if ((value & (int)Roles.AdminWebService) == (int)Roles.AdminWebService)
                roles.Add("Administration Web Service");

            if ((value & (int)Roles.ApiServer) == (int)Roles.ApiServer)
                roles.Add("API Server");

            if ((value & (int)Roles.AppServer) == (int)Roles.AppServer)
                roles.Add("Application Server");

            if ((value & (int)Roles.AsyncService) == (int)Roles.AsyncService)
                roles.Add("Asynchronous processing service");

            if ((value & (int)Roles.ConfigSqlServer) == (int)Roles.ConfigSqlServer)
                roles.Add("ConfigSqlServer");

            if ((value & (int)Roles.ConfigWitnessServer) == (int)Roles.ConfigWitnessServer)
                roles.Add("ConfigWitnessServer");

            if ((value & (int)Roles.DeploymentManagementTools) == (int)Roles.DeploymentManagementTools)
                roles.Add("DeploymentManagementTools");

            if ((value & (int)Roles.DeploymentService) == (int)Roles.DeploymentService)
                roles.Add("DeploymentService");

            if ((value & (int)Roles.DiscoveryService) == (int)Roles.DiscoveryService)
                roles.Add("DiscoveryService");

            if ((value & (int)Roles.Dns) == (int)Roles.Dns)
                roles.Add("Dns");

            if ((value & (int)Roles.EmailService) == (int)Roles.EmailService)
                roles.Add("EmailService");

            if ((value & (int)Roles.HelpServer) == (int)Roles.HelpServer)
                roles.Add("HelpServer");

            if ((value & (int)Roles.LivePlatform) == (int)Roles.LivePlatform)
                roles.Add("LivePlatform");

            if ((value & (int)Roles.Portal) == (int)Roles.Portal)
                roles.Add("Portal");

            if ((value & (int)Roles.Provisioning) == (int)Roles.Provisioning)
                roles.Add("Provisioning");

            if ((value & (int)Roles.SandboxServer) == (int)Roles.SandboxServer)
                roles.Add("SandboxServer");

            if ((value & (int)Roles.ScaleGroupProvisioning) == (int)Roles.ScaleGroupProvisioning)
                roles.Add("ScaleGroupProvisioning");

            if ((value & (int)Roles.SqlGovernor) == (int)Roles.SqlGovernor)
                roles.Add("SqlGovernor");

            if ((value & (int)Roles.SqlServer) == (int)Roles.SqlServer)
                roles.Add("SqlServer");

            if ((value & (int)Roles.SrsDataConnector) == (int)Roles.SrsDataConnector)
                roles.Add("SrsDataConnector");

            if ((value & (int)Roles.SrsSqlServer) == (int)Roles.SrsSqlServer)
                roles.Add("SrsSqlServer");

            if ((value & (int)Roles.StatsSqlServer) == (int)Roles.StatsSqlServer)
                roles.Add("StatsSqlServer");

            if ((value & (int)Roles.Support) == (int)Roles.Support)
                roles.Add("Support");

            if ((value & (int)Roles.TuningSqlServer) == (int)Roles.TuningSqlServer)
                roles.Add("TuningSqlServer");

            if ((value & (int)Roles.WebService) == (int)Roles.WebService)
                roles.Add("WebService");

            if ((value & (int)Roles.WitnessServer) == (int)Roles.WitnessServer)
                roles.Add("WitnessServer");

            return roles;
        }
    }
}
