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
    public partial class AuthorForm : Form
    {
        SqlDataAdapter da;
        DataSet dsAuthorDB;
        DataTable dtAuthor;
        SqlCommandBuilder sqlBuilder;
        Author aAuthor = new Author(); 
        public AuthorForm()
        {
            InitializeComponent();
        }

        private void Author_Load(object sender, EventArgs e)
        {
            dsAuthorDB = new DataSet("AuthorDB");
            dtAuthor = new DataTable("Authors");
            dsAuthorDB.Tables.Add(dtAuthor);
            dtAuthor.Columns.Add("AuthorId", typeof(Int32));
            dtAuthor.Columns.Add("FirstName", typeof(string));
            dtAuthor.Columns.Add("LastName", typeof(string));
            dtAuthor.Columns.Add("Email", typeof(string));

            dtAuthor.PrimaryKey = new DataColumn[] { dtAuthor.Columns["AuthorId"] };

            da = new SqlDataAdapter("SELECT * FROM Authors", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = dtAuthor.NewRow();
            dr["AuthorId"] = Convert.ToInt32(authorIDtextBox.Text.Trim());
            dr["FirstName"] = firstNameAuthor.Text.Trim();
            dr["LastName"] = latNameAuthor.Text.Trim();
            dr["Email"] = emailAuthor.Text.Trim();
            dtAuthor.Rows.Add(dr);
            da.Update(dsAuthorDB.Tables["Authors"]);
            MessageBox.Show("New Author has been Added successfully.", "Confirmation");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchId = AuthortextBoxCat.Text.Trim();
            MessageBox.Show("Do you wanr to Update the Author Information", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            DataRow dr = dtAuthor.Rows.Find(Convert.ToInt32(searchId));

            dr["FirstName"] = firstNameAuthor.Text.Trim();
            dr["LastName"] = latNameAuthor.Text.Trim();
            dr["Email"] = emailAuthor.Text.Trim();
            da.Update(dsAuthorDB.Tables["Authors"]);
            MessageBox.Show("Author has been Updated successfully.", "Confirmation");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchId = AuthortextBoxCat.Text.Trim();
            MessageBox.Show("You are going to Delete the Current Author", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            DataRow dr = dtAuthor.Rows.Find(searchId);
            dr.Delete();
            da.Update(dsAuthorDB.Tables["Authors"]);
            MessageBox.Show("Database has been updated successfully.", "Confirmation");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string searchId = AuthortextBoxCat.Text.Trim();
            DataRow dr = dtAuthor.Rows.Find(Convert.ToInt32(searchId));

            if (dr != null)
            {
                authorIDtextBox.Text = dr["AuthorId"].ToString();
                firstNameAuthor.Text = dr["FirstName"].ToString();
                latNameAuthor.Text = dr["LastName"].ToString();
                emailAuthor.Text = dr["Email"].ToString();
            }
            else
            {
                MessageBox.Show("The Author ID does not exists!, please Check Your Information", "Error");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            da.Fill(dsAuthorDB.Tables["Authors"]);
            dataGridView4.DataSource = dsAuthorDB.Tables["Authors"];
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryControllerMenu mainMenuForm = new InventoryControllerMenu();
            mainMenuForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
