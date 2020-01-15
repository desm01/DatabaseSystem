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
    public partial class AddStaff : Form
    {
        //Private variables declared. db used to connect to the SQL Database, table used to edit the grid
        private Database db;
        private DataTable table;
        //Private varaibles declared, used to modify data later on in the program
        private int _staffId;
        private string _staffName;
        private string _staffNumber;
        private string _staffAddress;
        private string _staffEmail;
        private bool _staffVoluntary;

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
        //Constrcutor. db is passed in
        public AddStaff(Database db)
        {
            //Set the form in the centre of the screen, make the borders flat, make the edges curved
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CenterToScreen();
            //Make the db object from the previous form in this form. This is so it can be accessed in the below methods 
            this.db = db;
            //Initalize the combobox and fill it with data
            initComboBox();
            comboBox2.Items.Add("False");
            comboBox2.Items.Add("True");
        }
        //Initalizes and fills the combobox with these items
        private void initComboBox() 
        {
            comboBox1.Items.Add("Staff Name");
            comboBox1.Items.Add("Voluntary");
            comboBox1.Items.Add("Show All");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //shows the data for the staff table which matches the searched for staff name
            if (comboBox1.Text == "Staff Name") 
        {
                StaffDBAccess sdba = new StaffDBAccess(db);
                string selectedName = searchBox.Text;
                createTable(sdba.GetStaffByName(selectedName));
        }
            //Shows all the data for the staff table when the 'View' button is clicked 
            if (comboBox1.Text == "Show All") 
            {
                StaffDBAccess sdba = new StaffDBAccess(db);
                createTable(sdba.getAllStaff());
            }
            //Shows the data for the staff table which mathes whether the the user is searching for voluntary or non-voluntary staff
            if (comboBox1.Text == "Voluntary") 
            {
                bool decider = false;
                StaffDBAccess sdba = new StaffDBAccess(db);
                switch (searchBox.Text) 
                {
                    case "False": decider = false; break;
                    case "True": decider = true; break;
                      
                }
                createTable(sdba.getStaffByVoluntary(decider));
            }
        }

        //formats the table to show all the Staff entries in the database
        private void createTable(List<objects.Staff> list)
        {
            table = new DataTable();
            table.Columns.Add("Staff ID");
            table.Columns.Add("Staff Name");
            table.Columns.Add("Staff Number");
            table.Columns.Add("Staff Address");
            table.Columns.Add("Staff Email");
            table.Columns.Add("Staff Voluntary");

            foreach (Staff staff in list)
            {
                table.Rows.Add(staff.StaffId, staff.StaffName, staff.StaffNumber, staff.StaffAddress, staff.StaffEmail, staff.StaffVoluntary);
                staffResults.DataSource = table;
            }
            staffResults.DataSource = table;
        }



        //This takes the user back to the main application
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }

        //Creates a new entry in the table using the entered data
        private void button1_Click(object sender, EventArgs e)
        {
            string StaffName = staffName.Text;
            string StaffNumber = staffNumber.Text;
            string StaffAddress = staffAddress.Text;
            string StaffEmail = staffEmail.Text;
            string StaffVoluntary = comboBox2.Text;
            int voluntary = 0; ;
            //Switch the string
            switch (StaffVoluntary)
            {
                //If it's false make voluntary = 0 OR if it's true make voluntary = 1
                case "False": voluntary = 0; break;
                case "True": voluntary = 1; break;
            }
            StaffDBAccess sdba = new StaffDBAccess(db);
        
            sdba.InsertStaff(StaffName, StaffNumber, StaffAddress, StaffEmail, voluntary);
            //Display a message saying succes
            new SuccessForm(db,StaffName).Show();
        }
        //when the modify data button is clicked, the highlighted entry will be changed in the database to whatever the user has entered into the grid

        private void button4_Click(object sender, EventArgs e)
        {
            StaffDBAccess sdba = new StaffDBAccess(db);

            sdba.updateProject(_staffId, _staffName, _staffNumber, _staffAddress, _staffEmail, _staffVoluntary);
            MessageBox.Show("The row in the database has been updated.", "Success");
            staffResults.DataSource = null;
        }

        private void staffResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }

        private void staffResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ///This allows data to be modified. Whenever a row is clicked; the data in that row is passed into a variable which can then be used to modify the database entries
            int index = e.RowIndex;

            DataGridViewRow selectedRow = staffResults.Rows[index];
            _staffId = int.Parse(selectedRow.Cells[0].Value.ToString());
            _staffName = selectedRow.Cells[1].Value.ToString();
            _staffNumber = selectedRow.Cells[2].Value.ToString();
            _staffAddress = selectedRow.Cells[3].Value.ToString();
            _staffEmail = selectedRow.Cells[4].Value.ToString();
            _staffVoluntary = Convert.ToBoolean(selectedRow.Cells[5].Value.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new ExplainScreen().Show();
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
