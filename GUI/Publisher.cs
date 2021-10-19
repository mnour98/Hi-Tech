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
    public partial class PublisherForm : Form
    {
        SqlDataAdapter da;
        DataSet dsPublisherDB;
        DataTable dtPublisher;
        SqlCommandBuilder sqlBuilder;
        Publisher publisher = new Publisher();

        public PublisherForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = dtPublisher.NewRow();
            dr["PublisherID"] = Convert.ToInt32(publisherIdtextBox.Text.Trim());
            dr["PublisherName"] = publisherNametextBox.Text.Trim();
            dr["Website"] = wenAddressteaxBox.Text.Trim();
            dtPublisher.Rows.Add(dr);
            da.Update(dsPublisherDB.Tables["Publishers"]);
            MessageBox.Show("New Publisher has been Added successfully.", "Confirmation");
        }

        private void Publisher_Load(object sender, EventArgs e)
        {
            dsPublisherDB = new DataSet("PublisherDB");
            dtPublisher = new DataTable("Publishers");
            dsPublisherDB.Tables.Add(dtPublisher);
            dtPublisher.Columns.Add("PublisherId", typeof(Int32));
            dtPublisher.Columns.Add("PublisherName", typeof(string));
            dtPublisher.Columns.Add("Website", typeof(string));


            dtPublisher.PrimaryKey = new DataColumn[] { dtPublisher.Columns["PublisherId"] };

            da = new SqlDataAdapter("SELECT * FROM Publishers", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            da.Fill(dsPublisherDB.Tables["Publishers"]);
            dataGridView3.DataSource = dsPublisherDB.Tables["Publishers"];
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string searchId = publisherSearchtextBox.Text.Trim();
            DataRow dr = dtPublisher.Rows.Find(Convert.ToInt32(searchId));

            if (dr != null)
            {
                publisherIdtextBox.Text = dr["PublisherId"].ToString();
                publisherNametextBox.Text = dr["PublisherName"].ToString();
                wenAddressteaxBox.Text = dr["Website"].ToString();

            }
            else
            {
                MessageBox.Show("The Publisher ID does not exists!, please Check Your Information", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchId = publisherSearchtextBox.Text.Trim();
            MessageBox.Show("Do you want to Update the Publisher Information", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            DataRow dr = dtPublisher.Rows.Find(Convert.ToInt32(searchId));

            dr["PublisherName"] = publisherNametextBox.Text.Trim();
            dr["Website"] = wenAddressteaxBox.Text.Trim();
            da.Update(dsPublisherDB.Tables["Publishers"]);
            MessageBox.Show("Publisher has been Updated successfully.", "Confirmation");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchId = publisherSearchtextBox.Text.Trim();
            MessageBox.Show("Do you want to Delete the Current Publisher", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            DataRow dr = dtPublisher.Rows.Find(Convert.ToInt32(searchId));
            dr.Delete();
            da.Update(dsPublisherDB.Tables["Publishers"]);
            MessageBox.Show("Database has been updated successfully.", "Confirmation");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryControllerMenu mainMenuForm = new InventoryControllerMenu();
            mainMenuForm.ShowDialog();
        }
    }
}
