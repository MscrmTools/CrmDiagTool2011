using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CrmDiagTool2011.AppCode;
using CrmDiagTool2011.Helpers;

namespace CrmDiagTool2011
{
    public partial class MainForm : Form
    {
        Assembly currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();

        private void CheckRemoteStatus()
        {
            this.tabControl1.Enabled = false;
            
            try
            {
                this.btn_trace_status.Text = "Unknown status";
                this.btn_devErrors_status.Text = "Unknown status";

                this.txtRemoteServerName.Enabled = this.rbRemoteServer.Checked;
                this.btnConnect.Enabled = this.rbRemoteServer.Checked;
                this.pnlTroubleshooting.Enabled = this.rbLocalServer.Checked;
                this.pnlDevErrors.Enabled = false;
                this.pnlTrace.Enabled = false;

                this.btn_trace_browse.Enabled = this.rbLocalServer.Checked;
                //this.btn_trace_opendirectory.Enabled = this.rbLocalServer.Checked;
                //this.btn_trace_zipfiles.Enabled = this.rbLocalServer.Checked;
                //this.btn_trace_cleandirectory.Enabled = this.rbLocalServer.Checked;

                this.btn_trace_status.Enabled = this.rbLocalServer.Checked || !String.IsNullOrEmpty(this.txtRemoteServerName.Text);

                if (rbLocalServer.Checked)
                {
                    RegistryHelper.UseRemoteServer = false;
                    RegistryHelper.RemoteServerName = null;
                }
                else
                {
                    RegistryHelper.UseRemoteServer = true;
                    RegistryHelper.RemoteServerName = txtRemoteServerName.Text;
                }

                this.FillTraceControls();
                this.FillDevErrorsControls();
                this.LoadTroubleshootingFilePart();
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "An error occured: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tabControl1.Enabled = true;
            }
        }

        /// <summary>
        /// Fills controls related to Crm trace
        /// </summary>
        private void FillTraceControls(CrmTraceProfile profile = null)
        {
            if (rbRemoteServer.Checked && String.IsNullOrEmpty(txtRemoteServerName.Text))
                return;

            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.btn_trace_save, "Saves the current displayed settings in the selected trace profile.\r\nIf the current selected trace profile is the server one, settings will be saved in the registry");
            tt.SetToolTip(this.btn_trace_saveAs, "Saves the current displayed settings in a new trace profile");
            tt.SetToolTip(this.btn_trace_delete, "Deletes the current selected trace profile and loads current server trace profile.");

            this.trace = new CrmTrace();

            if (profile == null)
            {
                this.LoadProfiles();
                profile = this.trace.CurrentProfile;
            }

            this.cbb_trace_profiles.SelectedItem = profile;

            this.cb_trace_callstack.Checked = profile.TraceCallStack;
            this.nud_trace_maxfilesize.Value = profile.TraceFileSizeLimit;
            this.txt_trace_tracedirectory.Text = profile.TraceDirectory;

            string[] categories = profile.TraceCategories.Split(';');
            string[] firstCategoryParts = categories[0].Split(':');

            this.cbb_level_trace.SelectedItem = firstCategoryParts[1];

            if (firstCategoryParts[0] == "*")
            {
                this.chk_trace_allCategories.Checked = true;
            }

            for (int i = 0; i < this.clb_trace_categories.Items.Count; i++)
            {
                string value = this.clb_trace_categories.Items[i].ToString().Trim() + ".*:" + this.cbb_level_trace.SelectedItem.ToString();

                this.clb_trace_categories.SetItemChecked(i, profile.TraceCategories.IndexOf(value) >= 0 ||
                    firstCategoryParts[0] == "*");
            }

            if (this.trace.TraceEnabled)
            {
                this.btn_trace_status.Text = "Disable trace";

                using (Stream myStream = currentAssembly.GetManifestResourceStream("CrmDiagTool2011.Images.bullet_green.png"))
                {
                    this.btn_trace_status.Image = new Bitmap(myStream);
                }

                this.gb_trace_parameters.Enabled = false;
                this.btn_trace_cleandirectory.Enabled = false;
                this.btn_trace_zipfiles.Enabled = false;
            }
            else
            {
                this.btn_trace_status.Text = "Enable trace";

                using (Stream myStream = currentAssembly.GetManifestResourceStream("CrmDiagTool2011.Images.bullet_red.png"))
                {
                    this.btn_trace_status.Image = new Bitmap(myStream);
                }
            }

            this.pnlTrace.Enabled = true;
        }

        private void LoadProfiles(CrmTraceProfile profile = null)
        {
            this.trace.LoadProfiles();
            this.cbb_trace_profiles.Items.Clear();

            this.trace.CurrentProfile.Name = "--> Current Server Settings <--";
            this.cbb_trace_profiles.Items.Add(this.trace.CurrentProfile);

            foreach (CrmTraceProfile profileItem in this.trace.Profiles.Profiles)
            {
                this.cbb_trace_profiles.Items.Add(profileItem);

                if (profile != null && profile.Name == profileItem.Name)
                {
                    this.cbb_trace_profiles.SelectedItem = profileItem;
                }
            }
        }

        /// <summary>
        /// Fills controls related to Dev errors
        /// </summary>
        private void FillDevErrorsControls()
        {
            if (rbRemoteServer.Checked && String.IsNullOrEmpty(txtRemoteServerName.Text))
                return;

            DevelopmentErrors de = new DevelopmentErrors(this.txtRemoteServerName.Text, this.rbRemoteServer.Checked);

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

            this.pnlDevErrors.Enabled = true;
        }

        /// <summary>
        /// Fills controls related to Report file
        /// </summary>
        private void LoadTroubleshootingFilePart()
        {
            if (rbRemoteServer.Checked)
                return;
            try
            {
                this.tv_file_settings.ExpandAll();

                string connectionString = RegistryHelper.EvaluateString("configdb", @"Software\Microsoft\MSCRM");
                DataTable table = DatabaseHelper.ExecuteQuery(connectionString, "SELECT FriendlyName, UniqueName FROM Organization");

                foreach (DataRow row in table.Rows)
                {
                    ListViewItem item = new ListViewItem(row["FriendlyName"].ToString());
                    item.SubItems.Add(row["UniqueName"].ToString());
                    item.Checked = true;

                    this.lv_file_organizations.Items.Add(item);
                }
            }
            catch (Exception error)
            {
                throw new Exception("An error occured while loading organizations list: " + error.Message, error);
            }
        }
    }
}
