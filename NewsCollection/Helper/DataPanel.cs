using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection.Helper
{
    class DataPanel
    {
        public Panel panel1;

        public Label serverNameLabel;
        public Label portLabel;
        public Label userNameLabel;
        public Label passwordLabel;
        public Label encodingLabel;
        public Label identityLabel;
        public Label tableOwnerLabel;

        public TextBox serverNameTextBox;
        public TextBox portTextBox;
        public TextBox userNameTextBox;
        public TextBox passwordTextBox;
        public TextBox tableOwnerTextBox;
        public ComboBox encodingComboBox;
        public ComboBox identityComboBox;

        public DataPanel()
        {
            panel1 = new Panel();
            panel1.Width = 590;
            panel1.Height = 170;
            panel1.AutoScroll = true;
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;

             serverNameLabel = new Label();
             portLabel = new Label();
             userNameLabel = new Label();
             passwordLabel = new Label();
             encodingLabel = new Label();
             identityLabel = new Label();
             tableOwnerLabel = new Label();

            serverNameTextBox = new TextBox();
            portTextBox = new TextBox();
            userNameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            tableOwnerTextBox = new TextBox();
             encodingComboBox = new ComboBox();
             identityComboBox = new ComboBox();

            serverNameLabel.Text = "服务器名";
            portLabel.Text = "端口";
            userNameLabel.Text = "用户名";
            passwordLabel.Text = "密码";
            encodingLabel.Text = "数据库编码";
            identityLabel.Text = "身份验证";
            tableOwnerLabel.Text = "表所属用户";
            serverNameLabel.Width = 75;
            portLabel.Width = 75;
            userNameLabel.Width = 75;
            passwordLabel.Width = 75;
            encodingLabel.Width = 75;
            identityLabel.Width = 75;

            serverNameTextBox.Width = 470;
            portTextBox.Width = 470;
            userNameTextBox.Width = 470;
            passwordTextBox.Width = 470;
            encodingComboBox.Width = 470;
            tableOwnerTextBox.Width = 470;
            identityComboBox.Width = 470;

            passwordTextBox.PasswordChar = '*';

            identityComboBox.Items.Add("Windows 身份验证");
            identityComboBox.Items.Add("SqlServer 身份验证");

            encodingComboBox.Items.Add("uft-8");
            encodingComboBox.Items.Add("gbk");
            encodingComboBox.Items.Add("gb2312");
            encodingComboBox.Items.Add("big5");
            encodingComboBox.Items.Add("latin1");
            encodingComboBox.Items.Add("ascii");

            identityComboBox.SelectedIndex = 0;
            encodingComboBox.SelectedIndex = 0;
        }

        public Panel getPanel(String dateType)
        {
            
            Console.WriteLine(dateType);
            switch (dateType)
            {
                case "MySql":
                    panel1.Controls.Clear();
                    serverNameLabel.Location=new Point(13,20);
                    panel1.Controls.Add(serverNameLabel);
                    serverNameTextBox.Location = new Point(100, 17);
                    panel1.Controls.Add(serverNameTextBox);
                    portLabel.Location = new Point(13, 50);
                    panel1.Controls.Add(portLabel);
                    portTextBox.Location = new Point(100, 47);
                    panel1.Controls.Add(portTextBox);
                    userNameLabel.Location = new Point(13, 80);
                    panel1.Controls.Add(userNameLabel);
                    userNameTextBox.Location = new Point(100, 77);
                    panel1.Controls.Add(userNameTextBox);
                    passwordLabel.Location = new Point(13, 110);
                    panel1.Controls.Add(passwordLabel);
                    passwordTextBox.Location = new Point(100, 107);
                    panel1.Controls.Add(passwordTextBox);
                    encodingLabel.Location = new Point(13, 140);
                    panel1.Controls.Add(encodingLabel);
                    encodingComboBox.Location = new Point(100, 137);
                    panel1.Controls.Add(encodingComboBox);
                    break;
                case "Oracle":
                    panel1.Controls.Clear();
                    serverNameLabel.Location = new Point(13, 20);
                    panel1.Controls.Add(serverNameLabel);
                    serverNameTextBox.Location = new Point(113, 17);
                    panel1.Controls.Add(serverNameTextBox);
                    portLabel.Location = new Point(13, 50);
                    panel1.Controls.Add(portLabel);
                    portTextBox.Location = new Point(113, 47);
                    panel1.Controls.Add(portTextBox);
                    userNameLabel.Location = new Point(13, 80);
                    panel1.Controls.Add(userNameLabel);
                    userNameTextBox.Location = new Point(113, 77);
                    panel1.Controls.Add(userNameTextBox);
                    passwordLabel.Location = new Point(13, 110);
                    panel1.Controls.Add(passwordLabel);
                    passwordTextBox.Location = new Point(113, 107);
                    panel1.Controls.Add(passwordTextBox);
                    tableOwnerLabel.Location = new Point(13, 140);
                    panel1.Controls.Add(tableOwnerLabel);
                    tableOwnerTextBox.Location = new Point(113, 137);
                    panel1.Controls.Add(tableOwnerTextBox);
                    break;
                case "SqlServer":
                    panel1.Controls.Clear();
                    serverNameLabel.Location = new Point(13, 20);
                    panel1.Controls.Add(serverNameLabel);
                    serverNameTextBox.Location = new Point(113, 17);
                    panel1.Controls.Add(serverNameTextBox);
                    identityLabel.Location = new Point(13, 50);
                    panel1.Controls.Add(identityLabel);
                    identityComboBox.Location = new Point(113, 47);
                    panel1.Controls.Add(identityComboBox);
                    userNameLabel.Location = new Point(13, 80);
                    panel1.Controls.Add(userNameLabel);
                    userNameTextBox.Location = new Point(113, 77);
                    panel1.Controls.Add(userNameTextBox);
                    passwordLabel.Location = new Point(13, 110);
                    panel1.Controls.Add(passwordLabel);
                    passwordTextBox.Location = new Point(113, 107);
                    panel1.Controls.Add(passwordTextBox);
                    break;
                default:
                    MessageBox.Show("无法将这个数据导入到这个数据库，请选择系统提供的数据库","提示");
                    break;
            }
            return panel1;
        }
    }
}
