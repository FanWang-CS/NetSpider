namespace NewsCollection
{
    partial class adminForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("人员审核");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("新增用户");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("人员管理", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("资讯审核");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("资讯管理", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.userManager = new System.Windows.Forms.ToolStripDropDownButton();
            this.setting = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.logRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cleanLog = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pageIndexBox = new System.Windows.Forms.TextBox();
            this.lastpage = new System.Windows.Forms.LinkLabel();
            this.nextpage = new System.Windows.Forms.LinkLabel();
            this.radioButtonStatus = new System.Windows.Forms.RadioButton();
            this.radioButtonType = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pageSizeBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalPageBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1.SuspendLayout();
            this.logRightClick.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 28);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node2";
            treeNode1.Text = "人员审核";
            treeNode2.Name = "Node3";
            treeNode2.Text = "新增用户";
            treeNode3.Name = "Node0";
            treeNode3.Text = "人员管理";
            treeNode4.Name = "Node4";
            treeNode4.Text = "资讯审核";
            treeNode5.Name = "Node1";
            treeNode5.Text = "资讯管理";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(220, 305);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManager});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(920, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // userManager
            // 
            this.userManager.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.userManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setting,
            this.exit});
            this.userManager.Image = ((System.Drawing.Image)(resources.GetObject("userManager.Image")));
            this.userManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.userManager.Name = "userManager";
            this.userManager.Size = new System.Drawing.Size(57, 22);
            this.userManager.Text = "用户名";
            this.userManager.Click += new System.EventHandler(this.userManager_Click);
            // 
            // setting
            // 
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(124, 22);
            this.setting.Text = "用户设置";
            this.setting.Click += new System.EventHandler(this.setting_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(124, 22);
            this.exit.Text = "退出登录";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label
            // 
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label.Location = new System.Drawing.Point(0, 335);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(220, 20);
            this.label.TabIndex = 2;
            this.label.Text = "系统日志";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.ContextMenuStrip = this.logRightClick;
            this.richTextBox1.Location = new System.Drawing.Point(0, 359);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(220, 162);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // logRightClick
            // 
            this.logRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanLog,
            this.saveLog});
            this.logRightClick.Name = "logRightClick";
            this.logRightClick.Size = new System.Drawing.Size(125, 48);
            // 
            // cleanLog
            // 
            this.cleanLog.Name = "cleanLog";
            this.cleanLog.Size = new System.Drawing.Size(124, 22);
            this.cleanLog.Text = "清空日志";
            this.cleanLog.Click += new System.EventHandler(this.cleanLog_Click);
            // 
            // saveLog
            // 
            this.saveLog.Name = "saveLog";
            this.saveLog.Size = new System.Drawing.Size(124, 22);
            this.saveLog.Text = "保存日志";
            this.saveLog.Click += new System.EventHandler(this.saveLog_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(920, 23);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(308, 18);
            this.toolStripStatusLabel1.Text = "您的用户权限是管理员，可以对人员和资讯信息进行管理";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(131, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 18);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(220, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(696, 219);
            this.dataGridView1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(224, 275);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 237);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "全部";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(2, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(686, 207);
            this.dataGridView2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(688, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "页，当前是";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(792, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "页";
            // 
            // pageIndexBox
            // 
            this.pageIndexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pageIndexBox.Location = new System.Drawing.Point(757, 247);
            this.pageIndexBox.Name = "pageIndexBox";
            this.pageIndexBox.Size = new System.Drawing.Size(30, 21);
            this.pageIndexBox.TabIndex = 9;
            this.pageIndexBox.Text = "1";
            this.pageIndexBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pageIndexBox.TextChanged += new System.EventHandler(this.pageIndexBox_TextChanged);
            this.pageIndexBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pageIndexBox_KeyUp);
            // 
            // lastpage
            // 
            this.lastpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lastpage.AutoSize = true;
            this.lastpage.Location = new System.Drawing.Point(818, 252);
            this.lastpage.Name = "lastpage";
            this.lastpage.Size = new System.Drawing.Size(0, 12);
            this.lastpage.TabIndex = 10;
            this.lastpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lastpage_LinkClicked);
            // 
            // nextpage
            // 
            this.nextpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextpage.AutoSize = true;
            this.nextpage.Location = new System.Drawing.Point(868, 251);
            this.nextpage.Name = "nextpage";
            this.nextpage.Size = new System.Drawing.Size(0, 12);
            this.nextpage.TabIndex = 11;
            this.nextpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nextpage_LinkClicked);
            // 
            // radioButtonStatus
            // 
            this.radioButtonStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonStatus.AutoSize = true;
            this.radioButtonStatus.Location = new System.Drawing.Point(3, 0);
            this.radioButtonStatus.Name = "radioButtonStatus";
            this.radioButtonStatus.Size = new System.Drawing.Size(95, 16);
            this.radioButtonStatus.TabIndex = 12;
            this.radioButtonStatus.TabStop = true;
            this.radioButtonStatus.Text = "审核状态分类";
            this.radioButtonStatus.UseVisualStyleBackColor = true;
            this.radioButtonStatus.CheckedChanged += new System.EventHandler(this.radioButtonStatus_CheckedChanged);
            // 
            // radioButtonType
            // 
            this.radioButtonType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonType.AutoSize = true;
            this.radioButtonType.Location = new System.Drawing.Point(137, 0);
            this.radioButtonType.Name = "radioButtonType";
            this.radioButtonType.Size = new System.Drawing.Size(71, 16);
            this.radioButtonType.TabIndex = 13;
            this.radioButtonType.TabStop = true;
            this.radioButtonType.Text = "类型分类";
            this.radioButtonType.UseVisualStyleBackColor = true;
            this.radioButtonType.CheckedChanged += new System.EventHandler(this.radioButtonType_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(639, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "共";
            // 
            // pageSizeBox
            // 
            this.pageSizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSizeBox.Location = new System.Drawing.Point(558, 248);
            this.pageSizeBox.Name = "pageSizeBox";
            this.pageSizeBox.Size = new System.Drawing.Size(30, 21);
            this.pageSizeBox.TabIndex = 16;
            this.pageSizeBox.Text = "20";
            this.pageSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pageSizeBox.TextChanged += new System.EventHandler(this.pageSizeBox_TextChanged);
            this.pageSizeBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pageSizeBox_KeyUp);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "条数据";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(521, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "每页";
            // 
            // totalPageBox
            // 
            this.totalPageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPageBox.Location = new System.Drawing.Point(656, 247);
            this.totalPageBox.Name = "totalPageBox";
            this.totalPageBox.ReadOnly = true;
            this.totalPageBox.Size = new System.Drawing.Size(30, 21);
            this.totalPageBox.TabIndex = 19;
            this.totalPageBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalPageBox.TextChanged += new System.EventHandler(this.totalPageBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.radioButtonType);
            this.panel1.Controls.Add(this.radioButtonStatus);
            this.panel1.Location = new System.Drawing.Point(225, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 16);
            this.panel1.TabIndex = 20;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(809, 525);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "显示时间";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // adminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 541);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.totalPageBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pageSizeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nextpage);
            this.Controls.Add(this.lastpage);
            this.Controls.Add(this.pageIndexBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeView1);
            this.Name = "adminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计量资讯采集器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.adminForm_FormClosed);
            this.Load += new System.EventHandler(this.adminForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.logRightClick.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripDropDownButton userManager;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pageIndexBox;
        private System.Windows.Forms.LinkLabel lastpage;
        private System.Windows.Forms.LinkLabel nextpage;
        private System.Windows.Forms.RadioButton radioButtonStatus;
        private System.Windows.Forms.RadioButton radioButtonType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pageSizeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox totalPageBox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem setting;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripProgressBar toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ContextMenuStrip logRightClick;
        private System.Windows.Forms.ToolStripMenuItem cleanLog;
        private System.Windows.Forms.ToolStripMenuItem saveLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}