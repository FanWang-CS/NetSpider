using NewsCollection.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection
{
    public partial class loginForm : Form
    {
        private Form mainForm;
        private Boolean isLoginSuccess = false;

        public loginForm()
        {
            
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm register = new RegisterForm(this);
            register.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseManager dataBaseManager = DataBaseManager.getInstance();
            String usertype = (String)comboBox1.SelectedItem;
            String username = textBox1.Text;
            String password = textBox2.Text;
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            password = "";
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符   
                password = password + s[i].ToString("x");
            }
            DataTable dt = dataBaseManager.login(username, password, usertype);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("用户名或密码错误，请检查输入内容","提示");
                return;
            }
            else
            {
                int checkstatus = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                if (checkstatus == 1)
                {
                    isLoginSuccess = true;
                    //this.Close();
                    dataBaseManager.CurrentUserName = username; //绑定当前用户，保证全局可获取
                    dataBaseManager.CurrentUserType = usertype; //绑定当前用户，保证全局可获取
                    if (usertype == "管理员")
                    {
                        adminForm adminForm = new adminForm(this);
                        adminForm.Show();
                    }
                    else
                    {
                        MainForm mainForm = new MainForm(this);
                        mainForm.Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("用户状态为待审核，等待管理员审核！", "提示");
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoginSuccess)
            {
                mainForm.Close();
            }
        }
    }
}
