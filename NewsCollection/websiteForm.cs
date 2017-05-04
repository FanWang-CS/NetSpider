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
    public partial class WebsiteForm : Form
    {
        DataBaseManager dataBaseManager = DataBaseManager.getInstance();
        DataBaseManager dataManager = DataBaseManager.getInstance();
        public WebsiteForm()
        {
            InitializeComponent();
        }
        public WebsiteForm(DataTable dt)
        {
            InitializeComponent();
            InitWebsiteForm(dt);
            button1.Text = "确定";
        }
        String id = null;
        String oldTitle = null;
        String oldUrl = null;
        String oldNote = null;
        //对编辑状态的网站编辑界面进行初始化
        private void InitWebsiteForm(DataTable dt)
        {

            if (dt.Rows.Count>0)
            {
                id = dt.Rows[0]["id"] as String;
                oldTitle = dt.Rows[0]["title"] as String;
                oldUrl = dt.Rows[0]["url"] as String;
                oldNote = dt.Rows[0]["note"] as String;
                textBox1.Text = oldTitle;
                textBox1.Text = oldUrl;
                textBox1.Text = oldNote;
            }
        }

        private void websiteForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String title = textBox1.Text;
            String Url = textBox2.Text;
            String note = textBox3.Text;
            String[] websiteInfo = new String[3] { title, Url, note };
            if (button1.Text == "确定")
            {
                
                if (title == oldTitle && Url == oldUrl && note == oldNote)
                {
                    this.Close();
                }
                else if (title.Equals("") || title == null)
                {
                    MessageBox.Show("请输入网站名称", "提示");
                }
                else if (Url.Equals("") || Url == null)
                {
                    MessageBox.Show("请输入网址", "提示");
                }
                else
                {
                    if(dataBaseManager.updateCurtainWebsite(id, websiteInfo))
                    {
                        DialogResult dr = MessageBox.Show("修改成功", "提示", MessageBoxButtons.OKCancel);
                        if(dr== DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                if (title.Equals("") || title == null)
                {
                    MessageBox.Show("请输入网站名称", "提示");
                }
                else if (Url.Equals("") || Url == null)
                {
                    MessageBox.Show("请输入网址", "提示");
                }
                else
                {
                    if (dataBaseManager.insertWebsite(websiteInfo))
                    {
                        DialogResult dr = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            this.Close();
                        }
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
