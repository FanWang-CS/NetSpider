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
    public partial class WebsiteGroup : Form
    {
        DataBaseManager dataBaseManager = DataBaseManager.getInstance();
        //public String GroupNodeText = null;
        public WebsiteGroup()
        {
            InitializeComponent();
        }

        public WebsiteGroup(DataTable dt)
        {
            InitializeComponent();
            InitWebsiteGroupForm(dt);
            button1.Text = "确定";
        }
        String id = null;
        String oldTitle = null;
        String oldNote = null;
        //对编辑状态的网站编辑界面进行初始化
        private void InitWebsiteGroupForm(DataTable dt)
        {

            if (dt.Rows.Count > 0)
            {
                id = dt.Rows[0]["id"] as String;
                oldTitle = dt.Rows[0]["title"] as String;
                oldNote = dt.Rows[0]["note"] as String;
                textBox1.Text = oldTitle;
                textBox2.Text = oldNote;
            }
        }

        private void websiteGroup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String title = textBox1.Text;
            String note = textBox2.Text;
            String[] websiteInfo = new String[2] { title, note };
            if (button1.Text == "确定")
            {

                if (title == oldTitle && note == oldNote)
                {
                    this.Close();
                }
                else if (title.Equals("") || title == null)
                {
                    MessageBox.Show("请输入网站分组名称", "提示");
                    return;
                }
                else
                {
                    if (dataBaseManager.editWebGroup(id, websiteInfo))
                    {
                        DialogResult dr = MessageBox.Show("修改成功", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("修改失败", "提示");
                        return;
                    }
                }
            }
            else
            {
                if (title.Equals("") || title == null)
                {
                    MessageBox.Show("请输入网站名称", "提示");
                }
                else
                {
                    if (dataBaseManager.creatWebGroup(websiteInfo))
                    {
                        DialogResult dr = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("添加失败", "提示");
                        return;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
