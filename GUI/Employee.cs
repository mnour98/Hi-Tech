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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Employees emp = new Employees();
            List<Employees> listEmp = emp.ListEmployees();
            listView1.Items.Clear();
            if (listEmp.Count != 0)
            {
                foreach (Employees anEmp in listEmp)
                {
                    ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                    item.SubItems.Add(anEmp.FirstName);
                    item.SubItems.Add(anEmp.LastName);
                    item.SubItems.Add(anEmp.Phone.ToString());


                    item.SubItems.Add(anEmp.Email);
                    item.SubItems.Add(anEmp.JobId.ToString());
                    listView1.Items.Add(item);
                }

            }
            else
            {
                MessageBox.Show("Empty List!", "No Employee");
            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            string msg = UtilityDB.ConnectDB().State.ToString(); 
            MessageBox.Show(msg, "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            //Step 1 : Data validation
            string tempId = textBoxId.Text.Trim();
            if (!(Validator.IsValidId(tempId)))
            {
                MessageBox.Show("Employee ID must be 4-digit number", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxId.Clear();
                textBoxId.Focus();
                return;
            }



           

             Employees tempEmp = new Employees();
            tempEmp = tempEmp.SearchEmployee(Convert.ToInt32(textBoxId.Text.Trim()));
            if (tempEmp != null)
            {
                MessageBox.Show("This Employee ID already exists!", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxId.Clear();
                textBoxId.Focus();
                return;
            }

          



            string tempFirstName = textBoxFirstName.Text.Trim();
            if (!(Validator.IsValidName(tempFirstName)))
            {
                MessageBox.Show("Invalid First Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            string tempLastName = textBoxLatName.Text.Trim();
            if (!(Validator.IsValidName(tempLastName)))
            {
                MessageBox.Show("Invalid Last Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLatName.Clear();
                textBoxLatName.Focus();
                return;
            }

           

           

            Employees emp = new Employees();
            emp.EmployeeId = Convert.ToInt32(textBoxId.Text.Trim());
            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLatName.Text.Trim();
            emp.Phone = Convert.ToInt32(phonetextBox.Text.Trim());
            emp.Email = emailtextBox2.Text.Trim();
            emp.JobId = Convert.ToInt32(textBoxId.Text.Trim());

            emp.SaveEmployee(emp);
            MessageBox.Show("Employee data saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            emp.EmployeeId = Convert.ToInt32(textBoxId.Text.Trim());
            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLatName.Text.Trim();
            emp.Phone = Convert.ToInt32(phonetextBox.Text.Trim());
            emp.Email = emailtextBox2.Text.Trim();
            emp.JobId = Convert.ToInt32(textBoxId.Text.Trim());

            DialogResult answer = MessageBox.Show("Do you really want to update this employee info? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
            {
                emp.UpdateEmployee(emp);
            }


        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int indexSelected = comboBoxOption.SelectedIndex;

            switch (indexSelected)
            {
                case 0: 

                    break;
                case 1:
                    
                    Employees emp = new Employees();
                    List<Employees> listEmp = emp.SearchEmployee(textBoxInput1.Text.ToString());
                    listView1.Items.Clear();
                    if (listEmp.Count != 0)
                    {
                        foreach (Employees anEmp in listEmp)
                        {
                            ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                            item.SubItems.Add(anEmp.FirstName);
                            item.SubItems.Add(anEmp.LastName);
                            item.SubItems.Add(anEmp.Phone.ToString());
                            item.SubItems.Add(anEmp.Email);
                            item.SubItems.Add(anEmp.JobId.ToString());
                            listView1.Items.Add(item);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Employee not found!", "Error");
                    }
                    break;
                case 2:
                    
                    Employees emp2 = new Employees();
                    List<Employees> listEmp2 = emp2.SearchEmployee(textBoxInput1.Text.Trim());
                    listView1.Items.Clear();
                    if (listEmp2.Count != 0)
                    {
                        foreach (Employees anEmp in listEmp2)
                        {
                            ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                            item.SubItems.Add(anEmp.FirstName);
                            item.SubItems.Add(anEmp.LastName);
                            item.SubItems.Add(anEmp.Phone.ToString());
                            item.SubItems.Add(anEmp.Email);
                            item.SubItems.Add(anEmp.JobId.ToString());
                            listView1.Items.Add(item);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Employee not found!", "Error");
                    }
                    break;

                default:
                    break;


            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int empId = Convert.ToInt32(textBoxId.Text.Trim());
            Employees emp = new Employees();
            if (emp != null)
            {
                DialogResult answer = MessageBox.Show("Do you really want to delete this employee? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (answer == DialogResult.Yes)
                {
                    emp.DeleteUser(empId);


                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MisMenu misMenu = new MisMenu();
            misMenu.ShowDialog();
        }
    }
}
