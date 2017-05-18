using NewsCollection.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection.Operation
{
    class BindOperation
    {
        DataBaseManager dataManager = DataBaseManager.getInstance();
        //为选择任务组和选择网站组绑定数据处绑定数据
        public void bindGroupSelection(ComboBox combobox, DataTable dt)
        {
            
            combobox.DataSource = dt;
            combobox.DisplayMember = "title";
            combobox.ValueMember = "id";
        }
        //为网站下拉框绑定数据
        public void bindwebsiteSelection(ComboBox combobox, DataTable dt)
        {
            combobox.DataSource = dt;
            combobox.DisplayMember = "title";
            combobox.ValueMember = "url";
        }
    }
}
