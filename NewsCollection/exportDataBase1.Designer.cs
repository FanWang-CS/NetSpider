using System;
using System.Drawing;

namespace NewsCollection
{
    partial class ExportDataBase1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outconfig_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.saveconfig_textbox = new System.Windows.Forms.TextBox();
            this.saveconfig_checkbox = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.database_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 59);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(89, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "填写你要将数据导入到的数据库的信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择数据库";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outconfig_comboBox);
            this.groupBox1.Location = new System.Drawing.Point(33, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // outconfig_comboBox
            // 
            this.outconfig_comboBox.FormattingEnabled = true;
            this.outconfig_comboBox.Location = new System.Drawing.Point(34, 21);
            this.outconfig_comboBox.Name = "outconfig_comboBox";
            this.outconfig_comboBox.Size = new System.Drawing.Size(459, 20);
            this.outconfig_comboBox.TabIndex = 0;
            this.outconfig_comboBox.SelectedIndexChanged += new System.EventHandler(this.outconfig_comboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.database_comboBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(33, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 403);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.saveconfig_textbox);
            this.groupBox4.Controls.Add(this.saveconfig_checkbox);
            this.groupBox4.Location = new System.Drawing.Point(13, 331);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(601, 64);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // saveconfig_textbox
            // 
            this.saveconfig_textbox.Enabled = false;
            this.saveconfig_textbox.Location = new System.Drawing.Point(126, 26);
            this.saveconfig_textbox.Name = "saveconfig_textbox";
            this.saveconfig_textbox.Size = new System.Drawing.Size(433, 23);
            this.saveconfig_textbox.TabIndex = 1;
            // 
            // saveconfig_checkbox
            // 
            this.saveconfig_checkbox.AutoSize = true;
            this.saveconfig_checkbox.Location = new System.Drawing.Point(23, 27);
            this.saveconfig_checkbox.Name = "saveconfig_checkbox";
            this.saveconfig_checkbox.Size = new System.Drawing.Size(75, 21);
            this.saveconfig_checkbox.TabIndex = 0;
            this.saveconfig_checkbox.Text = "保存配置";
            this.saveconfig_checkbox.UseVisualStyleBackColor = true;
            this.saveconfig_checkbox.CheckedChanged += new System.EventHandler(this.saveconfig_checkbox_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(514, 254);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 27);
            this.button4.TabIndex = 6;
            this.button4.Text = "连接";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // database_comboBox
            // 
            this.database_comboBox.FormattingEnabled = true;
            this.database_comboBox.Location = new System.Drawing.Point(91, 288);
            this.database_comboBox.Name = "database_comboBox";
            this.database_comboBox.Size = new System.Drawing.Size(524, 25);
            this.database_comboBox.TabIndex = 4;
            this.database_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据库名称";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(13, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 201);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "MySql",
            "Oracle",
            "SqlServer"});
            this.comboBox2.Location = new System.Drawing.Point(113, 16);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(476, 25);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "选择数据库类型";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(532, 542);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "下一步";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ExportDataBase1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 582);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExportDataBase1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出到数据";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExportDataBase1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox outconfig_comboBox;
        private System.Windows.Forms.ComboBox database_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox saveconfig_textbox;
        private System.Windows.Forms.CheckBox saveconfig_checkbox;
    }
}