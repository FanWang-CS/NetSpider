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
    public partial class exportDataBase1 : Form
    {
        DataPanel dataPanel = new DataPanel();
        Panel settingPanel = new Panel();
        public exportDataBase1()
        {
           
            InitializeComponent();
            this.comboBox2.SelectedIndex = 0;
            String dataType = (String)comboBox2.SelectedItem;
            settingPanel = dataPanel.getPanel(dataType);
            settingPanel.Location = new Point(6, 14);
            groupBox3.Controls.Add(settingPanel);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox3.Controls.Remove(settingPanel);
            String dataType = (String)comboBox2.SelectedItem;
            settingPanel=dataPanel.getPanel(dataType);
            settingPanel.Location=new Point(6, 14);
            groupBox3.Controls.Add(settingPanel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            exportDataBase2 exportDataBase2 = new exportDataBase2();
            exportDataBase2.Show();
        }

        private void exportDataBase1_Load(object sender, EventArgs e)
        {

        }
    }
}
