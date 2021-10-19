using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hi_TechLibrary.DataAccess;
using Hi_TechLibrary.Business;
using Hi_TechLibrary.VALIDATION;

namespace Hi_Tech.GUI
{
    public partial class SalesManger : Form
    {
        SqlDataAdapter da;
        DataSet dsHitTech;
        DataTable dtCustomers;
        SqlCommandBuilder sqlBuilder;
        Customer aCustomer = new Customer();


        public SalesManger()
        {
            InitializeComponent();
        }

        private void SalesManger_Load(object sender, EventArgs e)
        {
            dsHitTech = new DataSet("HitTechDs");

           
            dtCustomers = new DataTable("Customers");
            dsHitTech.Tables.Add(dtCustomers);
           

            dtCustomers.Columns.Add("CustomerId", typeof(Int32));
            dtCustomers.Columns.Add("CustomerName", typeof(string));
            dtCustomers.Columns.Add("PhoneNumber", typeof(Int32));
          
            dtCustomers.Columns.Add("Email", typeof(string));
            dtCustomers.Columns.Add("FaxNumber", typeof(Int32));
            dtCustomers.Columns.Add("StreetName", typeof(string));
            dtCustomers.Columns.Add("City", typeof(string));
            dtCustomers.Columns.Add("PosalCode", typeof(string));
            dtCustomers.Columns.Add("CreditLimt", typeof(Int32));


            dtCustomers.Columns["CustomerId"].AutoIncrement = true;
           
            dtCustomers.PrimaryKey = new DataColumn[] { dtCustomers.Columns["CustomerId"] };

            da = new SqlDataAdapter("SELECT * FROM Customers", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da);


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempId = textBox1.Text.Trim();
            if (!(Validator.IsValidIdd(tempId)))
            {
                MessageBox.Show("Cusomer ID must be 5-digit number", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }


            int cusId = Convert.ToInt32(textBox1.Text);
            DataRow drCustomer = dtCustomers.Rows.Find(cusId);
            if (drCustomer != null)
            {
                MessageBox.Show("This customer ID Aleady exist", "Duplicate Customer ID");
                textBox1.Clear();
                textBox1.Focus();
                return;



            }

            string tempIdd = textBox10.Text.Trim();
            if (!(Validator.IsValidIddd(tempIdd)))
            {
                MessageBox.Show("Candian postal Code", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox10.Clear();
                textBox10.Focus();
                return;
            }



           

            string fxcu = textBox3.Text.Trim();
            if (!(Validator.IsValidIddnumber(fxcu)))
            {
                MessageBox.Show("Cusomer Fax must be 10-digit number", "Invalid Fax", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Clear();
                textBox3.Focus();
                return;
            }

          


            string custFirstName = textBox2.Text.Trim();
            if (!(Validator.IsValidName(custFirstName)))
            {
                MessageBox.Show("Invalid First Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
                return;
            }



       



           

    




            DataRow dr = dtCustomers.NewRow();
            dr["CustomerId"] = Convert.ToInt32(textBox1.Text.Trim());
            dr["CustomerName"] = textBox2.Text.Trim();
            dr["PhoneNumber"] = Convert.ToInt32(textBox5.Text.Trim());

            dr["Email"] = textBox6.Text.Trim();
            dr["FaxNumber"] = textBox3.Text.Trim();
            dr["StreetName"] = textBox7.Text.Trim();
            dr["City"] = textBox8.Text.Trim();
            dr["PosalCode"] = textBox10.Text.Trim();
            dr["CreditLimt"] = Convert.ToInt32(textBox4.Text.Trim());

            dtCustomers.Rows.Add(dr);
            MessageBox.Show(dr.RowState.ToString());

           

        }

        private void buttonListStudentFromDS_Click(object sender, EventArgs e)
        {
            da.Fill(dsHitTech.Tables["Customers"]);
            dataGridViewStudentDS.DataSource = dsHitTech.Tables["Customers"];


        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            da.Update(dsHitTech.Tables["Customers"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBox1.Text.Trim());
            DataRow drCustomer = dtCustomers.Rows.Find(searchId);
            drCustomer.Delete();
            MessageBox.Show(drCustomer.RowState.ToString());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {


            int searchId = Convert.ToInt32(textBox1.Text.Trim());
            DataRow drCustomer = dtCustomers.Rows.Find(searchId);
            if (drCustomer != null)
            {
                textBox1.Text = drCustomer["CustomerId"].ToString();
                textBox2.Text = drCustomer["CustomerName"].ToString();
                textBox5.Text = drCustomer["PhoneNumber"].ToString();
                textBox6.Text = drCustomer["Email"].ToString();
                textBox3.Text = drCustomer["FaxNumber"].ToString();
                textBox7.Text = drCustomer["StreetName"].ToString();
                textBox8.Text = drCustomer["City"].ToString();
                textBox10.Text = drCustomer["PosalCode"].ToString();
                textBox4.Text = drCustomer["CreditLimt"].ToString();
            }
            else
            {
                MessageBox.Show("Student not found!", "Invalid Student ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            




        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
