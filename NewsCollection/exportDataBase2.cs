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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            exportDataBase3 exportDataBase3 = new exportDataBase3();
            exportDataBase3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
