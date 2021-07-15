using System;
using System.IO;
using System.Xml;
using CrmDiagTool2011.Helpers;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// This class helps to manage the DevErrors flag of Microsoft Dynamics CRM
    /// 2011 web application
    /// </summary>
    internal class DevelopmentErrors
    {
        #region Variables

        /// <summary>
        /// Target server name
        /// <remarks>
        /// Empty if local server is used
        /// </remarks>
        /// </summary>
        string innerServerName;

        /// <summary>
        /// Flag that indicates if the server to update is a remote server
        /// </summary>
        bool innerIsRemote;

        /// <summary>
        /// Web.Config document data
        /// </summary>
        XmlDocument webConfigDocument;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class DevelopmentErrors
        /// </summary>
        /// <param name="serverName">Name of the target server</param>
        /// <param name="isRemote">Flag that indicates if the server is a remote server</param>
        public DevelopmentErrors(string serverName, bool isRemote)
        {
            this.innerServerName = serverName;
            this.innerIsRemote = isRemote;

            RegistryHelper.RemoteServerName = serverName;
            RegistryHelper.UseRemoteServer = isRemote;

            this.LoadWebConfigDocument();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets the DevErrors flag status
        /// </summary>
        /// <returns>Indicates if DevErrors flag is "On"</returns>
        internal bool GetStatus()
        {
            return this.GetDevErrorsNode().Attributes["value"].Value == "On";
        }

        /// <summary>
        /// Sets the DevErrors flag status
        /// </summary>
        /// <param name="isActive">Indicates if DevErrors flag is "On"</param>
        internal void SetStatus(bool isActive)
        {
            this.GetDevErrorsNode().Attributes["value"].Value = isActive ? "On" : "Off";

            this.webConfigDocument.Save(this.GetWebConfigDirectoryPath() + @"\Web.Config");
        }

        /// <summary>
        /// Gets the XmlNode representation of DevErrors flag
        /// </summary>
        /// <returns>DevErrors Xml node</returns>
        private XmlNode GetDevErrorsNode()
        {
            XmlNode devErrorsNode = this.webConfigDocument.SelectSingleNode("//add[@key='DevErrors']");

            if (devErrorsNode == null || devErrorsNode.Attributes["value"] == null)
                throw new Exception("Invalid web.config! It does not contain DevErrors flag");

            return devErrorsNode;
        }

        /// <summary>
        /// Loads the web.config file for the target server
        /// </summary>
        private void LoadWebConfigDocument()
        {
            string webSitePath = this.GetWebConfigDirectoryPath();

            if (!Directory.Exists(webSitePath))
                throw new Exception("Can't find CRM web site path: " + webSitePath);

            this.webConfigDocument = new XmlDocument();
            webConfigDocument.Load(webSitePath + @"\Web.Config");
        }

        /// <summary>
        /// Gets the local or network path for the web.config directory
        /// </summary>
        /// <returns></returns>
        private string GetWebConfigDirectoryPath()
        {
            string webSitePath = RegistryHelper.EvaluateString("WebSitePath", @"Software\Microsoft\MSCRM");

            if (RegistryHelper.UseRemoteServer && !string.IsNullOrEmpty(RegistryHelper.RemoteServerName))
            {
                string[] locationPart = webSitePath.Split(':');

                webSitePath = string.Format(@"\\{0}\{1}$\{2}",
                    RegistryHelper.RemoteServerName,
                    locationPart[0],
                    locationPart[1]);
            }

            return webSitePath;
        }

        #endregion Methods
    }
}
