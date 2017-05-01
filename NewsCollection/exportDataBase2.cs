using NewsCollection.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection
{
    public partial class exportDataBase2 : Form
    {
        public exportDataBase2()
        {
            InitializeComponent();
            initDatas();
        }

        private void initDatas()
        {
            //绑定数据
            List<String> keyWord = DatabaseHelper.getInstance().KeyWord;
            int len = keyWord.Count;
            for(int i = 0; i < len; i++)
            {
                int rowNum = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowNum].Cells["originfieldcolumns"].Value = keyWord.ElementAt(i);
            }
            
            // 列出所有的表名
            List<String> tables = DatabaseHelper.getInstance().queryAllTableName();
            tables_comboBox.Items.Clear();
            tables_comboBox.Items.AddRange(tables.ToArray());
            tables_comboBox.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExportDataBase3 exportDataBase3 = new ExportDataBase3();
            exportDataBase3.Show();
        }

        private Dictionary<String, String> tableinfo;
        private void tables_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //更新界面的表格的显示
            DatabaseHelper.getInstance().TableName = tables_comboBox.SelectedItem as String;
            tableinfo =  DatabaseHelper.getInstance().getTableInfo();
            DataGridViewComboBoxColumn TablefieldColumn = dataGridView1.Columns[2] as DataGridViewComboBoxColumn;
            TablefieldColumn.Items.Clear();
            TablefieldColumn.Items.AddRange(tableinfo.Keys.ToArray());
        }

        private Boolean isBind = false;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //判断要处理的DataGridViewComboBoxColumn名称，若符合条件，编辑控件被强制转换为ComboBox以处理，添加SelectedIndexChanged事件
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == "fieldcolumns")
            {
                if (!isBind)
                {
                    ((ComboBox)e.Control).SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                    isBind = true;
                }
            }
        }

        /// <summary>
        /// SelectedIndexChanged事件触发时需要进行的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //task.changeKeyWord(this.dataGridView1.CurrentRow.Index, ((ComboBox)sender).Text);
            string value = "";
            tableinfo.TryGetValue(((ComboBox)sender).Text,out value);
            dataGridView1.CurrentRow.Cells[3].Value = value;
        }
    }
}
