using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;

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
        private List<NodeFilter> infoNodeFilter = new List<NodeFilter>();
        //深度迭代过滤器
        private NodeFilter nextPagerFilter;

        private Boolean needNextPage;

        public Task(String taskname, String taskdesc,String groupname)
        {
            this.taskname = taskname;
            this.taskdesc = taskdesc;
            this.groupname = groupname;
        }

        public void addInfoNodeFilter(NodeFilter nodefilter)
        {
            infoNodeFilter.Add(nodefilter);
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
            Parser htmlParser = new Parser();

            List<List<String>> table = new List<List<String>>();
            //foreach(NodeFilter)

        }
    }
}
