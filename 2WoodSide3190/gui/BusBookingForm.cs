using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using _2WoodSide3190.objects;
using _2WoodSide3190.dbAccess;

namespace _2WoodSide3190.gui
{
    public partial class BusBookingForm : Form
    {
        //Private variable to check what table has been selected
        private string SelectedTable;

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
        //Declare private variables, these will be used in the methods
        private int BusBookingId;
        private int BusId;
        private int StaffId;
        //Declare the Database object that lets us access the SQL database. The table lets us edit the grid
        private Database db;
        private DataTable table;

        //Constructor
        public BusBookingForm(Database db)
        {
            //Put the form in the middle of the screen, make the edges curved, make the borders disappear
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CenterToScreen();
            //Assign the database object from the previous form to this one so that it can be accessed in the below methods
            this.db = db;
            //Initalize the combo box with data
            initComboBox();
            //Set the current table to BusBooking
            SelectedTable = "BusBooking";
        }

        //Filling the combo box with these items
        private void initComboBox() 
        {
            comboBox1.Items.Add("Show All");
            comboBox1.Items.Add("Booking ID");
            comboBox1.Items.Add("Driver Name");
            comboBox1.Items.Add("Staff Name");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //When the button has been hit change the data in the database depending on what has been entered into the gird
            //Create access to the BusBooking table
            BusBookingDBAccess bbdba = new BusBookingDBAccess(db);
            //Call the UpdateBooking method and pass in the values you want to change
            bbdba.UpdateBooking(BusBookingId, BusId, StaffId);
            //Display an error message and make the grid empty
            MessageBox.Show("The row in the database has been updated.", "Success");
            busResults.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //If the back button is clicked, the main application will appear
            this.Hide();
            new MainApp(db).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //This adds the new entry to the database

                //Creates acces to the BusBooking table
                BusBookingDBAccess bbda = new BusBookingDBAccess(db);

                int _staffId = Convert.ToInt32(StaffBox.Text);
                int _busId = Convert.ToInt32(BusBox.Text);

                //Calls the InsertBusBook method and passes in the changed variables
                bbda.InsertBusBook(_busId, _staffId);
                //The succesform appears
                this.Hide();
                new SuccessForm(db,"Success, BusBooking Registered").Show();
            }
            //If there's a problem, show an error
            catch  
            {
                new ErrorBox(null).Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

            //If the label is clicked, fill the table with all the data in the staff table
            StaffDBAccess sdba = new StaffDBAccess(db);
            createTableToShowStaff(sdba.getAllStaff());
            SelectedTable = "Staff";
        }

        //formats the table to show all the staff members
        private void createTableToShowStaff(List<objects.Staff> list)
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
                busResults.DataSource = table;
            }
            busResults.DataSource = table;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //If the user clicks the show bus label, the grid will be updated to show all the buses in the bus table
            BusDBAccess bdba = new BusDBAccess(db);
            createTableToShowBus(bdba.getAllBus());
            //Sets the current table as Bus
            SelectedTable = "Bus";
        }
        //Formats the grid to show the Buses
        private void createTableToShowBus(List<objects.Bus> list)
        {
            table = new DataTable();
            table.Columns.Add("Bus ID");
            table.Columns.Add("Bus Driver");
            table.Columns.Add("Bus Route");
            table.Columns.Add("Bus Time");

            foreach (Bus bus in list)
            {
                table.Rows.Add(bus.BusId, bus.BusRoute, bus.BusDriver, bus.BusTime);
                busResults.DataSource = table;
            }
            busResults.DataSource = table;
        }

        //When the grid is clicked
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                //If the grid is showing data for the staff
                if (SelectedTable == "Staff")
                {
                    //The staff ID of the selected row is passed into the staff textbox This allows the user to select an ID for the textbox whilst using the grid.
                    int index = e.RowIndex;

                    DataGridViewRow selectedRow = busResults.Rows[index];

                    int _StaffId = int.Parse(selectedRow.Cells[0].Value.ToString());
                    StaffBox.Text = _StaffId.ToString();

                }
                //If the grid is showing data for the buses. This allows the user to select an ID for the textbox whilst using the grid.
                else if (SelectedTable == "Bus")
                {
                    //The Bus ID of the selected row is passed into the Bus textbox
                    int index = e.RowIndex;

                    DataGridViewRow selectedRow = busResults.Rows[index];
                    int _busBook = int.Parse(selectedRow.Cells[0].Value.ToString());
                    BusBox.Text = _busBook.ToString();
                }
                //If the grid is showing data for the BusBooking
                else if (SelectedTable == "BusBooking")
                {
                    //The currently selected rows data is passed into the variables below. This allows the user to modify the data.
                    int index = e.RowIndex;

                    DataGridViewRow selectedRow = busResults.Rows[index];

                    BusBookingId = int.Parse(selectedRow.Cells[1].Value.ToString());
                    BusId = int.Parse(selectedRow.Cells[2].Value.ToString());
                    StaffId = int.Parse(selectedRow.Cells[2].Value.ToString());

                }


            } 
            //The empty try catch statement helps to avoid errors
            catch { }
            }
            

        

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //If the user selects show all, display all the entries for the Bus Booking
                if (comboBox1.Text == "Show All")
                {
                    BusBookingDBAccess bdba = new BusBookingDBAccess(db);
                    createTableToShowAllBusBooking(bdba.getAllBusBooking());
                    SelectedTable = "";
                }

                //If the user searchs for a Booking ID, Show all the entries where their entered ID matches ones in the database
                else if (comboBox1.Text == "Booking ID")
                {
                    BusBookingDBAccess bdba = new BusBookingDBAccess(db);
                    createTableToShowAllBusBooking(bdba.SelectWhereBookingID(Convert.ToInt32(textBox1.Text)));
                    SelectedTable = "BusBooking";
                }
                //If the user searchs for a Driver Name, Show all the entries where their entered name matches the one stored in the database
                else if (comboBox1.Text == "Driver Name")
                {
                    BusDBAccess bdba = new BusDBAccess(db);
                    string driverName = textBox1.Text;
                    createTableToShowBus(bdba.getWhereDriverIs(driverName));
                    SelectedTable = "Bus";
                }
                //If the user searchs for a Staff Name, Show all the entries where their entered name matches the one stored in the database
                else if (comboBox1.Text == "Staff Name")
                {
                    StaffDBAccess sdba = new StaffDBAccess(db);
                    string staffName = textBox1.Text;
                    createTableToShowStaff(sdba.GetStaffByName(staffName));
                    SelectedTable = "Staff";
                }
            }

            catch { }

        }
        //Formats the table to display all the current BusBooking
        private void createTableToShowAllBusBooking(List<objects.BusBooking> list) 
        {
            table = new DataTable();
            table.Columns.Add("BusBooking ID:");
            table.Columns.Add("Bus ID:");
            table.Columns.Add("Staff ID:");
         


            foreach (BusBooking bus in list)
            {
                table.Rows.Add(bus.BusBookingId, bus.BusId, bus.StaffId);
                busResults.DataSource = table;
            }
            busResults.DataSource = table;
        }

     
        //If the picture is clicked, show the explanation screen
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

