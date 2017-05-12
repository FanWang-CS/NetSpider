using Microsoft.VisualBasic;
using NewsCollection.Dao;
using NewsCollection.Helper;
using NewsCollection.Model;
using NewsCollection.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winista.Text.HtmlParser;

namespace NewsCollection
{
    public partial class MainForm : Form
    {
        Form loginForm;
        DataBaseManager dataManager = DataBaseManager.getInstance();
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
        int step = 0;
        public int Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }

        public MainForm(Form rForm)
        {

            loginForm = rForm;
            InitializeComponent();
            InitUserManager();
        }

        public void InitUserManager()
        {
            if (dataManager.CurrentUserName != null){
                userManager.Text = dataManager.CurrentUserName;
                userManager.ToolTipText = dataManager.CurrentUserName+"已登录";
            }
            else
            {
                userManager.Text = "登录";
                userManager.ToolTipText = "点击进行登录";
            }
        }

        //private void MainForm_Shown(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    loginForm loginForm = new loginForm(this);
        //    loginForm.Show();
        //}

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
        //点击主界面的网站管理
        private void button1_Click(object sender, EventArgs e)
        {
            //bool hasDisplay =false;//状态栏是否已经有显示
            if (groupBox5.Text.Equals("网站管理"))
            {
                Refresh();
            }
            else
            {
                groupBox5.Text = "网站管理";
                foreach (Control ctl in this.groupBox5.Controls)
                {
                    Control controls1 = ctl;
                    if (ctl is GroupBox)
                    {
                        ctl.Visible = false;
                    }
                }
                treeView1.Visible = true;
                textBox1.Visible = true;
                treeView1.Name = "treeView1";
                treeView1.ContextMenuStrip = websiteBlank;
                WebsiteOpeartion websiteOpeartion = new WebsiteOpeartion();
                websiteOpeartion.refresh(treeView1);
              

            }
        }
        /**
         * 调整窗口大小时动态调整控件的大小
         **/
        private void mainForm_Resize(object sender, EventArgs e)
        {
            int height = this.Height;
            int Width = this.Width;
            //Console.WriteLine("height:{0},weight:{1},bottom:{2}", height, weight, statusStrip1.Bottom);
            //Console.ReadLine();
            int gboxheight = (statusStrip1.Bottom - statusStrip1.Height - toolStrip1.Bottom) / 2;
            groupBox5.Height = gboxheight;
            groupBox1.Height = gboxheight;
            treeView1.Height = groupBox5.Height - 80;
            groupBox1.Top = groupBox5.Top + gboxheight;

        }
        //点击主界面的我的任务
        private void button3_Click(object sender, EventArgs e)
        {

            if (groupBox5.Text.Equals("我的任务"))
            {
                Refresh();
            }
            else
            {
                groupBox5.Text = "我的任务";
                foreach (Control ctl in this.groupBox5.Controls)
                {
                    Control controls1 = ctl;
                    if (ctl is GroupBox)
                    {
                        ctl.Visible = false;
                    }
                }
                treeView1.Visible = true;
                textBox1.Visible = true;
                treeView1.Name = "treeView1";
                treeView1.Nodes.Clear();
                treeView1.ContextMenuStrip = taskBlank;
                //四种新闻类型
                TaskOperation taskOperation = new TaskOperation();
                taskOperation.refresh(treeView1);

                //TreeNode tn1 = treeView1.Nodes.Add("通知公告");
                //TreeNode tn2 = treeView1.Nodes.Add("新闻资讯");
                //TreeNode tn3 = treeView1.Nodes.Add("行业动态");
                //TreeNode tn4 = treeView1.Nodes.Add("法规政策");
                ////
                //TreeNode Ntn1 = new TreeNode("湖南计量院");
                //TreeNode Ntn2 = new TreeNode("湖南质监局");
                //tn1.Nodes.Add(Ntn1);
                //tn1.Nodes.Add(Ntn2);

            }
        }
        //点击主界面的任务状态
        private void button2_Click(object sender, EventArgs e)
        {

            if (groupBox5.Text.Equals("任务状态"))
            {
                Refresh();
            }
            else
            {
                groupBox5.Text = "任务状态";
                treeView1.Visible = false;
                textBox1.Visible = false;
                foreach (Control ctl in this.groupBox5.Controls)
                {
                    if (ctl is GroupBox)
                    {
                        ctl.Visible = true;
                    }
                }
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (treeView1.Parent.Text == "网站管理")
            {
                treeView1.ContextMenuStrip = websiteBlank;

                TreeNode selectNode = treeView1.GetNodeAt(e.X, e.Y);
                if (selectNode == null)
                {
                    return;
                }
                else if (selectNode.Level == 0)
                {
                    selectNode.ContextMenuStrip = websiteGroupClick;
                    return;
                }
                else if (selectNode.Level == 1)

                {
                    selectNode.ContextMenuStrip = websiteRightClick;
                    return;
                }
            }
            else if (treeView1.Parent.Text == "我的任务")
            {
                treeView1.ContextMenuStrip = taskBlank;

                TreeNode selectNode = treeView1.GetNodeAt(e.X, e.Y);

                if (selectNode.Level == 0)

                {
                    selectNode.ContextMenuStrip = taskGroupClick;
                    return;
                }
                else if (selectNode.Level == 1)

                {
                    selectNode.ContextMenuStrip = taskRightClick;
                    return;
                }
            }

        }


        private Task task;
        //"上一步"按钮
        private void button7_Click(object sender, EventArgs e)
        {
            if (step == 0)
            {
                MessageBox.Show("当前步骤已经是第一步", "提示");
            }
            else
            {
                step--;
                tabControl2.SelectedIndex = step;
                ImageHelper imageHelper = new ImageHelper();
                pictureBox1.Image = imageHelper.getImage(step);
            }
        }
        //"下一步"按钮
        private void button8_Click(object sender, EventArgs e)
        {
            if (step == 5)
            {
                MessageBox.Show("当前步骤已经是最后一步", "提示");
            }
            else
            {
                switch (step)
                {
                    case 0:
                        String taskname = tasknameview.Text.ToString();
                        String taskdesc = taskdescview.Text.ToString();
                        String groupname = taskgroupview.Text.ToString();
                        if (String.IsNullOrEmpty(taskname))
                        {
                            MessageBox.Show("请选择任务分组");
                            return;
                        }
                        if (String.IsNullOrEmpty(groupname))
                        {
                            MessageBox.Show("请选择组名");
                            return;
                        }
                        task = new Task(taskname, taskdesc, groupname);
                        break;
                    case 1:
                        String netUrl = neturlview.Text.ToString();
                        if (String.IsNullOrEmpty(netUrl))
                        {
                            MessageBox.Show("请选择网址");
                            return;
                        }
                        webview.Navigate(netUrl);
                        task.NetUrl = netUrl;
                        Console.WriteLine("加载页面：" + netUrl);
                        webview.Visible = true;
                        break;
                    case 2://规则
                        break;
                    case 3:  //选择采集方式
                        task.execute(dataGridView2, button8);
                       
                        break;
                    case 4:
                        //开始采集
                        break;
                }
                step++;
                tabControl2.SelectedIndex = step;
                ImageHelper imageHelper = new ImageHelper();
                pictureBox1.Image = imageHelper.getImage(step);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)

        {
            if (this.checkBox1.Checked)
            {
                statusStrip1.Items[2].Text = "日期:" + DateTime.Now.ToString();  //在控件statusStrip1中显示系统当前日期
            }
            else
            {
                statusStrip1.Items[2].Text = "";  //控件statusStrip1的内容设置为空
            }
        }

        private Boolean isBindDocumentClick = false;
        private void webview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webview.Stop();
            Console.WriteLine("页面加载完成！！");
            if (!isBindDocumentClick)
            {
                webview.Document.Click += onWebViewNodeClicked;
                isBindDocumentClick = true;
            }
        }

        //防止弹出弹窗
        private void webview_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            WebBrowserHelper.InjectAlertBlocker(webview);
        }

        //防止弹出新窗口
        private void webview_NewWindow(object sender, CancelEventArgs e)
        {
           e.Cancel = true;
            String netUrl = neturlview.Text.ToString();
            webview.Navigate(netUrl);
        }

        private Boolean isMakeRule = false;
        private String firstHrefStr = "";
        private String firstClassName = "";
        //选择WebView节点时
        private void onWebViewNodeClicked(object sender, HtmlElementEventArgs e)
        {
           
            if (webview.Document != null)
            {
                //获取点击的结点
                HtmlElement elem = webview.Document.GetElementFromPoint(e.ClientMousePosition);
                if (isSelectingNextPage)
                {
                    //生成下一个过滤器
                    task.NextPagerFilter = new ClassInnerTextNodeFilter(elem.TagName, elem.InnerText);
                    next_input1.Text = "识别标签：" + elem.TagName;
                    next_input2.Text = "识别文本：" + elem.InnerText;
                    isSelectingNextPage = false;
                }
                else
                {   //  生成数据扒取过滤器
                    //  如果是选择<A>
                    if (elem.TagName.Equals("A"))
                    {
                        if (isMakeRule)
                        {
                            String nextHrefStr = elem.GetAttribute("href");
                            String nextClassName = elem.GetAttribute("className");
                            String originPrefix = StringHelper.getIdentical_Prefix(firstHrefStr,nextHrefStr);
                            if (String.IsNullOrEmpty(originPrefix))
                            {
                                isMakeRule = false;
                                MessageBox.Show("不能生成识别规则，请重新尝试！","提示");
                                return;
                            }
                           
                            //展示： 添加一行数据
                            int t = this.dataGridView1.Rows.Add();
                            this.dataGridView1.Rows[t].Cells["getdata"].Value = elem.InnerText;
                            //扒取： 获取节点特征
                            String preFix = originPrefix;   //弹出修改框 允许修改
                            preFix = Interaction.InputBox("自动生成的规则前缀", "提示", originPrefix, -1, -1);

                            String classNameStr = null;
                            if(!String.IsNullOrEmpty(nextClassName) && !String.IsNullOrEmpty(firstClassName)
                                && firstClassName.Equals(nextClassName))
                            {
                                classNameStr = firstClassName;
                            }
                            ANodeFilter aNodeFilter = new ANodeFilter(classNameStr,preFix);
                            task.addInfoNodeFilter(aNodeFilter);
                            task.addKeyWord("标题");
                            task.addKeyWord("url");
                            isMakeRule = false;
                        }
                        else
                        {
                            firstHrefStr = elem.GetAttribute("href");
                            firstClassName = elem.GetAttribute("className");
                            MessageBox.Show("请再选择一个链接标签，来生成识别规则！", "提示"); //前后顺序，否则认证失败
                            isMakeRule = true;
                        }  
                    }
                    //非A标签
                    else
                    {
                        //展示： 添加一行数据
                        int t = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[t].Cells["getdata"].Value = elem.InnerText;
                        //扒取： 获取节点特征
                        String className = elem.GetAttribute("className");
                        ClassNodeFilter filter = new ClassNodeFilter(elem.TagName,className);
                        task.addInfoNodeFilter(filter);
                        task.addKeyWord("标题");
                        task.addKeyWord("");
                    }               
                }
            }
            String netUrl = neturlview.Text.ToString();
            webview.Navigate(netUrl);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    task.removeInfoNodeFilter(e.RowIndex);
                    task.removeKeyWord(e.RowIndex * 2 + 1);
                    task.removeKeyWord(e.RowIndex * 2);  //移除顺序很重要
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);//删除当前行

                    for(int i=0; i < task.getKeyWord().Count; i++)
                    {
                        Console.WriteLine("当前关键字： " + task.getKeyWord().ElementAt(i));
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (task != null)
            {
                task.TaskTyped = Task.TaskType.FirstType;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (task != null)
            {
                task.TaskTyped = Task.TaskType.secondType;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (task != null)
            {
                task.TaskTyped = Task.TaskType.ThirdType;
            }
        }

        private Boolean isBind = false;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //判断要处理的DataGridViewComboBoxColumn名称，若符合条件，编辑控件被强制转换为ComboBox以处理，添加SelectedIndexChanged事件
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == "showtype")
            {
                if (!isBind)
                {
                    ((ComboBox)e.Control).SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                    isBind = true;
                }
            }
        }

        /// <summary>
        /// SelectedIndexChanged事件触发时需要进行的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            task.changeKeyWord(this.dataGridView1.CurrentRow.Index * 2, ((ComboBox)sender).Text);
        }

        private Boolean isSelectingNextPage = false;
        private void neednextpageview_CheckedChanged(object sender, EventArgs e)
        {
            if (neednextpageview.Checked)
            {
                MessageBox.Show("请点击选择下一页标识","提示");
                isSelectingNextPage = true;
            }
            else
            {
                isSelectingNextPage = false;
                task.NextPagerFilter = null;
                next_input1.Text = "";
                next_input2.Text = "";
            }
        }
        #region 数据导出
        //导出到数据库
        
        private void button14_Click(object sender, EventArgs e)
        {
            //判断有无数据
            if(dataGridView2.Rows.Count < 1)
            {
                MessageBox.Show("无数据可导出！","提示");
                return;
            }
            
            //获取关键字
            DatabaseHelper.getInstance().KeyWord = task.getKeyWord();
            //获取扒取得数据
            DatabaseHelper.getInstance().Contents = outputDatas(dataGridView2);

            ExportDataBase1 exportDataBase1 = new ExportDataBase1();
            exportDataBase1.Show();
        }
        public List<List<String>> outputDatas(DataGridView dataGridView)
        {
            int rowNum = dataGridView.Rows.Count;
            int colNum = dataGridView.Columns.Count;
            List<List<String>> tables = new List<List<string>>();
            for (int i = 0; i < rowNum; i++)
            {
                List<String> row = new List<string>();
                for (int j = 0; j < colNum; j++)
                {
                    row.Add(dataGridView.Rows[i].Cells[j].Value as String);
                }
                tables.Add(row);
            }
            return tables;
        }
        //导出TXT
        ExportOperation exportOperation = new ExportOperation();
        private void button12_Click(object sender, EventArgs e)
        {
            exportOperation.dataGridViewTOTxt(dataGridView2);
        }
        //导出到Excel
        private void button13_Click(object sender, EventArgs e)
        {

        }
        #endregion
        //网站右击
        private void websiteRightClick_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                CurtainNodeText = treeView1.SelectedNode.Text;
                ParentNodeText = treeView1.SelectedNode.Parent.Text;
            }
           
        }

        //编辑网站
        //private Control _CurtainControl;
        private String CurtainNodeText;
        private String ParentNodeText;
        private void editWebsite_Click(object sender, EventArgs e)
        {
            //获取当前任务的参数内容
            if (CurtainNodeText != null&& ParentNodeText!=null)
            {
                //String WebsiteName = _CurtainControl.Text;
                //DataBaseManager dataManager = DataBaseManager.getInstance();
                DataTable dt = dataManager.getCurtainWebsite(CurtainNodeText, ParentNodeText);
                WebsiteForm websiteForm = new WebsiteForm(dt);
                websiteForm.Show();
            }
            else
            {
                MessageBox.Show("您未选中任何网站，无法进行编辑，请先选中要编辑的网站", "提示");
                return;
            }

        }
       
       
        //删除网站
        private void deleteWebsite_Click(object sender, EventArgs e)
        {
            //获取当前任务的参数内容
            if (CurtainNodeText != null)
            {
                //DataBaseManager dataManager = DataBaseManager.getInstance();
                DataTable dt = dataManager.getCurtainWebsite(CurtainNodeText, ParentNodeText);
                Boolean result = dataManager.deleteWebsite(dt.Rows[0]["id"] as String);
                if (result)
                {
                    new WebsiteOpeartion().refresh(treeView1);
                }
                else
                {
                    MessageBox.Show("无法删除","提示");
                }
            }
            else
            {
                MessageBox.Show("您未选中任何网站，无法进行编辑，请先选中要编辑的网站", "提示");
                return;
            }
        }
        //网站组右键
        private void websiteGroup_Opening(object sender, CancelEventArgs e)
        {

            if (treeView1.SelectedNode != null)
            {
                CurtainNodeText = treeView1.SelectedNode.Text;
            }
        }
        //新增网站
        private void creatWebsite_Click(object sender, EventArgs e)
        {
            WebsiteForm websiteForm = new WebsiteForm();
            websiteForm.GroupNodeText = CurtainNodeText;
            websiteForm.Show();
            new WebsiteOpeartion().refresh(treeView1);
        }
        //编辑分组
        private void editWebsiteGroup_Click(object sender, EventArgs e)
        {
            if (CurtainNodeText != null)
            {
                //DataBaseManager dataManager = DataBaseManager.getInstance();
                DataTable dt = dataManager.getCurtainWebGroup(CurtainNodeText);
                WebsiteGroup websiteGroup = new WebsiteGroup(dt);
                websiteGroup.Show();
            }
            else
            {
                MessageBox.Show("请选中要编辑的分组", "提示");
                return;
            }
            
        }
        //创建分组
        private void creatWebsiteGroup_Click(object sender, EventArgs e)
        {
            WebsiteGroup websiteGroup = new WebsiteGroup();
            websiteGroup.Show();
            new WebsiteOpeartion().refresh(treeView1);
        }
        //删除分组
        private void deleteWebsiteGroup_Click(object sender, EventArgs e)
        {
            //获取当前任务的参数内容
            if (CurtainNodeText != null)
            {
                //DataBaseManager dataManager = DataBaseManager.getInstance();
                DataTable dt = dataManager.getCurtainWebGroup(CurtainNodeText);
                Boolean result = dataManager.deleteWebGroup(dt.Rows[0]["id"] as String);
                if (result)
                {
                    new WebsiteOpeartion().refresh(treeView1);
                }
                else
                {
                    MessageBox.Show("无法删除", "提示");
                }
            }
        }
        //刷新
        private void websiteGroupRefresh_Click(object sender, EventArgs e)
        {
            new WebsiteOpeartion().refresh(treeView1);
        }
        //点击空白处时的刷新
        private void websiteBlankRefresh_Click(object sender, EventArgs e)
        {
            new WebsiteOpeartion().refresh(treeView1);
        }

        private void createWebsiteGroup_Click(object sender, EventArgs e)
        {
            creatWebsiteGroup_Click(sender, e);
        }
        /// <summary>
        /// 任务分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //获取contextMenuStrip是点击什么控件触发的
        private void taskGroup_Opening(object sender, CancelEventArgs e)
        {
            CurtainNodeText = treeView1.SelectedNode.Text;
           
            // _CurtainControl = taskGroup.SourceControl;
        }
        private void createtask_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void creatTaskGroup1_Click(object sender, EventArgs e)
        {
            TaskGroup taskGroup = new TaskGroup();
            taskGroup.Show();
            new TaskOperation().refresh(treeView1);
        }

        private void importTaskGroup_Click(object sender, EventArgs e)
        {

        }

        private void exportTaskGroup_Click(object sender, EventArgs e)
        {

        }
        //删除任务分组
        private void deleteTaskGroup_Click(object sender, EventArgs e)
        {
            //获取当前任务的参数内容
            if (CurtainNodeText != null)
            {
                DataTable dt = dataManager.getCurtainTaskGroup(CurtainNodeText);
                Boolean result = dataManager.deleteTaskGroup(dt.Rows[0]["id"] as String);
                if (result)
                {
                    new TaskOperation().refresh(treeView1);
                }
                else
                {
                    MessageBox.Show("无法删除", "提示");
                }
            }
        }
        //修改任务组
        private void editTaskGroup_Click(object sender, EventArgs e)
        {
            if (CurtainNodeText != null)
            {
                DataTable dt = dataManager.getCurtainWebGroup(CurtainNodeText);
                TaskGroup taskGroup = new TaskGroup(dt);
                taskGroup.Show();
            }
            else
            {
                MessageBox.Show("请选中要编辑的分组", "提示");
                return;
            }
        }
        //
        private void taskGroupRefresh_Click(object sender, EventArgs e)
        {

        }
        //空白处的刷新
        private void taskBlankRefresh_Click(object sender, EventArgs e)
        {
            new TaskOperation().refresh(treeView1);
        }
        //空白处创建任务分组
        private void createTaskgroup_Click(object sender, EventArgs e)
        {
            creatTaskGroup1_Click(sender, e);
        }

        private void taskRightClick_Opening(object sender, CancelEventArgs e)
        {
            CurtainNodeText = treeView1.SelectedNode.Text;
            // _CurtainControl = taskGroup.SourceControl;
        }
        //搜索框
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                String keyword = textBox1.Text;
                if (keyword == null || keyword.Trim().Equals(""))
                {
                    MessageBox.Show("请输入搜索关键词", "提示");
                    return;
                }
                String curtainGroupBox = textBox1.Parent.Text;
                if (curtainGroupBox == "网站管理")
                {
                    DataTable dt = dataManager.searchwebsite(keyword);
                    new WebsiteOpeartion().refresh(treeView1, dt);
                }
                else if (curtainGroupBox == "我的任务")
                {
                    //TODO
                }
            }     
        }
        //工具栏的创建人物分组
        private void createTaskGroup1_Click(object sender, EventArgs e)
        {
            creatTaskGroup1_Click(sender, e);
        }
        #region 右上角的用户管理模块
        //点击下拉框的弹出
        private void exit_Click(object sender, EventArgs e)
        {
            dataManager.CurrentUserName = null;//解除用户绑定
            //userManager.Text = "登录";
            //userManager.ToolTipText = "点击进行登录";
            InitUserManager();
        }

        //点击标题
        private void userManager_ButtonClick(object sender, EventArgs e)
        {
            String curtaInuserStatus = userManager.Text;
            if (curtaInuserStatus == "登录")
            {
                loginForm login = new loginForm();
                login.Show();
                InitUserManager();
            }
        }
        #endregion
        //tabpage2上新建一个分组
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            creatTaskGroup1_Click(sender, e);
        }

        private void userSetting_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close();
        }
    }
}
