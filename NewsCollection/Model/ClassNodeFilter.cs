using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;

namespace NewsCollection.Model
{
    /// <summary>
    /// 根据class值过滤
    /// </summary>
    class ClassNodeFilter : NodeFilter
    {
        private String tagName;
        private String className;
        public ClassNodeFilter(String tagname , String classname)
        {
            this.TagName = tagname;
            this.ClassName = classname;
        }

        public string ClassName { get => className; set => className = value; }
        public string TagName { get => tagName; set => tagName = value; }

        public bool Accept(INode node)
        {
            if (node != null && node is ITag)
            {
                ITag tag = node as ITag;
                String getClassName = tag.GetAttribute("class");
                if (tag.TagName.Equals(TagName) && getClassName != null && getClassName.Equals(ClassName))
                {
                    return true;
                }
            }
            return false;
        }

        //转字符串
        public override string ToString()
        {
            return "1|" + tagName + "|" + className;
        }
    }
}
