using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hi_TechLibrary.Business;
using Hi_TechLibrary.DataAccess;


  namespace Hi_Tech.GUI
{
    public partial class LogIn : Form
    {
        
        public LogIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User astudent = new User();
            astudent.UserId = Convert.ToInt32(textBox1.Text.Trim());
            astudent.Password = textBox2.Text.Trim();
            astudent.CheckUser(astudent.UserId, astudent.Password);


            if (astudent.CheckUser(astudent.UserId, astudent.Password) != null)
            {
                if (astudent.UserId == 1111 && astudent.Password == "henryb")
                {
                    MessageBox.Show("Hello MIS Manager!");
                    MisMenu frmRegistarion = new MisMenu();

                    frmRegistarion.ShowDialog();


                    this.Hide();



                }
                else if(astudent.UserId == 2222 && astudent.Password == "thomas")
                {
                    MessageBox.Show("Hello Sales Managerr!");
                    SalesManger frmRegistarion = new SalesManger();

                    frmRegistarion.ShowDialog();


                    this.Hide();

                }

                else if (astudent.UserId == 3333 && astudent.Password == "peterw")
                {
                    MessageBox.Show("Hello Inventory Controller!");
                    InventoryControllerMenu frmRegistarion = new InventoryControllerMenu();

                    frmRegistarion.ShowDialog();


                    this.Hide();

                }








            }
            else 
            {
                MessageBox.Show("Invalid password");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
