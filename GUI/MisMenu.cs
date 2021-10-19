using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_Tech.GUI
{
    public partial class MisMenu : Form
    {
        public MisMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee s = new Employee();
            this.Hide();
            s.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users s = new Users();
            this.Hide();
            s.ShowDialog();
        }
    }
}
