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
        private String className;
        public ClassNodeFilter(String classname)
        {
            this.className = classname;
        }

        public bool Accept(INode node)
        {
            if (node is ITag)
            {
                ITag tag = node as ITag;
                String getClassName = tag.GetAttribute("class");
                if (getClassName != null && getClassName.Equals(className))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
