using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Tags;

namespace NewsCollection.Model
{
    class ANodeFilter : NodeFilter
    {
        private String className;
        private String hrefPrefix; 
        public ANodeFilter(String className , String hrefPrefix)
        {
            this.className = className;
            this.hrefPrefix = hrefPrefix;
        }

        public bool Accept(INode node)
        {
            if(node != null && node is ITag)
            {
                ITag linkTag = node as ITag;
                if (linkTag.TagName.Equals("A"))
                {
                    if(className != null)
                    {
                        if(linkTag.GetAttribute("class") == null || !linkTag.GetAttribute("class").Equals(className))
                        {
                            return false;
                        }
                    }
                    if(linkTag.GetAttribute("href") != null && linkTag.GetAttribute("href").StartsWith(hrefPrefix) && !linkTag.GetAttribute("href").Contains("?"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
