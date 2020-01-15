using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2WoodSide3190.dbAccess;
using _2WoodSide3190.objects;
using System.Runtime.InteropServices;

namespace _2WoodSide3190.gui
{
    public partial class AddASchool : Form
    {
        //Private variables declared. db used to connect to the SQL Database, table used to edit the grid
        private Database db;
        private DataTable table;
        //Private varaibles declared, used to modify data later on in the program
        private int schoolId;
        private string schoolName;
        private string schoolAddress;
        private string schoolNumber;
        private string schoolEmail;
        private string schoolLocation;

        //This piece of code makes the edges curved
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
int nLeftRect,
int nTopRect,
int nRightRect,
int nBottomRect,
int nWidthEllipse,
int nHeightEllipse
);
        //Constrcutor. db is passed in so the user can access the SQL Database
        public AddASchool(Database db)
        {
            //Set the form in the centre of the screen, make the borders flat, make the edges curved
            InitializeComponent();
            CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //Make the db object from the previous form in this form. This is so it can be accessed in the below methods 
            this.db = db;
            //Initalize the combobox and fill it with data
            inintComboBox();
        }

        //Create a new entry in the table using the entered data
        private void button1_Click(object sender, EventArgs e)
        {
            //Add whatever is in the textboxes to these variables
                string Name = schoolNameTXT.Text;
                string SchoolLocation = schoolLocationTXT.Text;
                string SchoolAddress = schoolAddressTXT.Text;
                int SchoolNumber = Convert.ToInt32(schoolNumberTXT.Text);
                string SchoolEmail = schoolEmailTXT.Text;


            //Populate a new entry using this data
            SchoolDBAccess sdba = new SchoolDBAccess(db);


                sdba.InsertSchool(Name, SchoolLocation, SchoolAddress, SchoolNumber, SchoolEmail);

            //If it works, display the success form with the childs name
            this.Hide();
                new SuccessForm(db, "New School: " + Name + "\nRegistered").Show();

        }

        //This takes the user back to the main application
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }

        //Initalizes and fills the combobox with these items
        public void inintComboBox() 
        {
            comboBox1.Items.Add("School Name");
            comboBox1.Items.Add("Location");
            comboBox1.Items.Add("Show All");
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //shows the data for the School table which matches the searched for School name
            if (comboBox1.Text == "School Name")
            {
                SchoolDBAccess sdba = new SchoolDBAccess(db);
                string name = searchBox.Text;
                createTableShowAll(sdba.getSchoolByName(name));
            }
            //shows the data for the School table which matches the searched for School Location
            else if (comboBox1.Text == "Location")
            {
                SchoolDBAccess sdba = new SchoolDBAccess(db);
                string location = searchBox.Text;
                createTableShowAll(sdba.getSchoolByLocation(location));
            }
            //Shows all the data for the School table when the 'View' button is clicked 
            else if (comboBox1.Text == "Show All")
            {
                SchoolDBAccess sdba = new SchoolDBAccess(db);
                createTableShowAll(sdba.getAllSchools());
            }
            //If there's a problem. Display an error message and return to the main menu
            else
            {
                MessageBox.Show("ERROR");
                this.Hide();
                new MainApp(db).Show();
            }
        }

        //formats the table to show all the School entries in the database        

        private void createTableShowAll(List<objects.Schools> list)
        {    
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
                schoolTable.DataSource = table;
            }
            schoolTable.DataSource = table;
        }

        //when the modify data button is clicked, the highlighted entry will be changed in the database to whatever the user has entered into the grid

        private void button4_Click(object sender, EventArgs e)
        {
            SchoolDBAccess sdba = new SchoolDBAccess(db);
            sdba.updateProject(schoolId, schoolName, schoolLocation, schoolAddress, schoolNumber, schoolEmail);
            MessageBox.Show("The row in the database has been updated.", "Success");
            schoolTable.DataSource = null;  
        }


        private void schoolTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ///This allows data to be modified. Whenever a row is clicked; the data in that row is passed into a variable which can then be used to modify the database entries

            try
            {
                int index = e.RowIndex;

                DataGridViewRow selectedRow = schoolTable.Rows[index];
                schoolId = int.Parse(selectedRow.Cells[0].Value.ToString());
                schoolName = selectedRow.Cells[1].Value.ToString();
                schoolLocation = selectedRow.Cells[2].Value.ToString();
                schoolAddress = selectedRow.Cells[3].Value.ToString();
                schoolNumber = selectedRow.Cells[4].Value.ToString();
                schoolEmail = selectedRow.Cells[5].Value.ToString();
            }
            catch { }
        }

        //If the question mark image is clicked, the explanation screen is displayed
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
