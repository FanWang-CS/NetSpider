using NewsCollection.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection
{
    public partial class RegisterForm : Form
    {
        private loginForm loginForm;

        public RegisterForm(loginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        bool IsEmail(string emailStr)
        {
            return Regex.IsMatch(emailStr, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseManager dataManager = DataBaseManager.getInstance();
            //RegisterDao registerDao = new RegisterDao();
            String Usertype = textBox1.Text;
            String Username = textBox2.Text;
            String Email = textBox5.Text;
            String Password = textBox3.Text;
            String CertainPassword = textBox4.Text;
            if (Usertype==null|| Usertype.Equals("")|| Username == null || Username.Equals("") 
                || Email == null || Email.Equals("") || Password == null || Password.Equals("")
                || CertainPassword == null || CertainPassword.Equals(""))
            {
                MessageBox.Show("请填写完整信息", "提示");
                return;
            }
            if (!Password.Equals(CertainPassword))
            {
                MessageBox.Show("密码和确认密码不一致，请重新输入", "提示");
                textBox3.Text = "";
                textBox4.Text = "";
                return;
            }
            if (!IsEmail(Email))
            {
                MessageBox.Show("邮箱的输入错误", "提示");
                return;
            }
            if (!dataManager.canRegeist(Username))
            {
                MessageBox.Show("该用户已经注册过，请重新输入", "提示");
                return;
            }
            if (!dataManager.isAvailableofEmail(Email))
            {
                MessageBox.Show("该邮箱已经注册过，请选择其他的邮箱", "提示");
                return;
            }
            
            MD5 md5 = MD5.Create(); 
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(Password));
            String pwd = "";
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符   
                pwd = pwd + s[i].ToString("x");
            }
            Boolean result = dataManager.regeistUser(Username, Usertype, Email, pwd);
            if (result)
            {
                DialogResult dr = MessageBox.Show("注册成功，马上去登陆吧！", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    ClearText();
                }
            }
            else
            {
                MessageBox.Show("注册失败，请重新注册！");
            }
            dataManager.close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Show();
        }
    }
}
