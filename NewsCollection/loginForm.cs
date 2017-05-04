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
        public Form form1 = new Form();
        public loginForm()
        {
            InitializeComponent();
        }
        public loginForm(Form rForm)
        {
            InitializeComponent();
            form1 = rForm;
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm register = new RegisterForm();
            register.Show();
        }
        
        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseManager dataBaseManager = DataBaseManager.getInstance();
            //LoginDao loginDao = new LoginDao();
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
            DataTable dt = dataBaseManager.login(username, password);
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
                    this.Hide();
                    dataBaseManager.CurrentUserName = username; //绑定当前用户，保证全局可获取
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
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
    }
}
