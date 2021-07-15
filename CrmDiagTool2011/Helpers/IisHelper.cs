using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Web.Administration;

namespace CrmDiagTool2011.Helpers
{
    /// <summary>
    /// This class retrieves data from IIS web server
    /// </summary>
    class IisHelper
    {
        /// <summary>
        /// Retrieves the name of web sites in the local web server
        /// </summary>
        /// <returns>List of web sites name</returns>
        internal static List<string> GetSitesNames()
        {
            try
            {
                List<string> sitesNames = new List<string>();

                using (ServerManager sManager = new ServerManager())
                {
                    foreach (Site site in sManager.Sites)
                    {
                        sitesNames.Add(site.Name);
                    }
                }

                return sitesNames;
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving web sites names: " + error.Message, error);
            }
        }

        /// <summary>
        /// Retrieves information from a specific web site
        /// </summary>
        /// <param name="siteName">Name of the web site</param>
        /// <returns>Informatino of the web site</returns>
        internal static Dictionary<string, string> GetSiteInfo(string siteName)
        {
            try
            {
                Dictionary<string, string> siteInfo = new Dictionary<string, string>();

                using (ServerManager sManager = new ServerManager())
                {
                    // Retrieves the site specified in parameter
                    Site currentSite = sManager.Sites.First(s => s.Name == siteName);

                    siteInfo.Add("Id", currentSite.Id.ToString());
                    siteInfo.Add("State", currentSite.State.ToString());
                }

                return siteInfo;
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving site info: " + error.Message, error);
            }
        }

        /// <summary>
        /// Retrieves binding information about a web site
        /// </summary>
        /// <param name="siteName">Name of the web site</param>
        /// <returns>binding information of the web site</returns>
        internal static DataTable GetSiteBindings(string siteName)
        {
            try
            {
                // Create the data table 
                DataTable table = new DataTable();
                table.Columns.Add("Protocol");
                table.Columns.Add("Host");
                table.Columns.Add("IP");
                table.Columns.Add("Port");

                using (ServerManager sManager = new ServerManager())
                {
                    Site currentSite = sManager.Sites.FirstOrDefault(s => s.Name == siteName);

                    for (int i = 0; i < currentSite.Bindings.Count; i++)
                    {
                        DataRow row = table.NewRow();
                        row["Protocol"] = currentSite.Bindings[i].Protocol;
                        row["Host"] = string.IsNullOrEmpty(currentSite.Bindings[i].Host) ? "(No host header)" : currentSite.Bindings[i].Host;

                        if (currentSite.Bindings[i].EndPoint != null)
                        {
                            if (currentSite.Bindings[i].EndPoint.Address != null)
                            {
                                row["IP"] = currentSite.Bindings[i].EndPoint.Address.ToString() == "0.0.0.0" ? "(All unassigned)" : currentSite.Bindings[i].EndPoint.Address.ToString();
                            }

                            if (currentSite.Bindings[i].EndPoint.Port != null)
                            {
                                row["Port"] = currentSite.Bindings[i].EndPoint.Port.ToString();
                            }
                        }

                        table.Rows.Add(row);
                    }
                }

                return table;
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving site bindings: " + error.Message, error);
            }
        }

        /// <summary>
        /// Retrieves information about the application pools of the local web
        /// server
        /// </summary>
        /// <returns></returns>
        internal static DataTable GetApplicationPools()
        {
            try
            {
                // Create the data table 
                DataTable table = new DataTable();
                table.Columns.Add("Name");
                table.Columns.Add("State");
                table.Columns.Add("PipelineMode");
                table.Columns.Add("RuntimeVersion");
                table.Columns.Add("Identity");

                using (ServerManager sManager = new ServerManager())
                {
                    foreach (ApplicationPool appPool in sManager.ApplicationPools)
                    {
                        DataRow row = table.NewRow();
                        row["Name"] = appPool.Name;
                        row["State"] = appPool.State.ToString();
                        row["PipelineMode"] = appPool.ManagedPipelineMode.ToString();
                        row["RuntimeVersion"] = appPool.ManagedRuntimeVersion.ToString();
                        row["Identity"] = appPool.ProcessModel.IdentityType == ProcessModelIdentityType.SpecificUser ? appPool.ProcessModel.UserName : appPool.ProcessModel.IdentityType.ToString();

                        table.Rows.Add(row);
                    }
                }

                return table;
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving application pools: " + error.Message, error);
            }
        }
    }
}
