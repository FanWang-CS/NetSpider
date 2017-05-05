using NetSpider.Filter;
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
        private OrNodeFilter orFilter;
        //字段类型
        private List<String> keyWords = new List<string>();
        //深度迭代过滤器
        private NodeFilter nextPagerFilter;

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
        public NodeFilter NextPagerFilter { get => nextPagerFilter; set => nextPagerFilter = value; }
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
            orFilter = new OrNodeFilter(infoNodeFilters.ToArray()); 
            showDataGridView.Columns.Clear();  //清空DataGridView数据
            if (keyWords != null && keyWords.Count() > 0)
            {
                int size = keyWords.Count();
                for (int i = 0; i < size; i++)
                {
                    
                    showDataGridView.Columns.Add(keyWords.ElementAt(i) + i, keyWords.ElementAt(i) + i); //初始化展示控件
                }
            }
            // webLoader.Url = new Uri(neturl);
            //webLoader.Refresh();
            webLoader.Navigate(neturl);
        }

        /// <summary>
        /// 获取页面的源码
        /// </summary>
        private void getHtmlContent(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!String.IsNullOrEmpty(webLoader.DocumentText))
            {
                int keywordCount = keyWords.Count;
                htmlParser.InputHTML = webLoader.DocumentText;
                NodeList nodes = htmlParser.Parse(orFilter);
                if (nodes != null && nodes.Size() > 0)
                {
                    int pairs = nodes.Size() / keywordCount;
                    for (int i = 0; i < pairs; i++)
                    {
                        List<String> values = new List<string>();
                        for (int j = 0; j < keywordCount; j++)
                        {
                            values.Add(nodes[i * keywordCount + j].FirstChild.GetText());
                        }
                        showDataGridView.Rows.Add(values.ToArray());
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
                        Console.WriteLine("新网址为：" + newUrl);
                        //webLoader.Url = new Uri(newUrl);
                        //webLoader.Refresh();
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
    }
}
