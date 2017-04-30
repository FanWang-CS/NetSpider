using NewsCollection.Model;
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

        public MainForm()
        {
            InitializeComponent();
            //button7.Top = panel1.Bottom + 20;
            //button8.Top = panel1.Bottom + 20;
        }

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
                treeView1.Nodes.Clear();
                //四种新闻类型
                TreeNode tn1 = treeView1.Nodes.Add("通知公告");
                TreeNode tn2 = treeView1.Nodes.Add("新闻资讯");
                TreeNode tn3 = treeView1.Nodes.Add("行业动态");
                TreeNode tn4 = treeView1.Nodes.Add("法规政策");
                TreeNode tn5 = treeView1.Nodes.Add("图文消息");
                //
                TreeNode Ntn1 = new TreeNode("湖南计量院");
                TreeNode Ntn2 = new TreeNode("湖南质监局");
                tn1.Nodes.Add(Ntn1);
                tn1.Nodes.Add(Ntn2);

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
                //四种新闻类型
                TreeNode tn1 = treeView1.Nodes.Add("通知公告");
                TreeNode tn2 = treeView1.Nodes.Add("新闻资讯");
                TreeNode tn3 = treeView1.Nodes.Add("行业动态");
                TreeNode tn4 = treeView1.Nodes.Add("法规政策");
                //
                TreeNode Ntn1 = new TreeNode("湖南计量院");
                TreeNode Ntn2 = new TreeNode("湖南质监局");
                tn1.Nodes.Add(Ntn1);
                tn1.Nodes.Add(Ntn2);

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

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (treeView1.Parent.Text == "网站管理")
            {
                treeView1.ContextMenuStrip = 网站右键空白处contextMenuStrip6;

                TreeNode selectNode = treeView1.GetNodeAt(e.X, e.Y);
                if (selectNode.Level == 0)
                {
                    treeView1.ContextMenuStrip = 网站分组右键contextMenuStrip4;
                }
                else if (selectNode.Level == 1)

                {
                    treeView1.ContextMenuStrip = 网站右键contextMenuStrip1;
                }
            }
            else if (treeView1.Parent.Text == "我的任务")
            {
                treeView1.ContextMenuStrip = 任务右击空白contextMenuStrip7;

                TreeNode selectNode = treeView1.GetNodeAt(e.X, e.Y);

                if (selectNode.Level == 0)

                {
                    treeView1.ContextMenuStrip = 任务分组右键contextMenuStrip2;
                }
                else if (selectNode.Level == 1)

                {
                    treeView1.ContextMenuStrip = 任务右键contextMenuStrip3;
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
                            MessageBox.Show("任务名不能为空");
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
                        webview.Url = new Uri(netUrl);
                        webview.Refresh();
                        task.NetUrl = netUrl;
                        webview.Visible = true;
                        break;
                    case 2://规则
                        break;
                    case 3:  //选择采集方式
                        task.execute(dataGridView2);
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
            if (!isBindDocumentClick)
            {
                webview.Document.Click += onWebViewNodeClicked;
                isBindDocumentClick = true;
            }
        }

        private void onWebViewNodeClicked(object sender, HtmlElementEventArgs e)
        {
           
            String netUrl = neturlview.Text.ToString();
            webview.Url = new Uri(netUrl);
            webview.Refresh();
            if (webview.Document != null)
            {
                HtmlElement elem = webview.Document.GetElementFromPoint(e.ClientMousePosition);

                if (isSelectingNextPage)
                {
                    //选择结点
                    task.NextPagerFilter = new ClassInnerTextNodeFilter(elem.TagName, elem.InnerText);
                    next_input1.Text = "识别标签：" + elem.TagName;
                    next_input2.Text = "识别文本：" + elem.InnerText;
                    isSelectingNextPage = false;
                }
                else
                {
                    while (String.IsNullOrEmpty(elem.GetAttribute("className")))
                    {
                        elem = elem.Parent;
                        if (elem == null)
                        {
                            return;
                        }
                    }
                    elem.ScrollIntoView(true);
                    //展示： 添加一行数据
                    int t = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[t].Cells["getdata"].Value = elem.InnerText;

                    //扒取： 获取节点特征
                    String className = elem.GetAttribute("className");
                    ClassNodeFilter filter = new ClassNodeFilter(className);

                    Console.WriteLine("节点属性" + className);

                    task.addInfoNodeFilter(filter);
                    task.addKeyWord("标题");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    task.removeInfoNodeFilter(e.RowIndex);
                    task.removeKeyWord(e.RowIndex);
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);//删除当前行
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
            task.changeKeyWord(this.dataGridView1.CurrentRow.Index, ((ComboBox)sender).Text);
            //DataGridViewComboBoxCell combocell = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[1];
            //String value = (String)combocell.Value;
            //Console.WriteLine("change = " + value);
        }

        private Boolean isSelectingNextPage = false;
        private void neednextpageview_CheckedChanged(object sender, EventArgs e)
        {
            if (neednextpageview.Checked)
            {
                MessageBox.Show("请点击选择下一页标识");
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
    }
}
