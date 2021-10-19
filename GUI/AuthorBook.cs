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
using Hi_TechLibrary.Business;
using Hi_TechLibrary.DataAccess;
using Hi_TechLibrary.VALIDATION;


namespace Hi_Tech.GUI
{
    public partial class AuthorBooksForm: Form
    {
        SqlDataAdapter da;
        DataSet dsAuthorBookDB;
        DataTable dtAuthorBook;
        SqlCommandBuilder sqlBuilder;
        AuthorBook aAuthorBook = new AuthorBook();
        public AuthorBooksForm()
        {
            InitializeComponent();
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = dtAuthorBook.NewRow();
            dr["AuthorID"] = Convert.ToInt32(authorBookIDtextBox.Text.Trim());
            dr["ISBN"] = Convert.ToInt32(iSBNAthorBook.Text.Trim());
            dr["YearPublished"] = Convert.ToInt32(PublisherIdtextbox.Text.Trim());
            dr["Edition"] = Convert.ToInt32(edition.Text.Trim());
            dtAuthorBook.Rows.Add(dr);
            da.Update(dsAuthorBookDB.Tables["AuthorBooks"]);
            MessageBox.Show("New Edition has been Added successfully.", "Confirmation");



        }

        private void AuthorBookscs_Load(object sender, EventArgs e)
        {
            dsAuthorBookDB = new DataSet("AuthorBookDB");
            dtAuthorBook = new DataTable("AuthorBooks");
            dsAuthorBookDB.Tables.Add(dtAuthorBook);
            dtAuthorBook.Columns.Add("AuthorId", typeof(Int32));
            dtAuthorBook.Columns.Add("ISBN", typeof(Int32));
            dtAuthorBook.Columns.Add("YearPublished", typeof(Int32));
            dtAuthorBook.Columns.Add("Edition", typeof(Int32));

            dtAuthorBook.PrimaryKey = new DataColumn[] { dtAuthorBook.Columns["AuthorId"] };

            da = new SqlDataAdapter("SELECT * FROM AuthorBooks", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchId = AuthorBooktextBoxCat.Text.Trim();
            MessageBox.Show("Do you want to Update the Book Edition Information", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            DataRow dr = dtAuthorBook.Rows.Find(Convert.ToInt32(searchId));

            dr["YearPublished"] = PublisherIdtextbox.Text.Trim();
            dr["Edition"] = edition.Text.Trim();
            da.Update(dsAuthorBookDB.Tables["AuthorBooks"]);
            MessageBox.Show("Edition has been Updated successfully.", "Confirmation");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string searchId = AuthorBooktextBoxCat.Text.Trim();
            DataRow dr = dtAuthorBook.Rows.Find(Convert.ToInt32(searchId));

            if (dr != null)
            {
                authorBookIDtextBox.Text = dr["AuthorId"].ToString();
                iSBNAthorBook.Text = dr["ISBN"].ToString();
                PublisherIdtextbox.Text = dr["YearPublished"].ToString();
                edition.Text = dr["Edition"].ToString();
            }
            else
            {
                MessageBox.Show("The Edition ID does not exists!, please Check Your Information", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchId = AuthorBooktextBoxCat.Text.Trim();
            MessageBox.Show("Do you want to Delete the Author Book", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            DataRow dr = dtAuthorBook.Rows.Find(Convert.ToInt32(searchId));
            dr.Delete();
            da.Update(dsAuthorBookDB.Tables["AuthorBooks"]);
            MessageBox.Show("Database has been updated successfully.", "Confirmation");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            da.Fill(dsAuthorBookDB.Tables["AuthorBooks"]);
            dataGridView6.DataSource = dsAuthorBookDB.Tables["AuthorBooks"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryControllerMenu mainMenuForm = new InventoryControllerMenu();
            mainMenuForm.ShowDialog();
        }
    }
}
