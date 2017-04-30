using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;

namespace NewsCollection.Model
{
    class ClassInnerTextNodeFilter : NodeFilter
    {
        private String tagName;
        private String innerText;

        public ClassInnerTextNodeFilter(String tagName,String innerText)
        {
            this.tagName = tagName;
            if (innerText.EndsWith(">"))
            {
                innerText = innerText.Substring(0, innerText.Length - 1);
            }
            this.innerText = innerText;
        }
        public bool Accept(INode node)
        {
           if(node is ITag)
            {
                ITag tag = node as ITag;
                if (tag.TagName.Equals(tagName) && tag.FirstChild != null && tag.FirstChild.GetText().StartsWith(innerText)){
                    return true;
                }
            }
            return false;
        }
    }
}
