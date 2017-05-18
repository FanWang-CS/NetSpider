using NewsCollection.Dao;
using NewsCollection.Operation;
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
        public String GroupNodeText = null;
        public TreeView mainFormTreeView = null;
        public ComboBox webGroupCombobox = null;
        public ComboBox websiteCombobox = null;
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
                textBox2.Text = oldUrl;
                textBox3.Text = oldNote;
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
            String[] websiteInfo = new String[4] { title, Url, note, GroupNodeText };
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
                DataTable dt = dataBaseManager.getCurtainWebsite(title, GroupNodeText,id);
                if (dt.Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("当前分组已存在该网站名称,清重新输入","提示");
                    if (dr == DialogResult.OK)
                    {
                        textBox1.Text = "";
                    }
                }
                else
                {
                    Boolean result;
                    string successMessage = "";
                    string failedMessage = "";
                    if (button1.Text == "确定")
                    {
                        result = dataBaseManager.updateCurtainWebsite(id, websiteInfo);
                        successMessage = "修改成功";
                        failedMessage = "修改失败";
                    }
                    else
                    {
                        result = dataBaseManager.insertWebsite(websiteInfo);
                        successMessage = "添加成功";
                        failedMessage = "添加失败";
                    }
                    if (result)
                    {
                        DialogResult dr = MessageBox.Show(successMessage, "提示");
                        if (dr == DialogResult.OK)
                        {
                            new WebsiteOpeartion().refresh(mainFormTreeView);
                            String TaskCurrentWebGroupId = webGroupCombobox.Text;
                            DataTable weblist = dataBaseManager.getWebsiteInGroup(TaskCurrentWebGroupId);
                            new BindOperation().bindwebsiteSelection(websiteCombobox, weblist);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(failedMessage, "提示");
                        return;
                    }
                }
            }

        }
        
        //    if (button1.Text == "确定")
        //    {
                
        //        if (title == oldTitle && Url == oldUrl && note == oldNote)
        //        {
        //            this.Close();
        //        }
        //        else if (title.Equals("") || title == null)
        //        {
        //            MessageBox.Show("请输入网站名称", "提示");
        //        }
        //        else if (Url.Equals("") || Url == null)
        //        {
        //            MessageBox.Show("请输入网址", "提示");
        //        }
        //        else
        //        {
        //            if(dataBaseManager.updateCurtainWebsite(id, websiteInfo))
        //            {
        //                DialogResult dr = MessageBox.Show("修改成功", "提示", MessageBoxButtons.OKCancel);
        //                if(dr== DialogResult.OK)
        //                {
        //                    this.Close();
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (title.Equals("") || title == null)
        //        {
        //            MessageBox.Show("请输入网站名称", "提示");
        //        }
        //        else if (Url.Equals("") || Url == null)
        //        {
        //            MessageBox.Show("请输入网址", "提示");
        //        }
        //        else
        //        {
        //            if (dataBaseManager.insertWebsite(websiteInfo))
        //            {
        //                DialogResult dr = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OKCancel);
        //                if (dr == DialogResult.OK)
        //                {
        //                    this.Close();
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("添加失败", "提示");
        //            }
        //        }
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
