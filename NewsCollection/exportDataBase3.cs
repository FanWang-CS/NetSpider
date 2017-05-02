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
        public ExportDataBase3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatabaseHelper.getInstance().close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseHelper.getInstance().outputData2DB(showBox);
            DatabaseHelper.getInstance().close();
        }
    }
}
