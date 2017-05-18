using NewsCollection.Dao;
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
    public partial class userSetting : Form
    {
        DataBaseManager dataBaseManager = DataBaseManager.getInstance();
        public userSetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email = emailBox.Text;
            String password = passwordBox.Text;
            String nickName = nickNameBox.Text;
            if (dataBaseManager.isAvailableofEmail(email))
            {
                String[] newUserInfo = new String[3] { email, password , nickName };
                Boolean result = dataBaseManager.updataUserInfo(newUserInfo);
                if (result)
                {
                    MessageBox.Show("修改成功","提示");
                    userSetting_Load(sender, e);
                    return;
                }
                else
                {
                    MessageBox.Show("修改失败", "提示");
                    userSetting_Load(sender, e);
                    return;
                }
            }
            else
            {
                MessageBox.Show("该邮箱已被其他用户绑定，请重新选择绑定邮箱！", "提示");
            }
        }

        private void userSetting_Load(object sender, EventArgs e)
        {
            emailBox.ReadOnly = true;
            passwordBox.ReadOnly = true;
            nickNameBox.ReadOnly = true;
            DataTable dt=dataBaseManager.getuserInfo();
            if(dt!=null && dt.Rows.Count > 0)
            {

                userNameBox.Text = (String)dt.Rows[0].ItemArray[0];//用户名//邮箱//密码//用户类型//昵称
                emailBox.Text= (String)dt.Rows[0].ItemArray[1];
                passwordBox.Text = (String)dt.Rows[0].ItemArray[2];
                userTypeBox.Text=  (String)dt.Rows[0].ItemArray[3];
                nickNameBox.Text= (String)dt.Rows[0].ItemArray[4];
            } 
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            emailBox.ReadOnly = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            passwordBox.ReadOnly = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nickNameBox.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userSetting_Load(sender, e);
        }
    }
}
