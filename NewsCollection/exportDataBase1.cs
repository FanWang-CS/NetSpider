using NewsCollection.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection
{
    public partial class ExportDataBase1 : Form
    {
        DataPanel dataPanel = new DataPanel();
        Panel settingPanel = new Panel();
        public ExportDataBase1()
        {

            InitializeComponent();
            this.comboBox2.SelectedIndex = 0;
            String dataType = (String)comboBox2.SelectedItem;
            settingPanel = dataPanel.getPanel(dataType);
            settingPanel.Location = new Point(6, 14);
            groupBox3.Controls.Add(settingPanel);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
        }

        //当前选择的数据库
        private String currentDataType = "MySql";

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox3.Controls.Remove(settingPanel);
            currentDataType = (String)comboBox2.SelectedItem;
            settingPanel = dataPanel.getPanel(currentDataType);
            settingPanel.Location = new Point(6, 14);
            groupBox3.Controls.Add(settingPanel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            exportDataBase2 exportDataBase2 = new exportDataBase2();
            exportDataBase2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String serverName = dataPanel.serverNameTextBox.Text.Trim();
            String port = dataPanel.portTextBox.Text.Trim();
            String uid = dataPanel.userNameTextBox.Text.Trim();
            String psw = dataPanel.passwordTextBox.Text.Trim();
            if (String.IsNullOrEmpty(serverName) || String.IsNullOrEmpty(port)
                || String.IsNullOrEmpty(uid) || String.IsNullOrEmpty(psw))
            {
                MessageBox.Show("请将信息填写完整", "提示");
                return;
            }
            DatabaseHelper.getInstance().init(serverName, port, uid, psw);
            List<String> databases = DatabaseHelper.getInstance().queryAllDatabaseName();
            if(databases != null && databases.Count > 0)
            {
                database_comboBox.Items.AddRange(databases.ToArray());
                database_comboBox.SelectedIndex = 0;
            }
        }

        private String selectedDatabase;//默认选择的数据库
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDatabase = database_comboBox.SelectedItem as String;
        }
    }
}