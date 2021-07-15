using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using CrmDiagTool2011.Helpers;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// This class generates an html report containing information about
    /// a CRM 2011 deployment
    /// </summary>
    class ReportManager
    {
        #region Variables

        /// <summary>
        /// Report control builder
        /// </summary>
        ReportControlBuilder rcb;

        /// <summary>
        /// Report settings
        /// </summary>
        FileInfoSettings settings;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class ReportManager
        /// </summary>
        public ReportManager(FileInfoSettings settings)
        {
            this.rcb = new ReportControlBuilder();
            this.settings = settings;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Generates a report
        /// </summary>
        /// <param name="worker">BackgroundWorker that holds the building task</param>
        /// <returns>the HTML content for the report</returns>
        internal HtmlGenericControl BuildReport(BackgroundWorker worker)
        {
            int percentage = 0;
            int percentageStep = 100 / this.settings.ProgressBarMaxStep;

            HtmlGenericControl mainContainer = new HtmlGenericControl("div");

            #region General information
           
            this.rcb.AddSingleLineOfText(mainContainer, "Executed on: " + DateTime.Now.ToString(CultureInfo.CurrentUICulture.DateTimeFormat));

            this.BuildGeneralInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage); 
            
            this.BuildAspNetFrameworkInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildIpConfigAllInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildEnvironmentVariablesInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildTCPIPParametersInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildBootConfigurationInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage); 
            
            
            #endregion General information

            #region Active Directory information

            this.BuildAdGroupsMembershipInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage); 
            
            #endregion Active Directory information

            #region IIS information

            this.BuildIisInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildApplicationPoolsInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            #endregion IIS information

            #region CRM items information

            this.BuildCrmServicesInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildCrmRegistryKeysInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildCrmFilesInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildCrmLanguagePacksInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            this.BuildCrmGacFilesInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);


            #endregion CRM items information

            #region SQL information

            this.BuildSqlInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);
            
            this.BuildDeploymentPropertiesInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);
            
            this.BuildConfigPropertiesInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);
            
            this.BuildBuildVersionInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);
            
            this.BuildServerInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);
            
            this.BuildOrganizationInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            #endregion SQL information

            #region CRM information

            this.BuildUsersInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);
            
            this.BuildPluginsInformation(mainContainer);
            percentage += percentageStep;
            worker.ReportProgress(percentage);

            #endregion CRM information

            return mainContainer;
        }

        /// <summary>
        /// Adds the HTML content generated into a CRM 2011 styled HTML form
        /// </summary>
        /// <param name="main">HTML content</param>
        internal void GenerateFinalReport(HtmlGenericControl main)
        {
            string content = string.Empty;

            // Retrieves the embedded HTML report file
            Assembly currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (Stream myStream = currentAssembly.GetManifestResourceStream("CrmDiagTool2011.Resources.Report.htm"))
            {
                StreamReader reader = new StreamReader(myStream);
                content = reader.ReadToEnd();
            }

            // Renders the HTML content generated with CRM 2011 deployment 
            // information
            StringWriter sw = new StringWriter();
            HtmlTextWriter h = new HtmlTextWriter(sw);
            main.RenderControl(h);
            string str = sw.GetStringBuilder().ToString();

            // Includes the rendered content into the HTML report file
            content = content.Replace("##content##", str);

            // Asks the user for the save location of the report
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = "Dynamics CRM 2011 report.htm",
                Filter = "Fichier HTML (*.html)|*.html",
                OverwritePrompt = true,
                Title = "Select the location of the report"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName, false))
                {
                    writer.Write(content);
                }
            }
        }

        #region General information

        /// <summary>
        /// Builds General information data
        /// </summary>
        /// <param name="main"></param>
        private void BuildGeneralInformation(HtmlGenericControl main)
        {
            if (this.settings.UseGeneralSystemInfo)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "General information");

                try
                {       // Get general information data
                    GeneralInformation gi = new GeneralInformation();
                    Dictionary<string, string> values = gi.GetValues();

                    // Adds a table with retrieved data
                    this.rcb.AddTable(gc, new string[] { "Key", "Value" }, values);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildAspNetFrameworkInformation(HtmlGenericControl main)
        {
            if (this.settings.UseGeneralFramework)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, ".Net Framework Information");

                try
                {
                    // Get data
                    string command = string.Format("{0}{1}",
                        RegistryHelper.EvaluateString("InstallRoot", @"SOFTWARE\Microsoft\.NETFramework"),
                        @"v4.0.30319\aspnet_regiis.exe");

                    string data = ConsoleHelper.GetConsoleOutPut(command, "-lv");

                    // Adds a table with retrieved data
                    this.rcb.AddSingleLineOfText(gc, data);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildIpConfigAllInformation(HtmlGenericControl main)
        {
            if (this.settings.UseGeneralIPConfig)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "IP Configuration");

                try
                {
                    // Get data
                    string data = ConsoleHelper.GetConsoleOutPut("IPCONFIG", "/ALL");

                    // Adds a table with retrieved data
                    this.rcb.AddSingleLineOfText(gc, data);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildEnvironmentVariablesInformation(HtmlGenericControl main)
        {
            if (this.settings.UseGeneralEnvVariables)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "Environment Variables");

                try
                {
                    // Get general information data
                    Dictionary<string, string> values = new Dictionary<string, string>();

                    foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                    {
                        values.Add(de.Key.ToString(), de.Value.ToString().Replace(";", "\r\n"));
                    }

                    // Adds a table with retrieved data
                    this.rcb.AddTable(gc, new string[] { "Key", "Value" }, values);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildTCPIPParametersInformation(HtmlGenericControl main)
        {
            if (this.settings.UseGeneralTcpIp)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "TCP/IP Parameters");

                try
                {
                    // Get general information data
                    Dictionary<string, string> values = RegistryHelper.GetAllKeysWithPath(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters");

                    // Adds a table with retrieved data
                    this.rcb.AddTable(gc, new string[] { "Key", "Value" }, values);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildBootConfigurationInformation(HtmlGenericControl main)
        {
            if (this.settings.UseGeneralBootIni)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "Boot Configuration Data");

                try
                {
                    // Get data
                    string data = ConsoleHelper.GetConsoleOutPut("BCDEDIT", "/ENUM");

                    // Adds a table with retrieved data
                    this.rcb.AddSingleLineOfText(gc, data);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        #endregion General information

        #region Active Directory information

        private void BuildAdGroupsMembershipInformation(HtmlGenericControl main)
        {
            if (this.settings.UseADGroupMembership)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "Active Directory Groups");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, "SELECT * FROM ConfigSettings");

                    // SQL Access group
                    Dictionary<string, string> groupInfo = ADHelper.ActiveDirectoryProperty(data.Rows[0]["SqlAccessGroupId"].ToString(), "distinguishedname");
                    Dictionary<string, string> groupMembers = ADHelper.ActiveDirectoryProperty(data.Rows[0]["SqlAccessGroupId"].ToString(), "member");
                    this.rcb.AddTabHeader(gc, "Group: " + groupInfo["distinguishedname"]);
                    this.rcb.AddTable(gc, new string[] { "Member", "Distinguished name" }, groupMembers);

                    // Priv User group
                    groupInfo = ADHelper.ActiveDirectoryProperty(data.Rows[0]["PrivilegeUserGroupId"].ToString(), "distinguishedname");
                    groupMembers = ADHelper.ActiveDirectoryProperty(data.Rows[0]["PrivilegeUserGroupId"].ToString(), "member");
                    this.rcb.AddTabHeader(gc, "Group: " + groupInfo["distinguishedname"]);
                    this.rcb.AddTable(gc, new string[] { "Member", "Distinguished name" }, groupMembers);

                    // Reporting group
                    groupInfo = ADHelper.ActiveDirectoryProperty(data.Rows[0]["ReportingGroupId"].ToString(), "distinguishedname");
                    groupMembers = ADHelper.ActiveDirectoryProperty(data.Rows[0]["ReportingGroupId"].ToString(), "member");
                    this.rcb.AddTabHeader(gc, "Group: " + groupInfo["distinguishedname"]);
                    this.rcb.AddTable(gc, new string[] { "Member", "Distinguished name" }, groupMembers);

                    // Priv Reporting group
                    groupInfo = ADHelper.ActiveDirectoryProperty(data.Rows[0]["PrivilegeReportGroupId"].ToString(), "distinguishedname");
                    groupMembers = ADHelper.ActiveDirectoryProperty(data.Rows[0]["PrivilegeReportGroupId"].ToString(), "member");
                    this.rcb.AddTabHeader(gc, "Group: " + groupInfo["distinguishedname"]);
                    this.rcb.AddTable(gc, new string[] { "Member", "Distinguished name" }, groupMembers);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        #endregion Active Directory information

        #region CRM information

        private void BuildUsersInformation(HtmlGenericControl main)
        {
            if (this.settings.UseCrmDataUsers)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "Users");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, "SELECT DataBaseName, UniqueName, ConnectionString FROM Organization");

                    foreach (DataRow row in data.Rows)
                    {
                        if (this.settings.Organizations.Contains(row["UniqueName"].ToString()))
                        {
                            this.rcb.AddTabHeader(gc, "Organization: " + row["DataBaseName"].ToString());

                            DataTable orgData = DatabaseHelper.ExecuteQuery(row["ConnectionString"].ToString(),
                                @"SELECT 
                            fullname as 'Full name', 
                            domainname as 'Domain name', 
                            statecodename as 'State',
                            internalemailaddress as 'Internal Email address', 
                            incomingemaildeliverymethodname as 'Incoming Delivery Method',
                            incomingemailfilteringmethodname as 'Incoming Filterfing Method', 
                            outgoingemaildeliverymethodname as 'Outgoing Delivery Method'   
                            FROM FilteredSystemUser, FilteredUserSettings 
                            WHERE FilteredSystemUser.systemuserid = FilteredUserSettings.systemuserid AND fullname not in ('SYSTEM','INTEGRATION')");

                            this.rcb.AddTable(gc, orgData);
                        }
                    }
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildPluginsInformation(HtmlGenericControl main)
        {
            if (this.settings.UseCrmDataPlugins)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "Custom plugins");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, "SELECT DataBaseName, UniqueName, ConnectionString FROM Organization");

                    foreach (DataRow row in data.Rows)
                    {
                        if (this.settings.Organizations.Contains(row["UniqueName"].ToString()))
                        {
                            this.rcb.AddTabHeader(gc, "Organization: " + row["DataBaseName"].ToString());

                            DataTable orgData = DatabaseHelper.ExecuteQuery(row["ConnectionString"].ToString(),
                                @"select
                        pt.assemblyname as 'Assembly',
                        pa.sourcetypename as 'Source type',
                        pt.typename as 'Type',
                        pt.isworkflowactivityname as 'Is workflow activity',
                        pt.version as 'Version',
                        mps.modename as 'Mode',
                        mps.stage as 'Stage',
                        mps.sdkmessageidname as 'SDK message',
                        mf.primaryobjecttypecode as 'Primary Object Type Code',
                        mps.name as 'Step',
                        mps.supporteddeploymentname as 'Supported deployment'
                        from 
                        FilteredPluginAssembly pa,
                        FilteredPluginType pt,
                        FilteredSdkMessageProcessingStep mps,
                        FilteredSdkMessageFilter mf

                        where
                        pa.pluginassemblyid = pt.pluginassemblyid
                        AND pt.plugintypeid = mps.plugintypeid 
                        AND mps.sdkmessagefilterid = mf.sdkmessagefilterid
                        AND pa.customizationlevel = 1
                        AND pt.customizationlevel = 1
                        AND mps.customizationlevel = 1

                        ORDER BY pt.assemblyname, pa.name, mps.invocationsourcename, mps.sdkmessageidname, mps.stagename, mps.modename
                        ");

                            this.rcb.AddTable(gc, orgData);
                        }
                    }
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        #endregion CRM information

        #region SQL information

        private void BuildSqlInformation(HtmlGenericControl main)
        {
            if (this.settings.UseSqlSqlServerInformation)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "SQL Server General Information");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, @"SELECT 
                                                                                @@SERVERNAME as 'Server name', 
                                                                                @@LANGUAGE as 'Language',
                                                                                SERVERPROPERTY(N'Collation') as 'Collation',
                                                                                @@VERSION as 'Version',
                                                                                SERVERPROPERTY('IsClustered') as 'Is clustered'");
                    this.rcb.AddTable(gc, data);

                    data = DatabaseHelper.ExecuteQuery(configConnectionString, "SELECT DataBaseName, ConnectionString FROM Organization");

                    foreach (DataRow row in data.Rows)
                    {
                        this.rcb.AddTabHeader(gc, "Organization: " + row["DataBaseName"].ToString());

                        DataTable orgData = DatabaseHelper.ExecuteQuery(row["ConnectionString"].ToString(),
                            string.Format(@"SELECT 
                                DATABASEPROPERTYEX('{0}', 'Collation') as 'Collation',
                                DATABASEPROPERTYEX('{0}', 'IsFulltextEnabled') as 'Full Text enabled',
                                DATABASEPROPERTYEX('{0}', 'Recovery') as 'Recovery mode'", row["DataBaseName"].ToString()));

                        this.rcb.AddTable(gc, orgData);
                    }
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildDeploymentPropertiesInformation(HtmlGenericControl main)
        {
            if (this.settings.UseSqlDeploymentProp)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "SQL DeploymentProperties table");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");

                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, @"SELECT * FROM DeploymentProperties");

                    DataTable updatedTable = new DataTable();
                    updatedTable.Columns.Add("Key");
                    updatedTable.Columns.Add("Value");

                    foreach (DataRow row in data.Rows)
                    {
                        DataRow updatedRow = updatedTable.NewRow();

                        foreach (DataColumn column in data.Columns)
                        {
                            if (column.ColumnName == "ColumnName")
                                updatedRow["Key"] = row["ColumnName"].ToString();
                            else if (column.ColumnName != "Id" && column.ColumnName != "Encrypted" && row[column.ColumnName] != DBNull.Value)
                                updatedRow["Value"] = row[column.ColumnName].ToString();
                        }

                        updatedTable.Rows.Add(updatedRow);
                    }

                    this.rcb.AddTable(gc, updatedTable);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildConfigPropertiesInformation(HtmlGenericControl main)
        {
            if (this.settings.UseSqlConfigSettings)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "SQL ConfigSettings table");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, @"SELECT * FROM ConfigSettings");

                    this.rcb.AddTransposedTableRow(gc, data.Rows[0]);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildBuildVersionInformation(HtmlGenericControl main)
        {
            if (this.settings.UseSqlBuildVersion)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "SQL BuildVersion table");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, "SELECT DataBaseName, UniqueName, ConnectionString FROM Organization");

                    foreach (DataRow row in data.Rows)
                    {
                        if (this.settings.Organizations.Contains(row["UniqueName"].ToString()))
                        {
                            this.rcb.AddTabHeader(gc, "Organization: " + row["DataBaseName"].ToString());

                            DataTable orgData = DatabaseHelper.ExecuteQuery(row["ConnectionString"].ToString(), @"SELECT BuildDate, BuildNumber, BuildQFE, MajorVersion, MinorVersion, Revision, LastDatabaseQfe FROM BuildVersion");
                            this.rcb.AddTable(gc, orgData);
                        }
                    }
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildServerInformation(HtmlGenericControl main)
        {
            if (this.settings.UseSqlServer)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "SQL Server table");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, @"SELECT * FROM Server");

                    data.Columns.Add("StringedRoles");

                    foreach (DataRow row in data.Rows)
                    {
                        row["StringedRoles"] = string.Join("\r\n", ServerRoleHelper.GetRoles((int)row["Roles"]));
                    }
                    data.Columns.Remove("Roles");
                    this.rcb.AddTable(gc, data);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        private void BuildOrganizationInformation(HtmlGenericControl main)
        {
            if (this.settings.UseSqlOrganization)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "SQL Organization table");

                try
                {
                    string configConnectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                    DataTable data = DatabaseHelper.ExecuteQuery(configConnectionString, @"SELECT * FROM Organization");

                    foreach (DataRow row in data.Rows)
                    {
                        this.rcb.AddTabHeader(gc, "Organization: " + row["DatabaseName"].ToString());

                        this.rcb.AddTransposedTableRow(gc, row);
                    }
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        #endregion SQL information

        #region IIS information

        internal void BuildIisInformation(HtmlGenericControl main)
        {
            if (this.settings.UseIisBindings)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "IIS Information");

                try
                {
                    foreach (string name in IisHelper.GetSitesNames())
                    {
                        this.rcb.AddTabHeader(gc, "Web site: " + name);

                        this.rcb.AddSectionHeader(gc, "General information");

                        Dictionary<string, string> values = IisHelper.GetSiteInfo(name);
                        this.rcb.AddTable(gc, new string[] { "Key", "Value" }, values);

                        this.rcb.AddSectionHeader(gc, "Bindings information");

                        this.rcb.AddTable(gc, IisHelper.GetSiteBindings(name));
                    }
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        internal void BuildApplicationPoolsInformation(HtmlGenericControl main)
        {
            if (this.settings.UseIisAppPools)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "IIS Application Pools Information");

                try
                {
                    this.rcb.AddTable(gc, IisHelper.GetApplicationPools());
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        #endregion IIS information

        #region CRM items information

        internal void BuildCrmServicesInformation(HtmlGenericControl main)
        {
            if (this.settings.UseCrmServices)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "CRM Services");

                try
                {
                    string[] services = new string[] { "MSCRMAsyncService", 
                "MSCRMAsyncService$Maintenance", 
                "MSCRMSandBoxService", 
                "MSCRMUnzipService", 
                "MSCRMEmail" };

                    DataTable table = new DataTable();
                    table.Columns.Add("Name");
                    table.Columns.Add("Identity");
                    table.Columns.Add("Status");

                    foreach (string serviceName in services)
                    {
                        Dictionary<string, string> values = RegistryHelper.GetAllKeys(@"System\CurrentControlSet\Services\" + serviceName);

                        if (values.Keys.Count > 0)
                        {
                            DataRow row = table.NewRow();
                            row["Name"] = values["DisplayName"];
                            row["Identity"] = values["ObjectName"];
                            row["Status"] = ServiceHelper.GetServiceStatus(serviceName);

                            table.Rows.Add(row);
                        }
                    }

                    this.rcb.AddTable(gc, table);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        internal void BuildCrmRegistryKeysInformation(HtmlGenericControl main)
        {
            if (this.settings.UseCrmRegistryKeys)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "CRM Registry keys");

                try
                {
                    Dictionary<string, string> values = RegistryHelper.GetAllKeysWithPath(@"Software\Microsoft\MSCRM");

                    this.rcb.AddTable(gc, new string[] { "Path", "Value" }, values);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        internal void BuildCrmFilesInformation(HtmlGenericControl main)
        {
            if (this.settings.UseCrmInstalledFiles)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "CRM Files");

                try
                {
                    this.rcb.AddTable(gc, FileSystemHelper.GetDirectoryInformation(
                    RegistryHelper.EvaluateString("CRM_Server_InstallDir", @"Software\Microsoft\MSCRM"),
                    null,
                    true));
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        internal void BuildCrmLanguagePacksInformation(HtmlGenericControl main)
        {
            if (this.settings.UseCrmLanguagePacks)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "CRM Language packs (only for local server)");

                try
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("Language Code");
                    table.Columns.Add("Version");

                    foreach (string languageCode in RegistryHelper.GetSubKeyNames(@"Software\Microsoft\MSCRM\LangPacks"))
                    {
                        DataRow row = table.NewRow();
                        row["Language Code"] = languageCode;
                        row["Version"] = RegistryHelper.EvaluateString("CRM_LangPack_Version", @"Software\Microsoft\MSCRM\LangPacks\" + languageCode);

                        table.Rows.Add(row);
                    }
                   
                    // Adds a table with retrieved data
                    this.rcb.AddTable(gc, table);
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.ToString());
                }
            }
        }

        private void BuildCrmGacFilesInformation(HtmlGenericControl main)
        {
            if (this.settings.UseCrmGacFiles)
            {
                // Adds header
                HtmlGenericControl gc = this.rcb.AddHeader(main, "CRM GAC Files");

                try
                {
                    try
                    {
                        string windowsDirectory = new DirectoryInfo(Environment.SystemDirectory).Parent.FullName;
                        DirectoryInfo gacFilePath = new DirectoryInfo(Path.Combine(windowsDirectory, "assembly"));

                        this.rcb.AddTable(gc, FileSystemHelper.GetDirectoryInformation(
                        gacFilePath.FullName,
                        null,
                        true,
                        "Microsoft.Crm",
                        false));
                    }
                    catch (Exception error)
                    {
                        this.rcb.AddSingleLineOfText(gc, error.Message);
                    }
                }
                catch (Exception error)
                {
                    this.rcb.AddSingleLineOfText(gc, error.Message);
                }
            }
        }

        #endregion CRM items information

        #endregion Methods
    }
}
