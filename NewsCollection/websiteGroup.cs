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
    public partial class WebsiteGroup : Form
    {
        DataBaseManager dataBaseManager = DataBaseManager.getInstance();
        //public String GroupNodeText = null;
        public TreeView mainFormTreeView = null;
        public ComboBox webGroupCombox = null;
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
            String[] webgroupInfo = new String[2] { title, note };
            if (title.Equals("") || title == null)
            {
                MessageBox.Show("请输入网站名称", "提示");
            }
            else
            {
                DataTable dt = dataBaseManager.getWebGroupInfo(title, id);
                if (dt.Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("该分组名称已经存在,请重新输入分组名称", "提示");
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
                        result = dataBaseManager.editWebGroup(id, webgroupInfo);
                        successMessage = "修改成功";
                        failedMessage = "修改失败";
                    }
                    else
                    {
                        result=dataBaseManager.creatWebGroup(webgroupInfo);
                        successMessage = "添加成功";
                        failedMessage = "添加失败";
                    }
                    if (result)
                    {
                        DialogResult dr = MessageBox.Show(successMessage, "提示");
                        if (dr == DialogResult.OK)
                        {
                            new WebsiteOpeartion().refresh(mainFormTreeView);
                            DataTable webGroupDt = dataBaseManager.getWebsiteGroup();
                            new BindOperation().bindGroupSelection(webGroupCombox, webGroupDt);
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
