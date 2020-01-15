using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2WoodSide3190.objects;
using _2WoodSide3190.dbAccess;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace _2WoodSide3190.gui
{
    public partial class AddChild : Form
    {
        //Private variables declared. db used to connect to the SQL Database, table used to edit the grid
        private Database db;
        private DataTable table;
        //Private varaibles declared, used to modify data later on in the program
        private int ChildId;
        private int ParentId;
        private int SchoolId;
        private string ChildName;
        private string SelectedTable;

        private string MedicalDetails;
        private int Age;

        //This piece of code makes the edges curved
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
int nLeftRect,     // x-coordinate of upper-left corner
int nTopRect,      // y-coordinate of upper-left corner
int nRightRect,    // x-coordinate of lower-right corner
int nBottomRect,   // y-coordinate of lower-right corner
int nWidthEllipse, // height of ellipse
int nHeightEllipse // width of ellipse
);

        //Constrcutor. db is passed in and so is the selected Parent ID from the last form
        public AddChild(Database db, int _ParentId)
        {
            //Set the form in the centre of the screen, make the borders flat, make the edges curved
            InitializeComponent();
            CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //Make the db object from the previous form in this form. This is so it can be accessed in the below methods 
            this.db = db;
            //Initalize the combobox and fill it with data
            initComboBox();
            //The selected ID from the previous form is passed in
            parentId.Text = _ParentId.ToString();
        }

        //Initalizes and fills the combobox with these items
        public void initComboBox()
        {
            comboBox1.Items.Add("Child Name");
            comboBox1.Items.Add("Age");
            comboBox1.Items.Add("Show All");
            comboBox1.Items.Add("School Name");
        }
        //Create a new entry in the table using the entered data
        private void button1_Click(object sender, EventArgs e)
        {
            //Try to fill these variables using the data the user enters into the textboxes
            
            
                int ParentId = Convert.ToInt32(parentId.Text);
                int SchoolId = Convert.ToInt32(schoolId.Text);
                string ChildName = childName.Text;
                string MedicalDetails = medicalDetails.Text;
                int Age = Convert.ToInt32(age.Text);
            
            //Try populating a new entry with entered data
            try
            { 
                ChildrenDBAccess chDBA = new ChildrenDBAccess(db);
                chDBA.InsertChild(ParentId, SchoolId, ChildName, MedicalDetails, Age);
                this.Hide();
                //If it works, display the success form with the childs name
                new SuccessForm(db, ChildName + "\nSuccesfully Registered").Show();
            }
            //If there's an error, show the exact error on the ErrorForm
            catch (SqlException ex)
            {
                new ErrorBox(ex).Show();
            }
}

        //This takes the user back to the main application
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }



        private void button3_Click(object sender, EventArgs e)
        {

            //shows the data for the Child table which matches the searched for Child name
            if (comboBox1.Text == "Child Name")
            {
                ChildrenDBAccess cdba = new ChildrenDBAccess(db);
                string name = searchBox.Text;
                createTableShowAll(cdba.GetChildByName(name));
            }
            //shows the data for the Child table which matches the searched for child age
            else if (comboBox1.Text == "Age")
            {
                ChildrenDBAccess cdba = new ChildrenDBAccess(db);
                string name = searchBox.Text;
                createTableShowAll(cdba.GetChildByAge("=", name));
            }
            //Shows all the data for the Child table when the 'View' button is clicked 
            else if (comboBox1.Text == "Show All")
            {
                ChildrenDBAccess cdba = new ChildrenDBAccess(db);
                createTableShowAll(cdba.GetAllChildren());
                SelectedTable = "Child";
            }
            //Shows all the data for the School table which matches the searched for school name 
            else if (comboBox1.Text == "School Name")
            {
                string name = searchBox.Text;
                SchoolDBAccess scdba = new SchoolDBAccess(db);
                createTableShowAllSchools(scdba.getSchoolByName(name));
            }
        }

        //formats the table to show all the Child entries in the database
        private void createTableShowAll(List<objects.Children> list)
        {
            table = new DataTable();
            table.Columns.Add("Child ID");
            table.Columns.Add("Parent ID");
            table.Columns.Add("School ID");
            table.Columns.Add("Child Name");
            table.Columns.Add("Medical Details");
            table.Columns.Add("Age");
            SelectedTable = "Child";
            foreach (Children child in list)
            {
                table.Rows.Add(child.ChildId, child.ParentId, child.SchoolId, child.ChildName, child.MedicalDetails, child.Age);
                childResults.DataSource = table;
            }
            childResults.DataSource = table;
        }

        //when the modify data button is clicked, the highlighted entry will be changed in the database to whatever the user has entered into the grid

        private void button4_Click(object sender, EventArgs e)
        {
            ChildrenDBAccess cdba = new ChildrenDBAccess(db);
            cdba.updateProject(ChildId, ParentId, SchoolId, ChildName, MedicalDetails, Age);
            MessageBox.Show("The row in the database has been updated.", "Success");
            childResults.DataSource = null;
        }


        private void childResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ///This allows data to be modified. Whenever a row is clicked; the data in that row is passed into a variable which can then be used to modify the database entries

            //If the table is curerntly showing the data for children
            if (SelectedTable == "Child")
            {
                int index = e.RowIndex;
                try
                {

                    //Change the variables to whatever row the user has selected
                    DataGridViewRow selectedRow = childResults.Rows[index];
                    ChildId = int.Parse(selectedRow.Cells[0].Value.ToString());
                    ParentId = int.Parse(selectedRow.Cells[1].Value.ToString());
                    SchoolId = int.Parse(selectedRow.Cells[2].Value.ToString());
                    ChildName = selectedRow.Cells[3].Value.ToString();
                    MedicalDetails = selectedRow.Cells[4].Value.ToString();
                    Age = int.Parse(selectedRow.Cells[5].Value.ToString());
                }
                catch { }
            }
            //If the table is currently showing the data for School
            else if (SelectedTable == "School")
            {
                int index = e.RowIndex;
                try
                {
                    DataGridViewRow selectedRow = childResults.Rows[index];

                    int _schoolId = int.Parse(selectedRow.Cells[0].Value.ToString());
                    schoolId.Text = _schoolId.ToString();
                }
                catch { }
            }
            //If the table is currently showing the data for parents
            else if (SelectedTable == "Parent")
            {
                int index = e.RowIndex;
                try
                {
                    DataGridViewRow selectedRow = childResults.Rows[index];

                    int _parentId = int.Parse(selectedRow.Cells[0].Value.ToString());
                    parentId.Text = _parentId.ToString();
                }
                catch { }
            }
        }




        //When the label is clicked, the table will update to show all the data for schools
        private void label1_Click(object sender, EventArgs e)
        {
            SchoolDBAccess sdba = new SchoolDBAccess(db);
            createTableShowAllSchools(sdba.getAllSchools());
        }

        //formats the table to show all the Schools entries in the database
        private void createTableShowAllSchools(List<objects.Schools> list)
        {
            SelectedTable = "School";
            table = new DataTable();
            table.Columns.Add("School ID:");
            table.Columns.Add("School Name:");
            table.Columns.Add("School Location:");
            table.Columns.Add("School Address");
            table.Columns.Add("School Number");
            table.Columns.Add("School Email:");

            foreach (Schools school in list)
            {
                table.Rows.Add(school.SchoolId, school.SchoolName, school.SchoolLocation, school.SchoolAddress, school.SchoolNumber, school.SchoolEmail);
                childResults.DataSource = table;
            }
            childResults.DataSource = table;
        }


        //When the label is clicked, the table will update to show all the data for parents

        private void label7_Click(object sender, EventArgs e)
        {
            ParentDBAccess pdba = new ParentDBAccess(db);
            createTableShowAllParents(pdba.SelectAllParents());
        }

        //formats the table to show all the Schools entries in the database
        private void createTableShowAllParents(List<objects.Parent> list)
        {
            SelectedTable = "Parent";
            table = new DataTable();
            table.Columns.Add("Parent ID");
            table.Columns.Add("Parent Name");
            table.Columns.Add("Parent Phone");
            table.Columns.Add("Parent Email");
            table.Columns.Add("Parent Town");
            table.Columns.Add("Parent Occupation");

            foreach (Parent parent in list)
            {

                table.Rows.Add(parent.ParentId, parent.ParentName, parent.ParentPhone, parent.ParentEmail, parent.ParentAddress, parent.ParentOccupation);
                childResults.DataSource = table;

            }
            childResults.DataSource = table;

        }

        private void childResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //When the picture is clicked, the explain screen will appear
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new ExplainScreen().Show();
        }

        private void busBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BusBookingForm(db).Show();
        }

        private void bookAPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BookingForm(db).Show();
        }

        private void childToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddChild(db, 0).Show();
        }

        private void parentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddAParent(db).Show();
        }

        private void busToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddABus(db).Show();
        }

        private void schoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddASchool(db).Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddStaff(db).Show();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellForm(db).Show();
        }

        private void childToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddChild(db, 0).Show();
        }

        private void parentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddAParent(db).Show();
        }

        private void staffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddStaff(db).Show();
        }

        private void busToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddABus(db).Show();
        }

        private void schoolToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddASchool(db).Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HelpForm(db).Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ReportForm(db).Show();

        }

        private void viewCancellationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellationTable(db).Show();
        }
    }
}

