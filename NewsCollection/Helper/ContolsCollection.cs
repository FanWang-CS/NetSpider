using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection.Helper
{
    class ContolsCollection
    {
        //定义主界面tabpage中的的标签
        private Label _palnGroupLabel = new Label();//“任务组”
        private Label _planNoteLabel = new Label();//备注
        private Label _webSiteLabel = new Label();//“采集网站”

        //定义主界面tabpage中的按钮
        //private Button _

        //定义主界面tabpage中的下拉框
        public Label palnGroupLabel
        {
            get
            {
                _palnGroupLabel.Text = "任务组";
                return _palnGroupLabel;
            }
        }
    }
}
