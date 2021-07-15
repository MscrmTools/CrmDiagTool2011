using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrmDiagTool2011
{
    public partial class TraceRenameDialog : Form
    {
        string newName;

        public TraceRenameDialog(string existingName)
        {
            InitializeComponent();

            this.txt_newName.Text = existingName;
        }

        public string NewName { get { return this.newName; } }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            this.newName = this.txt_newName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
