using System.Collections.Generic;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// This class stores flags to indicate which information should be added
    /// in the report file
    /// </summary>
    /// <remarks>
    /// When including new information in the report file, add also a public 
    /// property to this class that should correspond to a node in the parameters
    /// treeview
    /// </remarks>
    class FileInfoSettings
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of class FileInfoSettings
        /// </summary>
        public FileInfoSettings()
        {
            this.ProgressBarMaxStep = 0;
        }

        #endregion Constructor

        #region Properties
        
        public bool UseCrmLanguagePacks { get; set; }
        public bool UseCrmServices { get; set; }
        public bool UseCrmRegistryKeys { get; set; }
        public bool UseCrmInstalledFiles { get; set; }
        public bool UseGeneralFramework { get; set; }
        public bool UseGeneralIPConfig { get; set; }
        public bool UseGeneralSystemInfo { get; set; }
        public bool UseGeneralEnvVariables { get; set; }
        public bool UseGeneralTcpIp { get; set; }
        public bool UseGeneralBootIni { get; set; }
        public bool UseCrmGacFiles { get; set; }
        public bool UseADGroupMembership { get; set; }
        public bool UseCrmDataUsers { get; set; }
        public bool UseCrmDataPlugins { get; set; }
        public bool UseSqlBuildVersion { get; set; }
        public bool UseSqlOrganization { get; set; }
        public bool UseSqlServer { get; set; }
        public bool UseSqlConfigSettings { get; set; }
        public bool UseSqlDeploymentProp { get; set; }
        public bool UseSqlSqlServerInformation { get; set; }
        public bool UseIisAppPools { get; set; }
        public bool UseIisBindings { get; set; }
        
        /// <summary>
        /// Gets or sets the maximum step for the progress bar
        /// (number of checked nodes in parameter treeview)
        /// </summary>
        public int ProgressBarMaxStep {get;set;}

        /// <summary>
        /// Gets or sets the list of organization that should be included in
        /// the report file
        /// </summary>
        public List<string> Organizations { get; set; }

        #endregion Properties
    }
}
