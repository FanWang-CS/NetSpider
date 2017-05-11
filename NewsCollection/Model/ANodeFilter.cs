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
        private String hrefPrefix; 
        public ANodeFilter(String hrefPrefix)
        {
            this.hrefPrefix = hrefPrefix;
        }

        public bool Accept(INode node)
        {
            if(node != null && node is LinkTag)
            {
               LinkTag linkTag = node as LinkTag;
                if (linkTag.Link != null && linkTag.Link.StartsWith(hrefPrefix))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
