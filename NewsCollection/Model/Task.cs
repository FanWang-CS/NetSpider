using NetSpider.Filter;
using NewsCollection.Dao;
using NewsCollection.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Nodes;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;

namespace NewsCollection.Model
{
    //任务列表
    class Task
    {
        // 任务展示枚举
        public enum TaskType
        {
            FirstType, secondType, ThirdType
        }
        //任务属性
        private String taskname;
        private String taskdesc;
        private String groupname;
        private TaskType taskType = TaskType.FirstType;

        //任务执行目标
        private String neturl;

        //提取过滤器
        private List<NodeFilter> infoNodeFilters = new List<NodeFilter>();
        //private OrNodeFilter orFilter;
        //字段类型
        private List<String> keyWords = new List<string>();
        //深度迭代过滤器
        private ClassInnerTextNodeFilter nextPagerFilter;

        private Boolean needNextPage;

        //页面加载器

        private WebBrowser webLoader;
        private Parser htmlParser;


        public Task(String taskname, String taskdesc, String groupname)
        {
            this.taskname = taskname;
            this.taskdesc = taskdesc;
            this.groupname = groupname;
            webLoader = new WebBrowser();
            webLoader.DocumentCompleted += getHtmlContent;
            webLoader.Navigated += AutoComfirmDialog;
            htmlParser = new Parser();
        }

        private void AutoComfirmDialog(object sender, WebBrowserNavigatedEventArgs e)
        {
            WebBrowserHelper.InjectAlertBlocker(webLoader);
        }

        public void addInfoNodeFilter(NodeFilter nodefilter)
        {
            infoNodeFilters.Add(nodefilter);
        }

        public void removeInfoNodeFilter(int index)
        {
            if (index >= 0 && index < infoNodeFilters.Count())
            {
                infoNodeFilters.RemoveAt(index);
            }
        }

        public void addKeyWord(String keyword)
        {
            keyWords.Add(keyword);
        }

        public void removeKeyWord(int index)
        {
            if (index >= 0 && index < keyWords.Count())
            {
                keyWords.RemoveAt(index);
            }
        }

        public void changeKeyWord(int index,String keyword)
        {
            if (index >= 0 && index < keyWords.Count())
            {
                keyWords.RemoveAt(index);
                keyWords.Insert(index, keyword);
            }
        }

        public List<string> getKeyWord()
        {
            return keyWords;
        }

        public string TaskName { get => taskname; set => taskname = value; }
        public string GroupName { get => groupname; set => groupname = value; }
        public string TaskDesc { get => taskdesc; set => taskdesc = value; }
        public string NetUrl { get => neturl; set => neturl = value; }
        public ClassInnerTextNodeFilter NextPagerFilter { get => nextPagerFilter; set => nextPagerFilter = value; }
        public bool NeedNextPage { get => needNextPage; set => needNextPage = value; }
        internal TaskType TaskTyped { get => taskType; set => taskType = value; }


        private DataGridView showDataGridView;
        private Button nextBtn;
        /// <summary>
        /// 执行任务
        /// </summary>
        public void execute(DataGridView datagridview, Button button)
        {
            Console.WriteLine("执行任务");
            showDataGridView = datagridview;
            nextBtn = button;
            nextBtn.Visible = false;
           // orFilter = new OrNodeFilter(infoNodeFilters.ToArray()); 
            showDataGridView.Columns.Clear();  //清空DataGridView数据
            if (keyWords != null && keyWords.Count() > 0)
            {
                int size = keyWords.Count();
                for (int i = 0; i < size; i++)
                {
                    if (!String.IsNullOrEmpty(keyWords.ElementAt(i)))
                    {
                        DataGridViewTextBoxColumn Column = new DataGridViewTextBoxColumn();
                        Column.Name = i + "";
                        Column.DataPropertyName = i + "";
                        Column.HeaderText = keyWords.ElementAt(i);
                        showDataGridView.Columns.Add(Column); //初始化展示控件
                    }
                }
            }
            webLoader.Navigate(neturl);
        }

        /// <summary>
        /// 获取页面的源码
        /// </summary>
        private void getHtmlContent(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!String.IsNullOrEmpty(webLoader.DocumentText))
            {
                int filterCount = infoNodeFilters.Count;
                List<List<String>> table = new List<List<string>>();
                for(int i = 0; i < filterCount; i++)
                {
                    Console.WriteLine("开始扒取内容,当前执行 fliter" + i);
                    NodeFilter filter = infoNodeFilters.ElementAt(i);
                    htmlParser.InputHTML = webLoader.DocumentText;
                    NodeList nodeList = htmlParser.Parse(filter);
                    Console.WriteLine("符合要求的节点数：" + nodeList.Count);
                    if (nodeList != null && nodeList.Count > 0)
                    {
                        int nodeCount = nodeList.Count;
                        if(filter is ANodeFilter)
                        {
                            List<String> textinfo = new List<String>();
                            List<String> linkinfo = new List<String>();
                            for(int j = 0; j < nodeCount; j++)
                            {
                                ITag linkTag = nodeList.ElementAt(j) as ITag;
                                textinfo.Add(linkTag.FirstChild.GetText());
                                linkinfo.Add(linkTag.GetAttribute("href"));
                                Console.WriteLine(linkTag.FirstChild.GetText() + "  --->  " + linkTag.GetAttribute("href"));
                            }
                            table.Add(textinfo);
                            table.Add(linkinfo);
                        }
                        else
                        {
                            List<String> textinfo = new List<string>();
                            for (int j = 0; j < nodeCount; j++)
                            {
                                textinfo.Add(nodeList.ElementAt(j).FirstChild.GetText());
                                Console.WriteLine(nodeList.ElementAt(j).FirstChild.GetText());
                            }
                            table.Add(textinfo);
                        }
                    }
                }
                int tableCount = table.Count;
                //刷新显示
                if (tableCount > 0)
                {
                    List<int> columnsCounts = new List<int>();
                    foreach(List<String> column in table)
                    {
                        columnsCounts.Add(column.Count);
                    }
                    int maxPoint = columnsCounts.Min();  //最短列,保证表格对齐
                    for(int i = 0; i < maxPoint; i++)
                    {
                        List<String> row = new List<string>();
                        for(int j = 0; j < tableCount; j++)
                        {
                            row.Add(table.ElementAt(j).ElementAt(i));
                        }
                        showDataGridView.Rows.Add(row.ToArray());
                    }
                }
                //获取下一页的网址
                if(nextPagerFilter != null){
                    htmlParser.InputHTML = webLoader.DocumentText;
                    NodeList nextpageNodes = htmlParser.Parse(nextPagerFilter);
                    Console.WriteLine("过滤的结点数有：" + nextpageNodes.Count);
                    if (nextpageNodes != null && nextpageNodes.Count > 0)
                    {
                        ITag tag = nextpageNodes[0] as ITag;
                        String newUrl = tag.GetAttribute("href");
                        if (!newUrl.StartsWith("http"))
                        {
                            newUrl = neturl + newUrl.Substring(newUrl.IndexOf("?"));
                        }
                        webLoader.Navigate(newUrl);
                    }
                    else
                    {
                        nextBtn.Visible = true;
                    }
                }
                else
                {
                    nextBtn.Visible = true;
                }
            }
        }

        //保存到数据库
        //public void save2DB()
        //{
        //    StringBuilder filterStr = new StringBuilder();
        //    StringBuilder keywordStr = new StringBuilder();
        //    int len = keyWords.Count;
        //    if(len > 0)
        //    {
        //        for(int i = 0; i < len; i++)
        //        {
        //            filterStr.Append(infoNodeFilters.ElementAt(i).ClassName + "|");
        //            keywordStr.Append(keyWords.ElementAt(i) + "|");
        //        }
        //        filterStr.Remove(filterStr.Length - 1, 1);
        //        keywordStr.Remove(keywordStr.Length - 1, 1);
        //    }
            
        //    DataBaseManager.getInstance().saveTask(taskname,taskdesc, groupname, neturl,
        //                                            nextPagerFilter == null ? "": nextPagerFilter.TagName + "|" + nextPagerFilter.InnerText,
        //                                            filterStr.ToString(),
        //                                            keywordStr.ToString());
        //}

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static Task loadTask()
        {

            return null;
        }
    }
}
