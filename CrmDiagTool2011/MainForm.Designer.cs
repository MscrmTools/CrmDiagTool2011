namespace CrmDiagTool2011
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General Information");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode(".Net Framework");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("IP Configuration");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Environment Variables");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("TCPIP Parameters Registry Keys");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Boot Configuration Data");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Server Information", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Security Groups");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Active Directory Information", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Bindings");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Application Pools");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("IIS Information", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Windows Services");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Registry Keys");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Installed Files");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Language Packs");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Logs and Trace Files");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("GAC Files");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("CRM Information", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Server Information");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("DeploymentProperties Table");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("ConfigurationSettings Table");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Server Table");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("BuildVersion Table");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Organization Table");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("SQL", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Users");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Plugins");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("CRM Data Information", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("All information", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode9,
            treeNode12,
            treeNode19,
            treeNode26,
            treeNode29});
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_platformTrace = new System.Windows.Forms.TabPage();
            this.pnlTrace = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_trace_actions = new System.Windows.Forms.GroupBox();
            this.btn_trace_cleandirectory = new System.Windows.Forms.Button();
            this.btn_trace_opendirectory = new System.Windows.Forms.Button();
            this.btn_trace_zipfiles = new System.Windows.Forms.Button();
            this.gb_trace_status = new System.Windows.Forms.GroupBox();
            this.btn_trace_status = new System.Windows.Forms.Button();
            this.gb_trace_parameters = new System.Windows.Forms.GroupBox();
            this.btn_trace_delete = new System.Windows.Forms.Button();
            this.btn_trace_saveAs = new System.Windows.Forms.Button();
            this.btn_trace_save = new System.Windows.Forms.Button();
            this.cbb_trace_profiles = new System.Windows.Forms.ComboBox();
            this.lbl_trace_profile = new System.Windows.Forms.Label();
            this.btn_trace_browse = new System.Windows.Forms.Button();
            this.chk_trace_allCategories = new System.Windows.Forms.CheckBox();
            this.lbl_trace_level = new System.Windows.Forms.Label();
            this.cbb_level_trace = new System.Windows.Forms.ComboBox();
            this.clb_trace_categories = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_trace_tracedirectory = new System.Windows.Forms.Label();
            this.txt_trace_tracedirectory = new System.Windows.Forms.TextBox();
            this.nud_trace_maxfilesize = new System.Windows.Forms.NumericUpDown();
            this.lbl_trace_maxfilesize = new System.Windows.Forms.Label();
            this.lbl_trace_callstack = new System.Windows.Forms.Label();
            this.cb_trace_callstack = new System.Windows.Forms.CheckBox();
            this.tp_devErrors = new System.Windows.Forms.TabPage();
            this.pnlDevErrors = new System.Windows.Forms.Panel();
            this.gb_devErrors = new System.Windows.Forms.GroupBox();
            this.btn_devErrors_status = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tp_troubleshootFile = new System.Windows.Forms.TabPage();
            this.pnlTroubleshooting = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gb_file_organizations = new System.Windows.Forms.GroupBox();
            this.lv_file_organizations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gb_file_settings = new System.Windows.Forms.GroupBox();
            this.tv_file_settings = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_file_generate = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbReportBug = new System.Windows.Forms.ToolStripButton();
            this.tsbDiscuss = new System.Windows.Forms.ToolStripButton();
            this.tsbRate = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtRemoteServerName = new System.Windows.Forms.TextBox();
            this.rbRemoteServer = new System.Windows.Forms.RadioButton();
            this.rbLocalServer = new System.Windows.Forms.RadioButton();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tp_platformTrace.SuspendLayout();
            this.pnlTrace.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_trace_actions.SuspendLayout();
            this.gb_trace_status.SuspendLayout();
            this.gb_trace_parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_trace_maxfilesize)).BeginInit();
            this.tp_devErrors.SuspendLayout();
            this.pnlDevErrors.SuspendLayout();
            this.gb_devErrors.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tp_troubleshootFile.SuspendLayout();
            this.pnlTroubleshooting.SuspendLayout();
            this.gb_file_organizations.SuspendLayout();
            this.gb_file_settings.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.lblDesc);
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(776, 60);
            this.panelHeader.TabIndex = 20;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(720, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 50);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(16, 35);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(315, 13);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "Enable trace and dev errors, generate a troubleshooting file";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(447, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Diagnostics Tool for Microsoft Dynamics CRM 2011";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tp_platformTrace);
            this.tabControl1.Controls.Add(this.tp_devErrors);
            this.tabControl1.Controls.Add(this.tp_troubleshootFile);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 145);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 342);
            this.tabControl1.TabIndex = 21;
            // 
            // tp_platformTrace
            // 
            this.tp_platformTrace.Controls.Add(this.pnlTrace);
            this.tp_platformTrace.Location = new System.Drawing.Point(4, 22);
            this.tp_platformTrace.Name = "tp_platformTrace";
            this.tp_platformTrace.Padding = new System.Windows.Forms.Padding(3);
            this.tp_platformTrace.Size = new System.Drawing.Size(742, 316);
            this.tp_platformTrace.TabIndex = 0;
            this.tp_platformTrace.Text = "Platform Tracing";
            this.tp_platformTrace.UseVisualStyleBackColor = true;
            // 
            // pnlTrace
            // 
            this.pnlTrace.Controls.Add(this.panel1);
            this.pnlTrace.Controls.Add(this.gb_trace_actions);
            this.pnlTrace.Controls.Add(this.gb_trace_status);
            this.pnlTrace.Controls.Add(this.gb_trace_parameters);
            this.pnlTrace.Location = new System.Drawing.Point(0, 0);
            this.pnlTrace.Name = "pnlTrace";
            this.pnlTrace.Size = new System.Drawing.Size(742, 316);
            this.pnlTrace.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 31);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(24, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(705, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // gb_trace_actions
            // 
            this.gb_trace_actions.Controls.Add(this.btn_trace_cleandirectory);
            this.gb_trace_actions.Controls.Add(this.btn_trace_opendirectory);
            this.gb_trace_actions.Controls.Add(this.btn_trace_zipfiles);
            this.gb_trace_actions.Location = new System.Drawing.Point(464, 148);
            this.gb_trace_actions.Name = "gb_trace_actions";
            this.gb_trace_actions.Size = new System.Drawing.Size(272, 161);
            this.gb_trace_actions.TabIndex = 14;
            this.gb_trace_actions.TabStop = false;
            this.gb_trace_actions.Text = "Actions";
            // 
            // btn_trace_cleandirectory
            // 
            this.btn_trace_cleandirectory.Image = ((System.Drawing.Image)(resources.GetObject("btn_trace_cleandirectory.Image")));
            this.btn_trace_cleandirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_trace_cleandirectory.Location = new System.Drawing.Point(6, 115);
            this.btn_trace_cleandirectory.Name = "btn_trace_cleandirectory";
            this.btn_trace_cleandirectory.Size = new System.Drawing.Size(259, 40);
            this.btn_trace_cleandirectory.TabIndex = 2;
            this.btn_trace_cleandirectory.Text = "Clean Trace Directory";
            this.btn_trace_cleandirectory.UseVisualStyleBackColor = true;
            this.btn_trace_cleandirectory.Click += new System.EventHandler(this.btn_trace_cleandirectory_Click);
            // 
            // btn_trace_opendirectory
            // 
            this.btn_trace_opendirectory.Image = ((System.Drawing.Image)(resources.GetObject("btn_trace_opendirectory.Image")));
            this.btn_trace_opendirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_trace_opendirectory.Location = new System.Drawing.Point(6, 23);
            this.btn_trace_opendirectory.Name = "btn_trace_opendirectory";
            this.btn_trace_opendirectory.Size = new System.Drawing.Size(259, 40);
            this.btn_trace_opendirectory.TabIndex = 1;
            this.btn_trace_opendirectory.Text = "Open Trace Directory";
            this.btn_trace_opendirectory.UseVisualStyleBackColor = true;
            this.btn_trace_opendirectory.Click += new System.EventHandler(this.btn_trace_opendirectory_Click);
            // 
            // btn_trace_zipfiles
            // 
            this.btn_trace_zipfiles.Image = ((System.Drawing.Image)(resources.GetObject("btn_trace_zipfiles.Image")));
            this.btn_trace_zipfiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_trace_zipfiles.Location = new System.Drawing.Point(6, 69);
            this.btn_trace_zipfiles.Name = "btn_trace_zipfiles";
            this.btn_trace_zipfiles.Size = new System.Drawing.Size(259, 40);
            this.btn_trace_zipfiles.TabIndex = 0;
            this.btn_trace_zipfiles.Text = "Zip Trace Files";
            this.btn_trace_zipfiles.UseVisualStyleBackColor = true;
            this.btn_trace_zipfiles.Click += new System.EventHandler(this.btn_trace_zipfiles_Click);
            // 
            // gb_trace_status
            // 
            this.gb_trace_status.Controls.Add(this.btn_trace_status);
            this.gb_trace_status.Location = new System.Drawing.Point(464, 44);
            this.gb_trace_status.Name = "gb_trace_status";
            this.gb_trace_status.Size = new System.Drawing.Size(272, 94);
            this.gb_trace_status.TabIndex = 13;
            this.gb_trace_status.TabStop = false;
            this.gb_trace_status.Text = "Trace Status";
            // 
            // btn_trace_status
            // 
            this.btn_trace_status.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trace_status.Image = ((System.Drawing.Image)(resources.GetObject("btn_trace_status.Image")));
            this.btn_trace_status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_trace_status.Location = new System.Drawing.Point(6, 29);
            this.btn_trace_status.Name = "btn_trace_status";
            this.btn_trace_status.Size = new System.Drawing.Size(260, 40);
            this.btn_trace_status.TabIndex = 0;
            this.btn_trace_status.Text = "btn_trace_status";
            this.btn_trace_status.UseVisualStyleBackColor = true;
            this.btn_trace_status.Click += new System.EventHandler(this.btn_trace_status_Click);
            // 
            // gb_trace_parameters
            // 
            this.gb_trace_parameters.Controls.Add(this.btn_trace_delete);
            this.gb_trace_parameters.Controls.Add(this.btn_trace_saveAs);
            this.gb_trace_parameters.Controls.Add(this.btn_trace_save);
            this.gb_trace_parameters.Controls.Add(this.cbb_trace_profiles);
            this.gb_trace_parameters.Controls.Add(this.lbl_trace_profile);
            this.gb_trace_parameters.Controls.Add(this.btn_trace_browse);
            this.gb_trace_parameters.Controls.Add(this.chk_trace_allCategories);
            this.gb_trace_parameters.Controls.Add(this.lbl_trace_level);
            this.gb_trace_parameters.Controls.Add(this.cbb_level_trace);
            this.gb_trace_parameters.Controls.Add(this.clb_trace_categories);
            this.gb_trace_parameters.Controls.Add(this.label2);
            this.gb_trace_parameters.Controls.Add(this.lbl_trace_tracedirectory);
            this.gb_trace_parameters.Controls.Add(this.txt_trace_tracedirectory);
            this.gb_trace_parameters.Controls.Add(this.nud_trace_maxfilesize);
            this.gb_trace_parameters.Controls.Add(this.lbl_trace_maxfilesize);
            this.gb_trace_parameters.Controls.Add(this.lbl_trace_callstack);
            this.gb_trace_parameters.Controls.Add(this.cb_trace_callstack);
            this.gb_trace_parameters.Location = new System.Drawing.Point(6, 44);
            this.gb_trace_parameters.Name = "gb_trace_parameters";
            this.gb_trace_parameters.Size = new System.Drawing.Size(452, 265);
            this.gb_trace_parameters.TabIndex = 12;
            this.gb_trace_parameters.TabStop = false;
            this.gb_trace_parameters.Text = "Parameters";
            // 
            // btn_trace_delete
            // 
            this.btn_trace_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_trace_delete.Image")));
            this.btn_trace_delete.Location = new System.Drawing.Point(421, 13);
            this.btn_trace_delete.Name = "btn_trace_delete";
            this.btn_trace_delete.Size = new System.Drawing.Size(23, 23);
            this.btn_trace_delete.TabIndex = 16;
            this.btn_trace_delete.UseVisualStyleBackColor = true;
            this.btn_trace_delete.Click += new System.EventHandler(this.btn_trace_delete_Click);
            // 
            // btn_trace_saveAs
            // 
            this.btn_trace_saveAs.Image = ((System.Drawing.Image)(resources.GetObject("btn_trace_saveAs.Image")));
            this.btn_trace_saveAs.Location = new System.Drawing.Point(392, 13);
            this.btn_trace_saveAs.Name = "btn_trace_saveAs";
            this.btn_trace_saveAs.Size = new System.Drawing.Size(23, 23);
            this.btn_trace_saveAs.TabIndex = 15;
            this.btn_trace_saveAs.UseVisualStyleBackColor = true;
            this.btn_trace_saveAs.Click += new System.EventHandler(this.btn_trace_saveAs_Click);
            // 
            // btn_trace_save
            // 
            this.btn_trace_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_trace_save.Image")));
            this.btn_trace_save.Location = new System.Drawing.Point(363, 13);
            this.btn_trace_save.Name = "btn_trace_save";
            this.btn_trace_save.Size = new System.Drawing.Size(23, 23);
            this.btn_trace_save.TabIndex = 14;
            this.btn_trace_save.UseVisualStyleBackColor = true;
            this.btn_trace_save.Click += new System.EventHandler(this.btn_trace_save_Click);
            // 
            // cbb_trace_profiles
            // 
            this.cbb_trace_profiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_trace_profiles.FormattingEnabled = true;
            this.cbb_trace_profiles.Location = new System.Drawing.Point(136, 15);
            this.cbb_trace_profiles.Name = "cbb_trace_profiles";
            this.cbb_trace_profiles.Size = new System.Drawing.Size(221, 21);
            this.cbb_trace_profiles.TabIndex = 13;
            this.cbb_trace_profiles.SelectedIndexChanged += new System.EventHandler(this.cbb_trace_profiles_SelectedIndexChanged);
            // 
            // lbl_trace_profile
            // 
            this.lbl_trace_profile.AutoSize = true;
            this.lbl_trace_profile.Location = new System.Drawing.Point(6, 18);
            this.lbl_trace_profile.Name = "lbl_trace_profile";
            this.lbl_trace_profile.Size = new System.Drawing.Size(70, 13);
            this.lbl_trace_profile.TabIndex = 12;
            this.lbl_trace_profile.Text = "Trace profile";
            // 
            // btn_trace_browse
            // 
            this.btn_trace_browse.Location = new System.Drawing.Point(409, 82);
            this.btn_trace_browse.Name = "btn_trace_browse";
            this.btn_trace_browse.Size = new System.Drawing.Size(29, 23);
            this.btn_trace_browse.TabIndex = 11;
            this.btn_trace_browse.Text = "...";
            this.btn_trace_browse.UseVisualStyleBackColor = true;
            this.btn_trace_browse.Click += new System.EventHandler(this.btn_trace_browse_Click);
            // 
            // chk_trace_allCategories
            // 
            this.chk_trace_allCategories.AutoSize = true;
            this.chk_trace_allCategories.Location = new System.Drawing.Point(136, 110);
            this.chk_trace_allCategories.Name = "chk_trace_allCategories";
            this.chk_trace_allCategories.Size = new System.Drawing.Size(97, 17);
            this.chk_trace_allCategories.TabIndex = 10;
            this.chk_trace_allCategories.Text = "All Categories";
            this.chk_trace_allCategories.UseVisualStyleBackColor = true;
            this.chk_trace_allCategories.CheckedChanged += new System.EventHandler(this.chk_trace_allCategories_CheckedChanged);
            // 
            // lbl_trace_level
            // 
            this.lbl_trace_level.AutoSize = true;
            this.lbl_trace_level.Location = new System.Drawing.Point(6, 236);
            this.lbl_trace_level.Name = "lbl_trace_level";
            this.lbl_trace_level.Size = new System.Drawing.Size(32, 13);
            this.lbl_trace_level.TabIndex = 9;
            this.lbl_trace_level.Text = "Level";
            // 
            // cbb_level_trace
            // 
            this.cbb_level_trace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_level_trace.FormattingEnabled = true;
            this.cbb_level_trace.Items.AddRange(new object[] {
            "Error",
            "Warning",
            "Info",
            "Verbose"});
            this.cbb_level_trace.Location = new System.Drawing.Point(136, 233);
            this.cbb_level_trace.Name = "cbb_level_trace";
            this.cbb_level_trace.Size = new System.Drawing.Size(121, 21);
            this.cbb_level_trace.TabIndex = 8;
            // 
            // clb_trace_categories
            // 
            this.clb_trace_categories.CheckOnClick = true;
            this.clb_trace_categories.FormattingEnabled = true;
            this.clb_trace_categories.Items.AddRange(new object[] {
            "Application ",
            "Application_Outlook ",
            "DataMigration ",
            "Deployment_Sdk ",
            "Exception ",
            "Etm ",
            "NewOrgUtility ",
            "ObjectModel ",
            "ParameterFilter ",
            "Platform ",
            "Platform_Async ",
            "Platform_ImportExportPublish ",
            "Platform_Import ",
            "Platform_Metadata ",
            "Platform_Sdk ",
            "Platform_Soap ",
            "Platform_Sql ",
            "Platform_Workflow ",
            "Reports ",
            "Sandbox ",
            "Sandbox_AssemblyCache ",
            "Sandbox_LoadBalancer ",
            "Sandbox_CallReturn ",
            "Sandbox_EnterExit ",
            "Sandbox_StartStop ",
            "Sandbox_Performance ",
            "Sandbox_Monitoring ",
            "SchedulingEngine ",
            "ServiceBus ",
            "Shared ",
            "SharePointCollaboration ",
            "Unmanaged_Outlook ",
            "Unmanaged_Platform"});
            this.clb_trace_categories.Location = new System.Drawing.Point(136, 133);
            this.clb_trace_categories.Name = "clb_trace_categories";
            this.clb_trace_categories.Size = new System.Drawing.Size(302, 89);
            this.clb_trace_categories.TabIndex = 7;
            this.clb_trace_categories.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_trace_categories_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Categories";
            // 
            // lbl_trace_tracedirectory
            // 
            this.lbl_trace_tracedirectory.AutoSize = true;
            this.lbl_trace_tracedirectory.Location = new System.Drawing.Point(6, 87);
            this.lbl_trace_tracedirectory.Name = "lbl_trace_tracedirectory";
            this.lbl_trace_tracedirectory.Size = new System.Drawing.Size(53, 13);
            this.lbl_trace_tracedirectory.TabIndex = 5;
            this.lbl_trace_tracedirectory.Text = "Directory";
            // 
            // txt_trace_tracedirectory
            // 
            this.txt_trace_tracedirectory.Location = new System.Drawing.Point(136, 84);
            this.txt_trace_tracedirectory.Name = "txt_trace_tracedirectory";
            this.txt_trace_tracedirectory.Size = new System.Drawing.Size(267, 22);
            this.txt_trace_tracedirectory.TabIndex = 4;
            // 
            // nud_trace_maxfilesize
            // 
            this.nud_trace_maxfilesize.Location = new System.Drawing.Point(136, 58);
            this.nud_trace_maxfilesize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_trace_maxfilesize.Name = "nud_trace_maxfilesize";
            this.nud_trace_maxfilesize.Size = new System.Drawing.Size(46, 22);
            this.nud_trace_maxfilesize.TabIndex = 3;
            this.nud_trace_maxfilesize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_trace_maxfilesize
            // 
            this.lbl_trace_maxfilesize.AutoSize = true;
            this.lbl_trace_maxfilesize.Location = new System.Drawing.Point(6, 60);
            this.lbl_trace_maxfilesize.Name = "lbl_trace_maxfilesize";
            this.lbl_trace_maxfilesize.Size = new System.Drawing.Size(123, 13);
            this.lbl_trace_maxfilesize.TabIndex = 2;
            this.lbl_trace_maxfilesize.Text = "Maximum file size (MB)";
            // 
            // lbl_trace_callstack
            // 
            this.lbl_trace_callstack.AutoSize = true;
            this.lbl_trace_callstack.Location = new System.Drawing.Point(6, 39);
            this.lbl_trace_callstack.Name = "lbl_trace_callstack";
            this.lbl_trace_callstack.Size = new System.Drawing.Size(94, 13);
            this.lbl_trace_callstack.TabIndex = 1;
            this.lbl_trace_callstack.Text = "Include call stack";
            // 
            // cb_trace_callstack
            // 
            this.cb_trace_callstack.AutoSize = true;
            this.cb_trace_callstack.Location = new System.Drawing.Point(136, 39);
            this.cb_trace_callstack.Name = "cb_trace_callstack";
            this.cb_trace_callstack.Size = new System.Drawing.Size(15, 14);
            this.cb_trace_callstack.TabIndex = 0;
            this.cb_trace_callstack.UseVisualStyleBackColor = true;
            // 
            // tp_devErrors
            // 
            this.tp_devErrors.Controls.Add(this.pnlDevErrors);
            this.tp_devErrors.Location = new System.Drawing.Point(4, 22);
            this.tp_devErrors.Name = "tp_devErrors";
            this.tp_devErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tp_devErrors.Size = new System.Drawing.Size(742, 316);
            this.tp_devErrors.TabIndex = 2;
            this.tp_devErrors.Text = "Development Errors";
            this.tp_devErrors.UseVisualStyleBackColor = true;
            // 
            // pnlDevErrors
            // 
            this.pnlDevErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDevErrors.Controls.Add(this.gb_devErrors);
            this.pnlDevErrors.Controls.Add(this.panel4);
            this.pnlDevErrors.Location = new System.Drawing.Point(0, 0);
            this.pnlDevErrors.Name = "pnlDevErrors";
            this.pnlDevErrors.Size = new System.Drawing.Size(736, 310);
            this.pnlDevErrors.TabIndex = 0;
            // 
            // gb_devErrors
            // 
            this.gb_devErrors.Controls.Add(this.btn_devErrors_status);
            this.gb_devErrors.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_devErrors.Location = new System.Drawing.Point(4, 40);
            this.gb_devErrors.Name = "gb_devErrors";
            this.gb_devErrors.Size = new System.Drawing.Size(272, 94);
            this.gb_devErrors.TabIndex = 15;
            this.gb_devErrors.TabStop = false;
            this.gb_devErrors.Text = "Status";
            // 
            // btn_devErrors_status
            // 
            this.btn_devErrors_status.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_devErrors_status.Image = ((System.Drawing.Image)(resources.GetObject("btn_devErrors_status.Image")));
            this.btn_devErrors_status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_devErrors_status.Location = new System.Drawing.Point(6, 29);
            this.btn_devErrors_status.Name = "btn_devErrors_status";
            this.btn_devErrors_status.Size = new System.Drawing.Size(260, 40);
            this.btn_devErrors_status.TabIndex = 0;
            this.btn_devErrors_status.Text = "btn_devErrors_status";
            this.btn_devErrors_status.UseVisualStyleBackColor = true;
            this.btn_devErrors_status.Click += new System.EventHandler(this.btn_devErrors_status_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 31);
            this.panel4.TabIndex = 14;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(4, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label3.Location = new System.Drawing.Point(24, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(705, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "Microsoft CRM Web Application usually displays simplified error messages to the e" +
    "nd user.\r\nClick the below button to Enable or Disable display of more detailed e" +
    "rror messages.";
            // 
            // tp_troubleshootFile
            // 
            this.tp_troubleshootFile.Controls.Add(this.pnlTroubleshooting);
            this.tp_troubleshootFile.Location = new System.Drawing.Point(4, 22);
            this.tp_troubleshootFile.Name = "tp_troubleshootFile";
            this.tp_troubleshootFile.Padding = new System.Windows.Forms.Padding(3);
            this.tp_troubleshootFile.Size = new System.Drawing.Size(742, 316);
            this.tp_troubleshootFile.TabIndex = 1;
            this.tp_troubleshootFile.Text = "Troubleshooting file for support";
            this.tp_troubleshootFile.UseVisualStyleBackColor = true;
            // 
            // pnlTroubleshooting
            // 
            this.pnlTroubleshooting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTroubleshooting.Controls.Add(this.progressBar1);
            this.pnlTroubleshooting.Controls.Add(this.gb_file_organizations);
            this.pnlTroubleshooting.Controls.Add(this.gb_file_settings);
            this.pnlTroubleshooting.Controls.Add(this.panel3);
            this.pnlTroubleshooting.Controls.Add(this.btn_file_generate);
            this.pnlTroubleshooting.Location = new System.Drawing.Point(0, 0);
            this.pnlTroubleshooting.Name = "pnlTroubleshooting";
            this.pnlTroubleshooting.Size = new System.Drawing.Size(742, 316);
            this.pnlTroubleshooting.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(398, 234);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(338, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 29;
            // 
            // gb_file_organizations
            // 
            this.gb_file_organizations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_file_organizations.Controls.Add(this.lv_file_organizations);
            this.gb_file_organizations.Location = new System.Drawing.Point(398, 40);
            this.gb_file_organizations.Name = "gb_file_organizations";
            this.gb_file_organizations.Size = new System.Drawing.Size(338, 142);
            this.gb_file_organizations.TabIndex = 28;
            this.gb_file_organizations.TabStop = false;
            this.gb_file_organizations.Text = "Include information about these organizations";
            // 
            // lv_file_organizations
            // 
            this.lv_file_organizations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_file_organizations.CheckBoxes = true;
            this.lv_file_organizations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_file_organizations.Location = new System.Drawing.Point(6, 20);
            this.lv_file_organizations.Name = "lv_file_organizations";
            this.lv_file_organizations.Size = new System.Drawing.Size(326, 116);
            this.lv_file_organizations.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_file_organizations.TabIndex = 0;
            this.lv_file_organizations.UseCompatibleStateImageBehavior = false;
            this.lv_file_organizations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Friendly name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Unique name";
            this.columnHeader2.Width = 120;
            // 
            // gb_file_settings
            // 
            this.gb_file_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_file_settings.Controls.Add(this.tv_file_settings);
            this.gb_file_settings.Location = new System.Drawing.Point(6, 40);
            this.gb_file_settings.Name = "gb_file_settings";
            this.gb_file_settings.Size = new System.Drawing.Size(386, 217);
            this.gb_file_settings.TabIndex = 27;
            this.gb_file_settings.TabStop = false;
            this.gb_file_settings.Text = "Select Information to retrieve";
            // 
            // tv_file_settings
            // 
            this.tv_file_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_file_settings.CheckBoxes = true;
            this.tv_file_settings.Location = new System.Drawing.Point(6, 20);
            this.tv_file_settings.Name = "tv_file_settings";
            treeNode1.Checked = true;
            treeNode1.Name = "tvnServerSystem";
            treeNode1.Text = "General Information";
            treeNode2.Checked = true;
            treeNode2.Name = "tvnServerFramework";
            treeNode2.Text = ".Net Framework";
            treeNode3.Checked = true;
            treeNode3.Name = "tvnServerIp";
            treeNode3.Text = "IP Configuration";
            treeNode4.Checked = true;
            treeNode4.Name = "tvnServerEnvironment";
            treeNode4.Text = "Environment Variables";
            treeNode5.Checked = true;
            treeNode5.Name = "tvnServerTcpIp";
            treeNode5.Text = "TCPIP Parameters Registry Keys";
            treeNode6.Checked = true;
            treeNode6.Name = "tvnServerBootIni";
            treeNode6.Text = "Boot Configuration Data";
            treeNode7.Checked = true;
            treeNode7.Name = "tvnServerInformation";
            treeNode7.Text = "Server Information";
            treeNode8.Checked = true;
            treeNode8.Name = "tvnAdSecurityGroups";
            treeNode8.Text = "Security Groups";
            treeNode9.Checked = true;
            treeNode9.Name = "tvnADInformation";
            treeNode9.Text = "Active Directory Information";
            treeNode10.Checked = true;
            treeNode10.Name = "tvnIisBindings";
            treeNode10.Text = "Bindings";
            treeNode11.Checked = true;
            treeNode11.Name = "tvnIisAppPools";
            treeNode11.Text = "Application Pools";
            treeNode12.Checked = true;
            treeNode12.Name = "tvnIis";
            treeNode12.Text = "IIS Information";
            treeNode13.Checked = true;
            treeNode13.Name = "tvnCrmWindowsServices";
            treeNode13.Text = "Windows Services";
            treeNode14.Checked = true;
            treeNode14.Name = "tvnCrmRegistryKeys";
            treeNode14.Text = "Registry Keys";
            treeNode15.Name = "tvnCrmInstalledFiles";
            treeNode15.Text = "Installed Files";
            treeNode16.Checked = true;
            treeNode16.Name = "tvnCrmLanguagePacks";
            treeNode16.Text = "Language Packs";
            treeNode17.Checked = true;
            treeNode17.Name = "tvnCrmLogsTraceFiles";
            treeNode17.Text = "Logs and Trace Files";
            treeNode18.Checked = true;
            treeNode18.Name = "tvnCrmGacFiles";
            treeNode18.Text = "GAC Files";
            treeNode19.Checked = true;
            treeNode19.Name = "tvnCrmInformation";
            treeNode19.Text = "CRM Information";
            treeNode20.Checked = true;
            treeNode20.Name = "tvnSqlServer";
            treeNode20.Text = "Server Information";
            treeNode21.Checked = true;
            treeNode21.Name = "tvnSqlDeploymentProperties";
            treeNode21.Text = "DeploymentProperties Table";
            treeNode22.Checked = true;
            treeNode22.Name = "tvnSqlConfigurationSettings";
            treeNode22.Text = "ConfigurationSettings Table";
            treeNode23.Checked = true;
            treeNode23.Name = "tvnSqlServer";
            treeNode23.Text = "Server Table";
            treeNode24.Checked = true;
            treeNode24.Name = "tvnSqlBuildVersion";
            treeNode24.Text = "BuildVersion Table";
            treeNode25.Checked = true;
            treeNode25.Name = "tvnSqlOrganization";
            treeNode25.Text = "Organization Table";
            treeNode26.Checked = true;
            treeNode26.Name = "tvnCrmSqlInformation";
            treeNode26.Text = "SQL";
            treeNode27.Checked = true;
            treeNode27.Name = "tvnCrmDataUsers";
            treeNode27.Text = "Users";
            treeNode28.Checked = true;
            treeNode28.Name = "tvnCrmDataPlugins";
            treeNode28.Text = "Plugins";
            treeNode29.Checked = true;
            treeNode29.Name = "tvnCrmData";
            treeNode29.Text = "CRM Data Information";
            treeNode30.Name = "tvnAll";
            treeNode30.Text = "All information";
            this.tv_file_settings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode30});
            this.tv_file_settings.ShowLines = false;
            this.tv_file_settings.ShowPlusMinus = false;
            this.tv_file_settings.Size = new System.Drawing.Size(374, 191);
            this.tv_file_settings.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 31);
            this.panel3.TabIndex = 26;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(4, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label4.Location = new System.Drawing.Point(24, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(705, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // btn_file_generate
            // 
            this.btn_file_generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_file_generate.Image = ((System.Drawing.Image)(resources.GetObject("btn_file_generate.Image")));
            this.btn_file_generate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_file_generate.Location = new System.Drawing.Point(398, 188);
            this.btn_file_generate.Name = "btn_file_generate";
            this.btn_file_generate.Size = new System.Drawing.Size(338, 40);
            this.btn_file_generate.TabIndex = 25;
            this.btn_file_generate.Text = "Generate troubleshooting file";
            this.btn_file_generate.UseVisualStyleBackColor = true;
            this.btn_file_generate.Click += new System.EventHandler(this.btn_file_generate_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.tsbAbout,
            this.toolStripSeparator1,
            this.tsbReportBug,
            this.tsbDiscuss,
            this.tsbRate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 61);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(776, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(23, 22);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbReportBug
            // 
            this.tsbReportBug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReportBug.Image = ((System.Drawing.Image)(resources.GetObject("tsbReportBug.Image")));
            this.tsbReportBug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReportBug.Name = "tsbReportBug";
            this.tsbReportBug.Size = new System.Drawing.Size(23, 22);
            this.tsbReportBug.Text = "Report a bug";
            this.tsbReportBug.ToolTipText = "Report a bug for this tool on CodePlex.\r\n\r\nReport a bug helps to have a better to" +
    "ol!";
            this.tsbReportBug.Click += new System.EventHandler(this.tsbReportBug_Click);
            // 
            // tsbDiscuss
            // 
            this.tsbDiscuss.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDiscuss.Image = ((System.Drawing.Image)(resources.GetObject("tsbDiscuss.Image")));
            this.tsbDiscuss.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiscuss.Name = "tsbDiscuss";
            this.tsbDiscuss.Size = new System.Drawing.Size(23, 22);
            this.tsbDiscuss.Text = "Start a discussion";
            this.tsbDiscuss.ToolTipText = "Start a discussion about this tool on CodePlex for:\r\n- A new feature\r\n- An evolut" +
    "ion of an existing feature\r\n- Anything else";
            this.tsbDiscuss.Click += new System.EventHandler(this.tsbDiscuss_Click);
            // 
            // tsbRate
            // 
            this.tsbRate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRate.Image = ((System.Drawing.Image)(resources.GetObject("tsbRate.Image")));
            this.tsbRate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRate.Name = "tsbRate";
            this.tsbRate.Size = new System.Drawing.Size(23, 22);
            this.tsbRate.Text = "Rate this tool";
            this.tsbRate.ToolTipText = "Rate this tool on CodePlex and make this tool more visible to the community\r\n\r\nWe" +
    "ther you like it or not, please review this tool!";
            this.tsbRate.Click += new System.EventHandler(this.tsbRate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtRemoteServerName);
            this.groupBox1.Controls.Add(this.rbRemoteServer);
            this.groupBox1.Controls.Add(this.rbLocalServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 49);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target Server";
            // 
            // btnConnect
            // 
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(543, 16);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(197, 23);
            this.btnConnect.TabIndex = 32;
            this.btnConnect.Text = "Connect to this server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtRemoteServerName
            // 
            this.txtRemoteServerName.Enabled = false;
            this.txtRemoteServerName.Location = new System.Drawing.Point(200, 18);
            this.txtRemoteServerName.Name = "txtRemoteServerName";
            this.txtRemoteServerName.Size = new System.Drawing.Size(337, 20);
            this.txtRemoteServerName.TabIndex = 31;
            // 
            // rbRemoteServer
            // 
            this.rbRemoteServer.AutoSize = true;
            this.rbRemoteServer.Location = new System.Drawing.Point(98, 19);
            this.rbRemoteServer.Name = "rbRemoteServer";
            this.rbRemoteServer.Size = new System.Drawing.Size(100, 17);
            this.rbRemoteServer.TabIndex = 29;
            this.rbRemoteServer.Text = "Remote server: ";
            this.rbRemoteServer.UseVisualStyleBackColor = true;
            // 
            // rbLocalServer
            // 
            this.rbLocalServer.AutoSize = true;
            this.rbLocalServer.Checked = true;
            this.rbLocalServer.Location = new System.Drawing.Point(7, 19);
            this.rbLocalServer.Name = "rbLocalServer";
            this.rbLocalServer.Size = new System.Drawing.Size(85, 17);
            this.rbLocalServer.TabIndex = 28;
            this.rbLocalServer.TabStop = true;
            this.rbLocalServer.Text = "Local Server";
            this.rbLocalServer.UseVisualStyleBackColor = true;
            this.rbLocalServer.CheckedChanged += new System.EventHandler(this.rbLocalServer_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 494);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(790, 1000);
            this.MinimumSize = new System.Drawing.Size(790, 492);
            this.Name = "MainForm";
            this.Text = "Diagnostics Tool for Microsoft Dynamics CRM 2011";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tp_platformTrace.ResumeLayout(false);
            this.pnlTrace.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_trace_actions.ResumeLayout(false);
            this.gb_trace_status.ResumeLayout(false);
            this.gb_trace_parameters.ResumeLayout(false);
            this.gb_trace_parameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_trace_maxfilesize)).EndInit();
            this.tp_devErrors.ResumeLayout(false);
            this.pnlDevErrors.ResumeLayout(false);
            this.gb_devErrors.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tp_troubleshootFile.ResumeLayout(false);
            this.pnlTroubleshooting.ResumeLayout(false);
            this.gb_file_organizations.ResumeLayout(false);
            this.gb_file_settings.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_platformTrace;
        private System.Windows.Forms.TabPage tp_troubleshootFile;
        private System.Windows.Forms.TabPage tp_devErrors;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRate;
        private System.Windows.Forms.ToolStripButton tsbDiscuss;
        private System.Windows.Forms.ToolStripButton tsbReportBug;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pnlDevErrors;
        private System.Windows.Forms.GroupBox gb_devErrors;
        private System.Windows.Forms.Button btn_devErrors_status;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlTroubleshooting;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox gb_file_organizations;
        private System.Windows.Forms.ListView lv_file_organizations;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox gb_file_settings;
        private System.Windows.Forms.TreeView tv_file_settings;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_file_generate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtRemoteServerName;
        private System.Windows.Forms.RadioButton rbRemoteServer;
        private System.Windows.Forms.RadioButton rbLocalServer;
        private System.Windows.Forms.Panel pnlTrace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_trace_actions;
        private System.Windows.Forms.Button btn_trace_cleandirectory;
        private System.Windows.Forms.Button btn_trace_zipfiles;
        private System.Windows.Forms.GroupBox gb_trace_status;
        private System.Windows.Forms.Button btn_trace_status;
        private System.Windows.Forms.GroupBox gb_trace_parameters;
        private System.Windows.Forms.Button btn_trace_delete;
        private System.Windows.Forms.Button btn_trace_saveAs;
        private System.Windows.Forms.Button btn_trace_save;
        private System.Windows.Forms.ComboBox cbb_trace_profiles;
        private System.Windows.Forms.Label lbl_trace_profile;
        private System.Windows.Forms.Button btn_trace_browse;
        private System.Windows.Forms.CheckBox chk_trace_allCategories;
        private System.Windows.Forms.Label lbl_trace_level;
        private System.Windows.Forms.ComboBox cbb_level_trace;
        private System.Windows.Forms.CheckedListBox clb_trace_categories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_trace_tracedirectory;
        private System.Windows.Forms.TextBox txt_trace_tracedirectory;
        private System.Windows.Forms.NumericUpDown nud_trace_maxfilesize;
        private System.Windows.Forms.Label lbl_trace_maxfilesize;
        private System.Windows.Forms.Label lbl_trace_callstack;
        private System.Windows.Forms.CheckBox cb_trace_callstack;
        private System.Windows.Forms.Button btn_trace_opendirectory;
    }
}

