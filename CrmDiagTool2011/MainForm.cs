using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using CrmDiagTool2011.AppCode;
using CrmDiagTool2011.Helpers;

namespace CrmDiagTool2011
{
    public partial class MainForm : Form
    {
        #region Variables

        /// <summary>
        /// Trace object
        /// </summary>
        CrmTrace trace;

        /// <summary>
        /// Report Manager
        /// </summary>
        ReportManager rManager;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class MainForm
        /// </summary>
        public MainForm()
        {
            try
            {
                InitializeComponent();

                this.Text += " (v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";

                if (!RegistryHelper.KeyExists(@"Software\Microsoft\MSCRM")
                    || RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM") == null)
                {
                    rbLocalServer.Enabled = false;
                    rbRemoteServer.Checked = true;
                }

                this.CheckRemoteStatus();
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "An error occured while initializing this application: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Constructor

        #region Trace Methods

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.CheckRemoteStatus();
        }


        private void rbLocalServer_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckRemoteStatus();
        }

        private void txtRemoteServerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CheckRemoteStatus();
                e.Handled = true;
            }
        }


        private void btn_trace_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDialog = new FolderBrowserDialog()
            {
                Description = "Select a directory where to store trace files",
                ShowNewFolderButton = true,
                SelectedPath = this.txt_trace_tracedirectory.Text
            };

            if (fbDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txt_trace_tracedirectory.Text = fbDialog.SelectedPath;
            }
        }

        private void btn_trace_status_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btn_trace_status.Text == "Enable trace")
                {
                    // Saves settings
                    this.trace.TraceEnabled = true;
                    this.trace.CurrentProfile.TraceCallStack = this.cb_trace_callstack.Checked;
                    this.trace.CurrentProfile.TraceDirectory = this.txt_trace_tracedirectory.Text;
                    this.trace.CurrentProfile.TraceFileSizeLimit = Convert.ToInt32(this.nud_trace_maxfilesize.Value);

                    if (this.chk_trace_allCategories.Checked)
                    {
                        this.trace.CurrentProfile.TraceCategories = "*:" + this.cbb_level_trace.SelectedItem.ToString();
                    }
                    else
                    {
                        List<string> categories = new List<string>();

                        foreach (string itemText in this.clb_trace_categories.CheckedItems)
                        {
                            categories.Add(itemText.Trim() + ".*:" + this.cbb_level_trace.SelectedItem.ToString());
                        }

                        this.trace.CurrentProfile.TraceCategories = string.Join(";", categories);
                    }

                    // Saves settings
                    this.trace.ApplyChanges();

                    // Updates button label and icon
                    this.btn_trace_status.Text = "Disable trace";
                    using (Stream myStream = currentAssembly.GetManifestResourceStream("CrmDiagTool2011.Images.bullet_green.png"))
                    {
                        this.btn_trace_status.Image = new Bitmap(myStream);
                    }

                    // Disables other groupboxes
                    this.gb_trace_parameters.Enabled = false;
                    this.btn_trace_cleandirectory.Enabled = false;
                    this.btn_trace_zipfiles.Enabled = false;
                }
                else
                {
                    // Stops trace
                    this.trace.TraceEnabled = false;

                    // Saves settings
                    this.trace.ApplyChanges();

                    // Updates button label and icon
                    this.btn_trace_status.Text = "Enable trace";
                    using (Stream myStream = currentAssembly.GetManifestResourceStream("CrmDiagTool2011.Images.bullet_red.png"))
                    {
                        this.btn_trace_status.Image = new Bitmap(myStream);
                    }

                    // Enables other groupboxes
                    this.gb_trace_parameters.Enabled = true;
                    this.btn_trace_cleandirectory.Enabled = true;
                    this.btn_trace_zipfiles.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "An error occured while setting the trace on: " + error.Message + "\r\nTry to restart this application with elevated privileges", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_trace_zipfiles_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Archive file (*.zip)| *.zip",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ZipManager zManager = new ZipManager();
                    zManager.CompressFolder(CrmTrace.GetTraceFolderPath(), saveFileDialog.FileName);

                    MessageBox.Show(this, "Zip file created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show(this,
                        "Error while creating zip file: " + error.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btn_trace_opendirectory_Click(object sender, EventArgs e)
        {
            try
            {
                // Opens explorer.exe to the trace directory
                Process prc = new Process();
                prc.StartInfo.FileName = CrmTrace.GetTraceFolderPath();
                prc.Start();
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "Error while opening trace directory: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_trace_cleandirectory_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> filesNotDeleted = new List<string>();

                // Retrieving files in the specified trace directory
                DirectoryInfo di = new DirectoryInfo(CrmTrace.GetTraceFolderPath());
                foreach (FileInfo fi in di.GetFiles())
                {
                    try
                    {
                        File.Delete(fi.FullName);
                    }
                    catch
                    {
                        filesNotDeleted.Add(fi.Name);
                    }
                }

                // Displaying files not deleted because they are still in use
                // by some Crm service
                if (filesNotDeleted.Count > 0)
                {
                    string message = "Some files were not deleted:\r\n" + string.Join("\r\n", filesNotDeleted);
                    MessageBox.Show(this, message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(this, "Trace directory cleaned!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "Error while cleaning trace directory: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chk_trace_allCategories_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.clb_trace_categories.Items.Count; i++)
            {
                this.clb_trace_categories.SetItemChecked(i, this.chk_trace_allCategories.Checked);
            }
        }

        private void clb_trace_categories_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if (e.NewValue == CheckState.Checked)
            //{
            //    if (this.clb_trace_categories.CheckedItems.Count ==
            //        this.clb_trace_categories.Items.Count - 1)
            //    {
            //        this.chk_trace_allCategories.Checked = true;
            //    }
            //}
            //else
            //{
            //    if (this.clb_trace_categories.CheckedItems.Count ==
            //         this.clb_trace_categories.Items.Count)
            //    {
            //        this.chk_trace_allCategories.Checked = false;
            //    }
            //}
        }

        private void btn_trace_save_Click(object sender, EventArgs e)
        {
            CrmTraceProfile profile = this.trace.Profiles.Profiles.Find(x => x.Name == this.cbb_trace_profiles.SelectedItem.ToString());

            if (profile == null)
            {
                if (this.cbb_trace_profiles.SelectedItem.ToString() == "--> Current Server Settings <--")
                {
                    if (MessageBox.Show(this, "Are you sure you want to save these settings in the registry?", "Question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    profile = this.trace.CurrentProfile;
                }
                else
                {
                    profile = new CrmTraceProfile();

                    TraceRenameDialog trd = new TraceRenameDialog(profile.Name);

                    if (trd.ShowDialog() == DialogResult.OK)
                    {
                        profile.Name = trd.NewName;
                    }
                    else
                    {
                        return;
                    }

                    this.trace.Profiles.Profiles.Add(profile);
                }
            }

            profile.TraceCallStack = this.cb_trace_callstack.Checked;
            profile.TraceDirectory = this.txt_trace_tracedirectory.Text;
            profile.TraceFileSizeLimit = Convert.ToInt32(this.nud_trace_maxfilesize.Value);

            if (this.chk_trace_allCategories.Checked)
            {
                profile.TraceCategories = "*:" + this.cbb_level_trace.SelectedItem.ToString();
            }
            else
            {
                List<string> categories = new List<string>();

                foreach (string itemText in this.clb_trace_categories.CheckedItems)
                {
                    categories.Add(itemText.Trim() + ".*:" + this.cbb_level_trace.SelectedItem.ToString());
                }

                profile.TraceCategories = string.Join(";", categories);
            }

            if (this.cbb_trace_profiles.SelectedItem.ToString() == "--> Current Server Settings <--")
            {
                this.trace.ApplyChanges();
            }
            else
            {
                this.trace.SaveProfiles();
            }
        }

        private void btn_trace_saveAs_Click(object sender, EventArgs e)
        {
            CrmTraceProfile currentProfile = this.trace.Profiles.Profiles.Find(x => x.Name == this.cbb_trace_profiles.SelectedItem.ToString());
            if (currentProfile == null)
                currentProfile = this.trace.CurrentProfile;

            TraceRenameDialog trd = new TraceRenameDialog(currentProfile.Name);
            trd.StartPosition = FormStartPosition.CenterParent;

            if (trd.ShowDialog() == DialogResult.OK)
            {
                if (this.trace.Profiles.Profiles.Find(x => x.Name == trd.NewName) != null)
                {
                    MessageBox.Show(this, "A Crm trace profile already exists with this name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CrmTraceProfile profile = new CrmTraceProfile();
                profile.Name = trd.NewName;
                profile.TraceCallStack = this.cb_trace_callstack.Checked;
                profile.TraceDirectory = this.txt_trace_tracedirectory.Text;
                profile.TraceFileSizeLimit = Convert.ToInt32(this.nud_trace_maxfilesize.Value);

                if (this.chk_trace_allCategories.Checked)
                {
                    profile.TraceCategories = "*:" + this.cbb_level_trace.SelectedItem.ToString();
                }
                else
                {
                    List<string> categories = new List<string>();

                    foreach (string itemText in this.clb_trace_categories.CheckedItems)
                    {
                        categories.Add(itemText.Trim() + ".*:" + this.cbb_level_trace.SelectedItem.ToString());
                    }

                    profile.TraceCategories = string.Join(";", categories);
                }

                this.trace.Profiles.Profiles.Add(profile);
                this.trace.SaveProfiles();
                this.LoadProfiles(profile);
            }
        }

        private void btn_trace_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to delete this profile?", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CrmTraceProfile profile = this.trace.Profiles.Profiles.Find(x => x.Name == this.cbb_trace_profiles.SelectedItem.ToString());
                this.trace.Profiles.Profiles.Remove(profile);
                this.trace.SaveProfiles();
                this.LoadProfiles();
                this.FillTraceControls(this.trace.CurrentProfile);
            }
        }

        private void cbb_trace_profiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrmTraceProfile profile = (CrmTraceProfile)this.cbb_trace_profiles.SelectedItem;

            FillTraceControls(profile);

            if (this.cbb_trace_profiles.SelectedItem.ToString() == "--> Current Server Settings <--")
            {
                this.btn_trace_delete.Enabled = false;
            }
            else
            {
                this.btn_trace_delete.Enabled = true;
            }
        }

        #endregion Trace Methods

        #region Development Errors Methods

        private void btn_devErrors_status_Click(object sender, EventArgs e)
        {
            try
            {
                DevelopmentErrors de = new DevelopmentErrors(this.txtRemoteServerName.Text, this.rbRemoteServer.Checked);

                if (this.btn_devErrors_status.Text == "Turn DevErrors Off")
                {
                    de.SetStatus(false);
                }
                else if (this.btn_devErrors_status.Text == "Turn DevErrors On")
                {
                    de.SetStatus(true);
                }

                // Refresh the current status to see if the change worked or not...
                if (de.GetStatus())
                {
                    using (Stream myStream = currentAssembly.GetManifestResourceStream("CrmDiagTool2011.Images.bullet_green.png"))
                    {
                        this.btn_devErrors_status.Image = new Bitmap(myStream);
                    }

                    this.btn_devErrors_status.Text = "Turn DevErrors Off";
                }
                else
                {
                    using (Stream myStream = currentAssembly.GetManifestResourceStream("CrmDiagTool2011.Images.bullet_red.png"))
                    {
                        this.btn_devErrors_status.Image = new Bitmap(myStream);
                    }

                    this.btn_devErrors_status.Text = "Turn DevErrors On";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(this,
                    "Error while updating devErrors settings: " + error.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion Development Errors Methods

        #region Report file Methods

        private void btn_file_generate_Click(object sender, EventArgs e)
        {
            try
            {
                // Stores list of organizations that should be included in the 
                // HTML report file
                List<string> organizations = new List<string>();

                foreach (ListViewItem item in this.lv_file_organizations.CheckedItems)
                    organizations.Add(item.SubItems[1].Text);

                // Stores report file settings
                FileInfoSettings settings = new FileInfoSettings()
                {
                    Organizations = organizations,
                    ProgressBarMaxStep = TreeviewHelper.CountCheckNodes(this.tv_file_settings),
                    UseADGroupMembership = this.tv_file_settings.Nodes.Find("tvnAdSecurityGroups", true)[0].Checked,
                    UseCrmDataPlugins = this.tv_file_settings.Nodes.Find("tvnCrmDataPlugins", true)[0].Checked,
                    UseCrmDataUsers = this.tv_file_settings.Nodes.Find("tvnCrmDataUsers", true)[0].Checked,
                    UseCrmInstalledFiles = this.tv_file_settings.Nodes.Find("tvnCrmInstalledFiles", true)[0].Checked,
                    UseCrmLanguagePacks = this.tv_file_settings.Nodes.Find("tvnCrmLanguagePacks", true)[0].Checked,
                    UseCrmRegistryKeys = this.tv_file_settings.Nodes.Find("tvnCrmRegistryKeys", true)[0].Checked,
                    UseCrmServices = this.tv_file_settings.Nodes.Find("tvnCrmWindowsServices", true)[0].Checked,
                    UseCrmGacFiles = this.tv_file_settings.Nodes.Find("tvnCrmGacFiles", true)[0].Checked,
                    UseGeneralBootIni = this.tv_file_settings.Nodes.Find("tvnServerBootIni", true)[0].Checked,
                    UseGeneralEnvVariables = this.tv_file_settings.Nodes.Find("tvnServerEnvironment", true)[0].Checked,
                    UseGeneralFramework = this.tv_file_settings.Nodes.Find("tvnServerFramework", true)[0].Checked,
                    UseGeneralIPConfig = this.tv_file_settings.Nodes.Find("tvnServerIp", true)[0].Checked,
                    UseGeneralSystemInfo = this.tv_file_settings.Nodes.Find("tvnServerSystem", true)[0].Checked,
                    UseGeneralTcpIp = this.tv_file_settings.Nodes.Find("tvnServerTcpIp", true)[0].Checked,
                    UseIisAppPools = this.tv_file_settings.Nodes.Find("tvnIisAppPools", true)[0].Checked,
                    UseIisBindings = this.tv_file_settings.Nodes.Find("tvnIisBindings", true)[0].Checked,
                    UseSqlBuildVersion = this.tv_file_settings.Nodes.Find("tvnSqlBuildVersion", true)[0].Checked,
                    UseSqlConfigSettings = this.tv_file_settings.Nodes.Find("tvnSqlConfigurationSettings", true)[0].Checked,
                    UseSqlDeploymentProp = this.tv_file_settings.Nodes.Find("tvnSqlDeploymentProperties", true)[0].Checked,
                    UseSqlOrganization = this.tv_file_settings.Nodes.Find("tvnSqlOrganization", true)[0].Checked,
                    UseSqlServer = this.tv_file_settings.Nodes.Find("tvnSqlServer", true)[0].Checked,
                    UseSqlSqlServerInformation = this.tv_file_settings.Nodes.Find("tvnSqlServer", true)[0].Checked
                };

                // Deactivate controls during file generation
                this.gb_file_organizations.Enabled = false;
                this.gb_file_settings.Enabled = false;
                this.btn_file_generate.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // Launches report generation
                BackgroundWorker worker = new BackgroundWorker();
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync(settings);
            }
            catch (Exception error)
            {
                MessageBox.Show(this,
                    "An error occured while initializing report generation: " + error.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #region Report Worker methods

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.rManager = new ReportManager((FileInfoSettings)e.Argument);
            e.Result = rManager.BuildReport((BackgroundWorker)sender);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > this.progressBar1.Maximum)
            {
                this.progressBar1.Value = this.progressBar1.Maximum;
            }
            else
            {
                this.progressBar1.Value = e.ProgressPercentage;
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gb_file_organizations.Enabled = true;
            this.gb_file_settings.Enabled = true;
            this.btn_file_generate.Enabled = true;
            this.Cursor = Cursors.Default;

            if (e.Error != null)
            {
                MessageBox.Show(this, "An error occured while generating the report: " + e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Result != null)
            {
                this.rManager.GenerateFinalReport((HtmlGenericControl)e.Result);
            }

            this.progressBar1.Value = 0;
        }

        #endregion Report Worker methods

        private void tv_file_settings_AfterCheck(object sender, TreeViewEventArgs e)
        {
            tv_file_settings.AfterCheck -= new TreeViewEventHandler(tv_file_settings_AfterCheck);

            TreeNode actionedNode = e.Node;

            for (int i = 0; i < actionedNode.Nodes.Count; i++)
            {
                actionedNode.Nodes[i].Checked = actionedNode.Checked;

                if (actionedNode.Nodes[i].Nodes != null)
                {
                    for (int j = 0; j < actionedNode.Nodes[i].Nodes.Count; j++)
                    {
                        actionedNode.Nodes[i].Nodes[j].Checked = actionedNode.Checked;
                    }
                }
            }

            TreeNode parentNode = actionedNode.Parent;

            if (parentNode != null && parentNode.Nodes != null)
            {
                parentNode.Checked = false;

                for (int i = 0; i < parentNode.Nodes.Count; i++)
                {
                    if (parentNode.Nodes[i].Checked)
                    {
                        parentNode.Checked = true;
                    }
                }
            }

            tv_file_settings.AfterCheck += new TreeViewEventHandler(tv_file_settings_AfterCheck);
        }

        #endregion Report file Methods

        #region Toolbar links

        private void tsbRate_Click(object sender, EventArgs e)
        {
            Process.Start("http://crmdiagtool2011.codeplex.com/releases");
        }

        private void tsbDiscuss_Click(object sender, EventArgs e)
        {
            Process.Start("http://crmdiagtool2011.codeplex.com/discussions");
        }

        private void tsbReportBug_Click(object sender, EventArgs e)
        {
            Process.Start("http://crmdiagtool2011.codeplex.com/WorkItem/Create");
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            AboutForm aForm = new AboutForm();
            aForm.StartPosition = FormStartPosition.CenterParent;
            aForm.ShowDialog();
        }

        #endregion Toolbar links
    }
}
