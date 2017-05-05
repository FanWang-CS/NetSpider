using NewsCollection.Dao;
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
       // DataExportDao dataExportDao = new DataExportDao();
        public ExportDataBase1()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            initConfig();
        }

        private DataTable OuterConfigTable;
        private List<String> OuterConfigNames;
        /// <summary>
        /// 自动获取上次存放的记录
        /// </summary>
        private void initConfig()
        {
            OuterConfigTable = DataBaseManager.getInstance().getAllConfig();
            if(OuterConfigTable.Rows.Count>0)
            {
                int rowNum = OuterConfigTable.Rows.Count;
                OuterConfigNames = new List<string>();
                for(int i = 0; i < rowNum; i++)
                {
                    OuterConfigNames.Add(OuterConfigTable.Rows[i][0] as String);
                }
                outconfig_comboBox.Items.AddRange(OuterConfigNames.ToArray());
                outconfig_comboBox.SelectedIndex = 0;
            }
        }

        private void outconfig_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ip = OuterConfigTable.Rows[outconfig_comboBox.SelectedIndex]["ip"] as String;
            String port = OuterConfigTable.Rows[outconfig_comboBox.SelectedIndex]["port"] as String;
            String dbname = OuterConfigTable.Rows[outconfig_comboBox.SelectedIndex]["dbname"] as String;
            dataPanel.serverNameTextBox.Text = ip;
            dataPanel.portTextBox.Text = port;
            dataPanel.userNameTextBox.Text = dbname;
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

        private void button4_Click(object sender, EventArgs e)
        {
            database_comboBox.Text = "";
            database_comboBox.Items.Clear();
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

        private void saveconfig_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (saveconfig_checkbox.Checked)
            {
                saveconfig_textbox.Enabled = true;
            }
            else
            {
                saveconfig_textbox.Enabled = false;
            }
        }

        //下一步
        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(selectedDatabase))
            {
                MessageBox.Show("请选择数据库");
                return;
            }

            //是否保存数据
            if (saveconfig_checkbox.Checked)
            {
                String configName = saveconfig_textbox.Text;
               if(String.IsNullOrEmpty(configName))
                {
                    MessageBox.Show("请填写数据库配置保存的名称", "提示");
                    return;
                }
               if (OuterConfigNames!=null && OuterConfigNames.Contains(configName))
                {
                    MessageBox.Show("该数据库配置名称已存在！", "提示");
                    return;
                }
                String serverName = dataPanel.serverNameTextBox.Text.Trim();
                String port = dataPanel.portTextBox.Text.Trim();
                String uid = dataPanel.userNameTextBox.Text.Trim();
                DataBaseManager.getInstance().saveConfig(configName, serverName, port, uid);
            }
            DatabaseHelper.getInstance().DataBaseName = selectedDatabase;
            this.Hide();
            exportDataBase2 exportDataBase2 = new exportDataBase2(this);
            exportDataBase2.Show();
        }

        //释放DataBaseHelper对象
        private void ExportDataBase1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("清空对象");
            DatabaseHelper.getInstance().close();
        }
    }
}