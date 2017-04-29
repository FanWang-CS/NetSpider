using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Util;

namespace NewsCollection.Model
{
    //任务列表
    class Task
    {
        //任务属性
        private String taskname;
        private String taskdesc;
        //任务执行目标
        private String groupname;
        private String neturl;

        //提取过滤器
        private List<NodeFilter> infoNodeFilters = new List<NodeFilter>();
        //深度迭代过滤器
        private NodeFilter nextPagerFilter;

        private Boolean needNextPage;

        //页面加载器
        
        private WebBrowser webLoader;
        private Parser htmlParser;
        

        public Task(String taskname, String taskdesc,String groupname)
        {
            this.taskname = taskname;
            this.taskdesc = taskdesc;
            this.groupname = groupname;
            webLoader = new WebBrowser();
            webLoader.DocumentCompleted += null;
            htmlParser = new Parser();
        }

        public void addInfoNodeFilter(NodeFilter nodefilter)
        {
            infoNodeFilters.Add(nodefilter);
        }

        public void removeInfoNodeFilter(int index)
        {
            if(index >=0 && index < infoNodeFilters.Count())
            {
                infoNodeFilters.RemoveAt(index);
            }
        }


        public string TaskName { get => taskname; set => taskname = value; }
        public string GroupName { get => groupname; set => groupname = value; }
        public string TaskDesc { get => taskdesc; set => taskdesc = value; }
        public string NetUrl { get => neturl; set => neturl = value; }
        public NodeFilter NextPagerFilter { get => nextPagerFilter; set => nextPagerFilter = value; }
        public bool NeedNextPage { get => needNextPage; set => needNextPage = value; }

        /// <summary>
        /// 执行任务
        /// </summary>
        public void execute()
        {
            webLoader.Url = new Uri(neturl);
            webLoader.Refresh();
        }

        /// <summary>
        /// 获取页面的源码
        /// </summary>
        private List<List<String>> getHtmlContent(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (String.IsNullOrEmpty(e.ToString()))
            {
                List<List<String>> table = new List<List<String>>();
                htmlParser.InputHTML = e.ToString();
                foreach(NodeFilter filter in infoNodeFilters)
                {
                    NodeList nodes = htmlParser.Parse(filter); 
                    if(nodes != null && nodes.Size() > 0)
                    {
                        List<String> cols = new List<string>();
                        for(int i = nodes.Size() -1 ;i>= 0; i--)
                        {
                            cols.Add(nodes.ElementAt(i).FirstChild.GetText());
                        }
                        table.Add(cols);
                    }
                }
                return table;
            }
            return null;
            
        }
    }
}
