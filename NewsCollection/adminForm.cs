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
    public partial class adminForm : Form
    {
        Form loginForm;
        DataBaseManager dataBaseManager = DataBaseManager.getInstance();
        public adminForm(Form rForm)
        {
            loginForm = rForm;
            InitializeComponent();
            InitUserManager();
        }

        int pageSize;
        int pageIndex=1;
        int totalPage=1;
        TreeNode selectNode;
        String tableName;
        String classifyField; 
        private void adminForm_Load(object sender, EventArgs e)
        {

        }


        //右边树型结构的点击事件
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            pageSizeBox.Text = "20";
            pageIndexBox.Text = "1";
            pageSize = Convert.ToInt32(pageSizeBox.Text);
            pageIndex = Convert.ToInt32(pageIndexBox.Text);
            selectNode = treeView1.GetNodeAt(e.X, e.Y);
            if (selectNode.Text == "人员审核")
            {
                
                dataGridView1.Columns.Clear();

                lastpage.Text = "";
                tableName = "user";
                classifyField = "usertype";
                addStatusCol(dataGridView1);
                
                int totalNum = dataBaseManager.getTotalNum(tableName);
                totalPage = (int)Math.Ceiling(totalNum / (double)pageSize);
                totalPageBox.Text = Convert.ToString(totalPage);
                DataTable dt1 = dataBaseManager.getDataResult(tableName, pageIndex, pageSize);
                dataGridView1.DataSource = dt1;

                

                if (radioButtonStatus.Checked == true)
                {
                    radioButtonStatus_CheckedChanged(sender, e);
                }
                else if(radioButtonType.Checked == true)
                {
                    radioButtonType_CheckedChanged(sender, e);
                }
                else
                {
                    DataTable dt2 = dataBaseManager.getClassifyResult(tableName, "", "");
                    dataGridView2.DataSource = dt2;
                }
            }
            else if (selectNode.Text == "新增用户")
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 7;
                dataGridView1.ColumnHeadersVisible = true;

                //设置表头样式
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

                //columnHeaderStyle.BackColor = Color.Beige;
                //columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
                //dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                // 设置表头
                dataGridView1.Columns[0].Name = "用户名";
                dataGridView1.Columns[1].Name = "邮箱";
                dataGridView1.Columns[2].Name = "密码";
                dataGridView1.Columns[3].Name = "用户类型";
                dataGridView1.Columns[4].Name = "审核状态";
                dataGridView1.Columns[5].Name = "添加";
                dataGridView1.Columns[6].Name = "删除";
            }
            else if (selectNode.Text == "资讯审核")
            {
                dataGridView1.Columns.Clear();
                //dataGridView1.ColumnCount = 1;
                //dataGridView1.ColumnHeadersVisible = true;
                //dataGridView1.Columns[0].Name = "审核状态";
                //dataGridView1.Columns[0].CellType


                tableName = "news";
                classifyField = "newstype";
                addStatusCol(dataGridView1);
                int totalNum = dataBaseManager.getTotalNum(tableName);
                totalPage = (int)Math.Ceiling(totalNum / (double)pageSize);
                totalPageBox.Text = Convert.ToString(totalPage);
                DataTable dt1 = dataBaseManager.getDataResult(tableName, pageIndex, pageSize);
                dataGridView1.DataSource = dt1;
                
               
                //dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgView_EditingControlShowing);
                if (radioButtonStatus.Checked == true)
                {
                    radioButtonStatus_CheckedChanged(sender, e);
                }
                else if (radioButtonType.Checked == true)
                {
                    radioButtonType_CheckedChanged(sender, e);
                }
                else
                {
                    DataTable dt2 = dataBaseManager.getClassifyResult(tableName, "", "");
                    dataGridView2.DataSource = dt2;
                }
            }
        }
        //在最后添加一列
        private void addStatusCol(DataGridView dataGridView)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Name = "checkstatus";
            column.DataPropertyName = "checkstatus";
            column.HeaderText = "审核状态";
            this.dataGridView1.Columns.Add(column);
            column.DataSource = dataBaseManager.getStatus(tableName);      //这里需要设置一下combox的itemsource,以便combox根据数据库中对应的值自动显示信息
            column.DisplayMember = "Status";
            column.ValueMember = "checkstatus";
           
        }


        //在当前页输入页码并点击回车
        private void pageIndexBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                loadingPage();
            }
        }
        //当当前页码改变时，重新加载页面
        private void loadingPage()
        {
            if (pageIndexBox.Text.Trim() == null)
                pageIndex = 0;
            pageIndex = Convert.ToInt32(pageIndexBox.Text.Trim());
            if (pageIndex <= 0)
            {
                MessageBox.Show("输入页码无效", "提示");
                return;
            }
            else if (pageIndex > totalPage)
            {
                MessageBox.Show("输入页码超过数据最大页数", "提示");
                return;
            }
            if (pageIndex == 1)
            {
                lastpage.Text = "";
            }
            else if (pageIndex == totalPage)
            {
                nextpage.Text = "";
            }
            DataTable dt = dataBaseManager.getDataResult(tableName, pageIndex, pageSize);
            dataGridView1.DataSource = dt;
        }

        //在每页数据处输入数据并点击回车
        private void pageSizeBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                if (pageSizeBox.Text.Trim() == null)
                    pageSize = 0;
                pageSize = Convert.ToInt32(pageSizeBox.Text.Trim());
                if (pageIndex <= 0)
                {
                    MessageBox.Show("输入数据无效", "提示");
                    return;
                }
                pageIndexBox.Text = "1";
                DataTable dt = dataBaseManager.getDataResult(tableName, pageIndex, pageSize);
                dataGridView1.DataSource = dt;
            }
        }
        //在每页数据数量改变时
        private void pageSizeBox_TextChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(pageSizeBox.Text.Trim());
            pageIndex = Convert.ToInt32(pageIndexBox.Text.Trim());
        }

        private void pageIndexBox_TextChanged(object sender, EventArgs e)
        {
            pageIndex = Convert.ToInt32(pageIndexBox.Text.Trim());
            if (pageIndex > 1)
                lastpage.Text = "上一页";
            if(pageIndex<totalPage)
                nextpage.Text = "下一页";
        }
        //点击上一页
        private void lastpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                pageIndexBox.Text = Convert.ToString(pageIndex);
                loadingPage();
            }
        }
        //点击下一页
        private void nextpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pageIndex < totalPage)
            {
                pageIndex++;
                pageIndexBox.Text = Convert.ToString(pageIndex);
                loadingPage();
            }
        }
        //总页数改变
        private void totalPageBox_TextChanged(object sender, EventArgs e)
        {
            totalPage = Convert.ToInt32(totalPageBox.Text);
            if (totalPage > 1)
            {
                nextpage.Text = "下一页";
            }
            else if (totalPage==1)
            {
                nextpage.Text = "";
            }
        }
        //选择审核状态分类
        private void radioButtonStatus_CheckedChanged(object sender, EventArgs e)
        {
            String[] checkType = {"1","0","-1"};
            String[] checkTypeName = { "审核通过", "未审核", "审核不通过" };
            removeAllTabPages(tabControl1);
            for (int i = 0; i < checkType.Length; i++)
            {
                DataTable dt2 = dataBaseManager.getClassifyResult(tableName, "checkstatus", checkType[i]);
                TabPage tabPage = new TabPage();
                tabPage.Name = "tabPage" + (i + 1).ToString();
                tabPage.Text = checkTypeName[i];
                tabPage.TabIndex = i;
                DataGridView dataGridView = new DataGridView();
                dataGridView.Name = "dataGridView" + (i + 2);
                dataGridView.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                tabPage.Controls.Add(dataGridView);
                tabControl1.Controls.Add(tabPage);
                dataGridView.DataSource = dt2;
            }
        }
        //清空TabControl里所有的TabPage
        private void removeAllTabPages(TabControl tabControl)
        {
            int tabCount = tabControl.TabCount;
            for (int i = tabCount - 1; i >= 0; i--)
            {
                tabControl.TabPages.RemoveAt(i);
            }
        }

        //选择类型分类
        private void radioButtonType_CheckedChanged(object sender, EventArgs e)
        {
            DataTable typeTable = dataBaseManager.getClassifyType(tableName, classifyField);
            if(typeTable!=null && typeTable.Rows.Count > 0)
            {
                removeAllTabPages(tabControl1);
                for (int i = 0; i < typeTable.Rows.Count; i++)
                {
                    String typeTitle =null;
                    typeTitle = (String)typeTable.Rows[i].ItemArray[0];
                    DataTable dt2 = dataBaseManager.getClassifyResult(tableName, classifyField, typeTitle);
                    TabPage tabPage = new TabPage();
                    tabPage.Name = "tabPage" + (i + 1).ToString();
                    tabPage.Text = typeTitle;
                    tabPage.TabIndex = i;
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.Name = "dataGridView" + (i + 2);
                    dataGridView.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                    tabPage.Controls.Add(dataGridView);
                    tabControl1.Controls.Add(tabPage);
                    dataGridView.DataSource = dt2;
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            dataBaseManager.CurrentUserName = null;//解除用户绑定
            //userManager.Text = "登录";
            //userManager.ToolTipText = "点击进行登录";
            InitUserManager();
        }
        public void InitUserManager()
        {
            if (dataBaseManager.CurrentUserName != null)
            {
                userManager.Text = dataBaseManager.CurrentUserName;
                userManager.ToolTipText = dataBaseManager.CurrentUserName + "已登录";
            }
            else
            {
                userManager.Text = "登录";
                userManager.ToolTipText = "点击进行登录";
            }
        }

        private void setting_Click(object sender, EventArgs e)
        {

        }

        private void userManager_Click(object sender, EventArgs e)
        {
            String curtaInuserStatus = userManager.Text;
            if (curtaInuserStatus == "登录")
            {
                this.Hide();
                loginForm login = new loginForm();
                login.Show();
            }
        }

        private void adminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close();
        }
    }
}
