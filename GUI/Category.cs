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
    public partial class CategoryForm : Form
    {

        SqlDataAdapter da;
        DataSet dsCategoryDB;
        DataTable dtCategory;
        SqlCommandBuilder sqlBuilder;
        Category aCategory = new Category();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            dsCategoryDB = new DataSet("CategoryDB");
            dtCategory = new DataTable("Categories");
            dsCategoryDB.Tables.Add(dtCategory);
            dtCategory.Columns.Add("CategoryId", typeof(Int32));
            dtCategory.Columns.Add("CategoryName", typeof(string));

            dtCategory.PrimaryKey = new DataColumn[] { dtCategory.Columns["CategoryId"] };

            da = new SqlDataAdapter("SELECT * FROM Categories", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da);
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void categorId_TextChanged(object sender, EventArgs e)
        {

        }

        private void categoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = dtCategory.NewRow();
            dr["CategoryId"] = Convert.ToInt32(categorIdtextBox.Text.Trim());
            dr["CategoryName"] = categoryName.Text.Trim();
            dtCategory.Rows.Add(dr);
            da.Update(dsCategoryDB.Tables["Categories"]);
            MessageBox.Show("New Category has been Added successfully.", "Confirmation");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchId = searchtextBoxCat.Text.Trim();
            MessageBox.Show("Do you want to  Update the Category Information?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            DataRow dr = dtCategory.Rows.Find(Convert.ToInt32(searchId));

            dr["CategoryName"] = categoryName.Text.Trim();
            da.Update(dsCategoryDB.Tables["Categories"]);
            MessageBox.Show("Category has been Updated successfully.", "Confirmation");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            da.Fill(dsCategoryDB.Tables["Categories"]);
            dataGridView2.DataSource = dsCategoryDB.Tables["Categories"];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string searchId = searchtextBoxCat.Text.Trim();
            DataRow dr = dtCategory.Rows.Find(Convert.ToInt32(searchId));

            if (dr != null)
            {
                categorIdtextBox.Text = dr["CategoryId"].ToString();
                categoryName.Text = dr["CategoryName"].ToString();
            }
            else
            {
                MessageBox.Show("The Category ID does not exists!, please Check Your Information", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchId = searchtextBoxCat.Text.Trim();
            MessageBox.Show("Do you want to Delete a category ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            DataRow dr = dtCategory.Rows.Find(Convert.ToInt32(searchId));
            dr.Delete();
            da.Update(dsCategoryDB.Tables["Categories"]);
            MessageBox.Show("Database has been updated successfully.", "Confirmation");
        }
    }
}
