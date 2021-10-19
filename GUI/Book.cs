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
using Hi_TechLibrary.VALIDATION;
using System.Data.SqlClient;
namespace Hi_Tech.GUI
{
    public partial class Bookform : Form
    {
        SqlDataAdapter da;
        DataSet dsBookDB;
        DataTable dtBook;
        SqlCommandBuilder sqlBuilder;
        Book abook = new Book();
        
        public Bookform()
        {
            InitializeComponent();
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryControllerMenu mainMenuForm = new InventoryControllerMenu();
            mainMenuForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

     

            DataRow dr = dtBook.NewRow();
            dr["ISBN"] = Convert.ToInt32(iSBNtextBox.Text.Trim());
            dr["Title"] = bookTiltletextBox.Text.Trim();
            dr["QOH"] = Convert.ToInt32(textBoxQOH.Text.Trim());
            dr["Price"] = Convert.ToInt32(pricetextBox.Text.Trim());
            dr["CategoryID"] = Convert.ToInt32(categorIDtextBox.Text.Trim());
            dr["PublisherID"] = Convert.ToInt32(publisherIdtextBox.Text.Trim());

            dtBook.Rows.Add(dr);
            da.Update(dsBookDB.Tables["Books"]);
            MessageBox.Show("New Book has been Added successfully.", "Confirmation");
        }

        private void Bookform_Load(object sender, EventArgs e)
        {
            dsBookDB = new DataSet("BookDB");
            dtBook = new DataTable("Books");
            dsBookDB.Tables.Add(dtBook);
            dtBook.Columns.Add("ISBN", typeof(Int32));
            dtBook.Columns.Add("Title", typeof(string));
            dtBook.Columns.Add("QOH", typeof(Int32));
            dtBook.Columns.Add("Price", typeof(Int32));
            dtBook.Columns.Add("CategoryId", typeof(Int32));
            dtBook.Columns.Add("PublisherId", typeof(Int32));

            dtBook.PrimaryKey = new DataColumn[] { dtBook.Columns["ISBN"] };

            da = new SqlDataAdapter("SELECT * FROM Books", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchId = searchtextBox.Text.Trim();
           
            DataRow dr = dtBook.Rows.Find(Convert.ToInt32(searchId));

            dr["Title"] = bookTiltletextBox.Text.Trim();
            dr["QOH"] = Convert.ToInt32(textBoxQOH.Text.Trim());
            dr["Price"] = Convert.ToInt32(pricetextBox.Text.Trim());
            dr["CategoryID"] = Convert.ToInt32(categorIDtextBox.Text.Trim());
            dr["PublisherID"] = Convert.ToInt32(publisherIdtextBox.Text.Trim());
            da.Update(dsBookDB.Tables["Books"]);
            MessageBox.Show("Book has been Updated successfully.", "Confirmation");







        }

        private void button5_Click(object sender, EventArgs e)
        {
            da.Fill(dsBookDB.Tables["Books"]);
            dataGridView1.DataSource = dsBookDB.Tables["Books"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string searchId = searchtextBox.Text.Trim();
            DataRow dr = dtBook.Rows.Find(Convert.ToInt32(searchId));

            if (dr != null)
            {
                iSBNtextBox.Text = dr["ISBN"].ToString();
                bookTiltletextBox.Text = dr["Title"].ToString();
                textBoxQOH.Text = dr["QOH"].ToString();
                pricetextBox.Text = dr["Price"].ToString();
                categorIDtextBox.Text = dr["CategoryId"].ToString();
                publisherIdtextBox.Text = dr["PublisherId"].ToString();
            }
            else
            {
                MessageBox.Show("The Book ISBN does not exists!, please Check Your Information", "Error");
            }






        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchId = searchtextBox.Text.Trim();
            MessageBox.Show("Do you waant to Delete the book? ", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            DataRow dr = dtBook.Rows.Find(searchId);
            dr.Delete();
            da.Update(dsBookDB.Tables["Books"]);
            MessageBox.Show("Database has been updated successfully.", "Confirmation");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
