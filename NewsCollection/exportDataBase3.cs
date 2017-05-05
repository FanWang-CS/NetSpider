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
    public partial class ExportDataBase3 : Form
    {
        private exportDataBase2 exportDataBase2;

        public ExportDataBase3(exportDataBase2 exportDataBase2)
        {
            this.exportDataBase2 = exportDataBase2;
            InitializeComponent();
        }

        //上一步
        private Boolean isClickBtn2Close = false;
        private void button1_Click(object sender, EventArgs e)
        {
            isClickBtn2Close = true;
            this.Close();
        }

        //下一步
        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseHelper.getInstance().outputData2DB(showBox);
            button2.Enabled = false;
        }

        //取消
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void ExportDataBase3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClickBtn2Close)
            {
                exportDataBase2.Show();
            }
            else
            {
                exportDataBase2.Close();
            }
        }
    }
}
