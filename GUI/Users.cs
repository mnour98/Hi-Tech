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

namespace Hi_Tech.GUI
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string tempId = textBoxUserId.Text.Trim();
            if (!(Validator.IsValidId(tempId)))
            {
                MessageBox.Show("User ID must be 4-digit number", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }



            

            string tempFirstName = passwordtextbox.Text.Trim();
            if (!(Validator.IsValidName(tempFirstName)))
            {
                MessageBox.Show("Invalid First Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordtextbox.Clear();
                passwordtextbox.Focus();
                return;
            }

            string tempLastName = textBoxFirstNameUser.Text.Trim();
            if (!(Validator.IsValidName(tempLastName)))
            {
                MessageBox.Show("Invalid Last Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstNameUser.Clear();
                textBoxFirstNameUser.Focus();
                return;
            }

            string tempI = textBoxLatNameUsers.Text.Trim();
            if (!(Validator.IsValidId(tempId)))
            {
                MessageBox.Show("Employee ID must be 4-digit number", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLatNameUsers.Clear();
                textBoxLatNameUsers.Focus();
                return;
            }



            User use = new User();
            use.UserId = Convert.ToInt32(textBoxUserId.Text.Trim());
            use.Password = passwordtextbox.Text.Trim();
            use.UserStatus = textBoxFirstNameUser.Text.Trim();
            use.EmployeeId = Convert.ToInt32(textBoxLatNameUsers.Text.Trim());

     
            use.SaveUser(use);
            MessageBox.Show("User data saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void textBoxId_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User use = new User();
            use.UserId = Convert.ToInt32(textBoxUserId.Text.Trim());
            use.Password = passwordtextbox.Text.Trim();
            use.UserStatus = textBoxFirstNameUser.Text.Trim();
            use.EmployeeId = Convert.ToInt32(textBoxUserId.Text.Trim());
            DialogResult answer = MessageBox.Show("Do you really want to update this user info? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
            {
                use.UpdateUser(use);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            User lis = new User();
            List<User> listEmp = lis.ListUsers();
            listViewEmployee.Items.Clear();
            if (listEmp.Count != 0)
            {
                foreach (User anEmp in listEmp)
                {
                    ListViewItem item = new ListViewItem(anEmp.UserId.ToString());
                    item.SubItems.Add(anEmp.Password);
                    item.SubItems.Add(anEmp.UserStatus);
                    item.SubItems.Add(anEmp.EmployeeId.ToString());

                    listViewEmployee.Items.Add(item);
                    
                }

            }
            else
            {
                MessageBox.Show("Empty List!", "No User");
            }
        }

        private void listViewEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(textBoxUserId.Text.Trim());
            User use = new User();
            if (use != null)
            {
                DialogResult answer = MessageBox.Show("Do you really want to delete this employee? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (answer == DialogResult.Yes)
                {
                    use.DeleteUser(userId);


                }
            }


        }

        private void textBoxLatNameUsers_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            

            
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
            MisMenu misMenu = new MisMenu();
            misMenu.ShowDialog();
        }
    }
}
