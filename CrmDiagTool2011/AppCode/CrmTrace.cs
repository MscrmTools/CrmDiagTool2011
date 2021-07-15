using System;
using CrmDiagTool2011.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// This class represents an object that can deal with trace settings
    /// </summary>
    internal class CrmTrace
    {
        #region Constants

        /// <summary>
        /// Path to CRM registrey keys
        /// </summary>
        const string CRM_REGISTRY_PATH = @"Software\Microsoft\MSCRM";

        #endregion Constants

        #region Variables

        CrmTraceProfiles profiles;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class CrmTrace
        /// </summary>
        public CrmTrace()
        {
            try
            {
                this.LoadProfiles();
                this.CurrentProfile = new CrmTraceProfile();

                // Retrieve current registry keys for trace
                this.TraceEnabled = RegistryHelper.EvaluateOption("TraceEnabled", CRM_REGISTRY_PATH);
                this.CurrentProfile.TraceCallStack = RegistryHelper.EvaluateOption("TraceCallStack", CRM_REGISTRY_PATH);
                this.CurrentProfile.TraceDirectory = RegistryHelper.EvaluateString("TraceDirectory", CRM_REGISTRY_PATH);
                this.CurrentProfile.TraceFileSizeLimit = RegistryHelper.EvaluateInteger("TraceFileSizeLimit", CRM_REGISTRY_PATH);
                this.CurrentProfile.TraceCategories = RegistryHelper.EvaluateString("TraceCategories", CRM_REGISTRY_PATH);

                string installPath = RegistryHelper.EvaluateString("CRM_Server_InstallDir", CRM_REGISTRY_PATH);

                // Setting file size default value
                if (this.CurrentProfile.TraceFileSizeLimit == 0)
                    this.CurrentProfile.TraceFileSizeLimit = 10;

                // Setting trace directory default value
                if (string.IsNullOrEmpty(this.CurrentProfile.TraceDirectory))
                    this.CurrentProfile.TraceDirectory = string.Format("{0}\\Trace", installPath);

                // Setting trace categories default value
                if (string.IsNullOrEmpty(this.CurrentProfile.TraceCategories))
                    this.CurrentProfile.TraceCategories = "*:Verbose";
            }
            catch (Exception error)
            {
                throw new Exception("An error occured when retrieving trace settings: " + error.Message);
            }
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// If you use a value of 0, tracing is disabled. If you use a value of
        /// 1, tracing is enabled.
        /// </summary>
        public bool TraceEnabled { get; set; }

        public CrmTraceProfile CurrentProfile { get; set; }

        public CrmTraceProfiles Profiles { get{return profiles;} }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Apply current instance properties to trace registry keys
        /// </summary>
        public void ApplyChanges()
        {
            int traceRefresh = RegistryHelper.EvaluateInteger("TraceRefresh", CRM_REGISTRY_PATH);

            if(traceRefresh < 100)
                traceRefresh += 1;
            else
                traceRefresh = 1;

            RegistryHelper.SetString(CRM_REGISTRY_PATH, "TraceCategories", this.CurrentProfile.TraceCategories);
            RegistryHelper.SetString(CRM_REGISTRY_PATH, "TraceDirectory", this.CurrentProfile.TraceDirectory);
            RegistryHelper.SetOption(CRM_REGISTRY_PATH, "TraceCallStack", this.CurrentProfile.TraceCallStack);
            RegistryHelper.SetOption(CRM_REGISTRY_PATH, "TraceEnabled", this.TraceEnabled);
            RegistryHelper.SetInteger(CRM_REGISTRY_PATH, "TraceFileSizeLimit", this.CurrentProfile.TraceFileSizeLimit);
            RegistryHelper.SetInteger(CRM_REGISTRY_PATH, "TraceRefresh", traceRefresh);
        }

        internal CrmTraceProfiles LoadProfiles()
        {
            if (File.Exists("CrmDiagTool2011.TraceProfiles.config"))
            {
                using (StreamReader configReader = new StreamReader("CrmDiagTool2011.TraceProfiles.config"))
                {
                    this.profiles = (CrmTraceProfiles)XmlSerializerHelper.Deserialize(configReader.ReadToEnd(), typeof(CrmTraceProfiles));
                }
            }
            else
            {
                this.profiles = new CrmTraceProfiles()
                {
                    Profiles = new List<CrmTraceProfile>()
                };
            }

            return this.profiles;
        }

        internal void SaveProfiles()
        {
            try
            {
                XmlSerializerHelper.SerializeToFile(this.Profiles, "CrmDiagTool2011.TraceProfiles.config");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error while saving profiles to disk: " + error.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        internal static string GetTraceFolderPath()
        {
            string tracePath = RegistryHelper.EvaluateString("TraceDirectory", CRM_REGISTRY_PATH);

            if (tracePath == null)
            {
                string installPath = RegistryHelper.EvaluateString("CRM_Server_InstallDir", CRM_REGISTRY_PATH);

                tracePath = Path.Combine(installPath, "Trace");
            }

            if (RegistryHelper.UseRemoteServer && !string.IsNullOrEmpty(RegistryHelper.RemoteServerName))
            {
                string[] locationPart = tracePath.Split(':');

                tracePath = string.Format(@"\\{0}\{1}$\{2}",
                    RegistryHelper.RemoteServerName,
                    locationPart[0],
                    locationPart[1]);
            }

            return tracePath;
        }

        #endregion Methods
    }
}
