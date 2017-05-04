using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection.Helper
{
    class WebBrowserHelper
    {
        public static void InjectAlertBlocker(WebBrowser webview)
        {
            HtmlElement head = webview.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = webview.Document.CreateElement("script");
            mshtml.IHTMLScriptElement element = (mshtml.IHTMLScriptElement)scriptEl.DomElement;
            string alertBlocker = "window.alert = function () { }";
            element.text = alertBlocker;
            head.AppendChild(scriptEl);
            webview.ScriptErrorsSuppressed = true;
        }
    }
}
