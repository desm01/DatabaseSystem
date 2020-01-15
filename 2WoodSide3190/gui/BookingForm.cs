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
    public partial class BookingForm : Form
    {
        //Private variables declared. db used to connect to the SQL Database, table used to edit the grid
        private Database db;
        private DataTable table;

        //Private varaibles declared, used to modify data later on in the program
        private int BookingId;
        private int ChildId;
        private int BusBookingId;
        private bool Paid;
        private DateTime Date;

        //used to store the currently selected table
        private string selectedTable;

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
        public BookingForm(Database db)
        {
            //Set the form in the centre of the screen, make the borders flat, make the edges curved
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CenterToScreen();
            //Make the db object from the previous form in this form. This is so it can be accessed in the below methods 
            this.db = db;
            //Initalize the combobox and fill it with data
            InitComboBox();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            //Shows all the data for bookings when the 'View' button is clicked 
            if (comboBox1.Text == "Show All") 
            {
                BookingDBAccess bdba = new BookingDBAccess(db);
                createTable(bdba.getAllBook());
            }
            //Shows the data for the bookings which matches the searched for BookingId
            else if (comboBox1.Text == "Booking ID") 
            {
                BookingDBAccess bdba = new BookingDBAccess(db);
                int BookNo = Convert.ToInt32(searchBox.Text);
                createTable(bdba.getBookWithID(BookNo));
            }
            //shows the data for the bookings which matches the searched for Childs name
           else if (comboBox1.Text =="Child Name") 
            {
                ChildrenDBAccess cdba = new ChildrenDBAccess(db);
                string name = searchBox.Text;
                createTableShowAllChild(cdba.GetChildByName(name));
                selectedTable = "Children";
            }
            //Shows the data for the bookings which matches the searched for childs age
            else if (comboBox1.Text == "Child Age") 
            {
                ChildrenDBAccess cdba = new ChildrenDBAccess(db);
                int age = Convert.ToInt32(searchBox.Text);
                createTableShowAllChild(cdba.GetChildByAge("=", age.ToString()));
                selectedTable = "Children";
            }

        }
        //formats the table to show all the bookings in the database
        private void createTable(List<objects.Booking> list)
        {
            table = new DataTable();
            table.Columns.Add("Booking ID");
            table.Columns.Add("Child ID");
            table.Columns.Add("Bus Booking ID");
            table.Columns.Add("Paid");
            table.Columns.Add("Date");

            foreach (Booking book in list)
            {
                table.Rows.Add(book.BookingId, book.ChildId, book.BusBookingId, book.Paid, book.Time);
                bookResults.DataSource = table;
            }
            bookResults.DataSource = table;
        }
        //Initalizes and fills the combobox with these items
        private void InitComboBox() 
        {
            comboBox1.Items.Add("Show All");
            comboBox1.Items.Add("Booking ID");
            comboBox1.Items.Add("Child Name");
            comboBox1.Items.Add("Child Age");

            cancelled.Items.Add("Not Paid");
            cancelled.Items.Add("Paid");
        }

       
        //Shows the main application
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }

        //Inserts data into the table
        private void button1_Click(object sender, EventArgs e)
        {
            //Initalizes cancelled to 0 as it hasnt been cancelled
            int canclled = 0;
            int ChildId = Convert.ToInt32(childId.Text);
            int BusBookingId = Convert.ToInt32(busBookingId.Text);

            //If the user hasn't paid, they're assigned 0
            if (cancelled.Text == "Not Paid") 
            {
                 canclled = 0 ;
            }
            //If the user has paid, they're assigned a 1
            else if (cancelled.Text == "Paid") 
            {
                canclled = 1;
            }
            try
            {
                //Inserts the entered data into the Booking table
                string time = date.Value.ToShortDateString();

                BookingDBAccess bdba = new BookingDBAccess(db);
                bdba.InsertBooking(ChildId, BusBookingId, canclled, time);
                this.Hide();
                new SuccessForm(db, "Booking Successfully Registered").Show();
            }
            catch (Exception ex) {  }
        }

        private void label5_Click(object sender, EventArgs e)
        {

            //If the user clicks the show all children label, the grid will be updated to show all the children stored in the database
            ChildrenDBAccess cdba = new ChildrenDBAccess(db);
            createTableShowAllChild(cdba.GetAllChildren());
            selectedTable = "Children";
        }

        //Formats the table to be able to show all the children
        private void createTableShowAllChild(List<objects.Children> list)
        {
            table = new DataTable();
            table.Columns.Add("Child ID");
            table.Columns.Add("Parent ID");
            table.Columns.Add("School ID");
            table.Columns.Add("Child Name");
            table.Columns.Add("Medical Details");
            table.Columns.Add("Age");

            foreach (Children child in list)
            {
                table.Rows.Add(child.ChildId, child.ParentId, child.SchoolId, child.ChildName, child.MedicalDetails, child.Age);
               bookResults.DataSource = table;
            }
            bookResults.DataSource = table;
        }

        //If the show all busbooking label is clicked, the grid will update to show all the current bus bookings in the database
        private void label6_Click(object sender, EventArgs e)
        {
            BusBookingDBAccess bdba = new BusBookingDBAccess(db);
            createTableShowAllBusBooking(bdba.getAllBusBooking());
            selectedTable = "Bus";
        }
        //Formats the table to be able to show all the BusBookings
        private void createTableShowAllBusBooking(List<objects.BusBooking> list) 
        {
            table = new DataTable();
            table.Columns.Add("Bus Booking ID");
            table.Columns.Add("Bus ID");
            table.Columns.Add("Staff ID");
            table.Columns.Add("Bus Driver");
            table.Columns.Add("Staff Member");

            foreach(BusBooking busBook in list) 
            {
                table.Rows.Add(busBook.BusBookingId, busBook.BusId, busBook.StaffId);
                bookResults.DataSource = table;
            }
            bookResults.DataSource = table;
        }

        private void bookResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void bookResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //If the curernt table is the children table
            if (selectedTable == "Children")
            {
                //Change the children id textbox to whatever row the user clicks
                int index = e.RowIndex;

                DataGridViewRow selectedRow = bookResults.Rows[index];
                int _childId = int.Parse(selectedRow.Cells[0].Value.ToString());
                childId.Text = _childId.ToString();
            }
            //If the current table is the bus table
            else if (selectedTable == "Bus") 
            {
                //Change the current BusbookingId textbox to whatever row the user clicks
                int index = e.RowIndex;

                DataGridViewRow selectedRow = bookResults.Rows[index];
                int _BusBookId = int.Parse(selectedRow.Cells[0].Value.ToString());
                busBookingId.Text = _BusBookId.ToString();
            }

            int index1 = e.RowIndex;
        }

        //when the modify data button is clicked, the highlighted entry will be changed in the database to whatever the user has entered into the grid

        private void button4_Click(object sender, EventArgs e)
        {
            BookingDBAccess bbdba = new BookingDBAccess(db);
            bbdba.UpdateBooking(BookingId, ChildId, BusBookingId, Paid, Date);
            MessageBox.Show("The row in the database has been updated.", "Success");
            bookResults.DataSource = null; 
        }

        //If the picture is clicked, the explain screen will appear
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

