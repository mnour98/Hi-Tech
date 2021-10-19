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
    public partial class InventoryControllerMenu : Form
    {
        public InventoryControllerMenu()
        {
            InitializeComponent();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Bookform bookForm = new Bookform();
            this.Hide();
            bookForm.ShowDialog();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm categoryform = new CategoryForm();
            this.Hide();
            categoryform.ShowDialog();
        }

        private void publisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublisherForm publisherForm = new PublisherForm();
            this.Hide();
            publisherForm.ShowDialog();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorForm authorForm = new AuthorForm();
            this.Hide();
            authorForm.ShowDialog();
        }

        private void authorBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorBooksForm authorBooksForm = new AuthorBooksForm();
            this.Hide();
            authorBooksForm.ShowDialog();
        }
    }
}
