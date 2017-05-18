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

    public partial class TaskGroup : Form
    {
        DataBaseManager dataBaseManager = DataBaseManager.getInstance();
        public TreeView mainFormTreeview = null;
        public ComboBox  groupSelection = null;
        public TaskGroup()
        {
            InitializeComponent();
        }
        public TaskGroup(DataTable dt)
        {
            InitializeComponent();
            InitTaskGroup(dt);
            button1.Text = "确定";
        }
        String id = null;
        String oldTitle = null;
        String oldNote = null;
        //对编辑状态的网站编辑界面进行初始化
        private void InitTaskGroup(DataTable dt)
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
            String[] taskInfo = new String[2] { title, note };
            if (String.IsNullOrEmpty(title))
            {
                MessageBox.Show("请输入任务分组名称！", "提示");
                return;
            }
            DataTable dt = dataBaseManager.getCurtainTaskGroup(title, id);
            if (dt.Rows.Count>0)
            {
                MessageBox.Show("该分组名称已经存在！", "提示");
                return;
            }
            else
            {
                Boolean result;
                String successStr;
                String failStr;
                if(button1.Text == "确定")
                {
                    result =dataBaseManager.editTaskGroup(id, taskInfo);
                    successStr = "修改成功";
                    failStr = "修改失败";
                }
                else
                {
                    result = dataBaseManager.creatTaskGroup(taskInfo);
                    successStr = "修改成功";
                    failStr = "修改失败";
                }
                if (result)
                {
                    DialogResult dr = MessageBox.Show(successStr, "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        if (mainFormTreeview != null)
                        {
                            new TaskOperation().refresh(mainFormTreeview);
                            DataTable groupdt = dataBaseManager.getTaskGroup();
                            new BindOperation().bindGroupSelection(groupSelection, groupdt);
                        }
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(failStr, "提示");
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
