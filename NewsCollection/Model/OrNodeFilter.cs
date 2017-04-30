using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;

namespace NetSpider.Filter
{
    class OrNodeFilter:OrFilter
    {
        public OrNodeFilter(NodeFilter[] filters)
        {
            this.Predicates = filters;
        }
    }
}
