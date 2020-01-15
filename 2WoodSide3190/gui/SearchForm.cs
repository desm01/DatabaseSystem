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
using System.Runtime.InteropServices;
using _2WoodSide3190.dbAccess;
using System.IO;
using System.Diagnostics;

namespace _2WoodSide3190.gui
{
    public partial class SearchForm : Form
    {

    //Makes the form curved
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

//Declaration of private variables
        private Database db;
        private DataTable table;
        //The table variable is used to check which table the user has selected
        public string Table;

        //The constrcutor has the database and selected table passed in
        public SearchForm(Database db, string WhichTable)
        {       
            InitializeComponent();
            this.db = db;
            //Assign which table is being selected
            Table = WhichTable;
            //Makes border disappear and the form curved
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CenterToScreen();
            //Fill the combo boxes
            InitComboBox();
            comboBox3.Items.Add("=");
            comboBox3.Items.Add(">");
            comboBox3.Items.Add("<");
            comboBox1.Text = Table;

            //Check the selected table
            switch(Table)
            {
                            //If it's this table. Fill the grid with data from the chosen database table
                case "Parent & Child": InnerJoinDBAccess parentChild = new InnerJoinDBAccess(db); CreateTableToShowChildAndParent(parentChild.GetChildAndParent()); break;
                case "Bookings": InnerJoinDBAccess booking = new InnerJoinDBAccess(db); createTableToShowBookings(booking.GetAllBooking()); break;

                case "Bus": BusDBAccess BusdbAcess = new BusDBAccess(db); createTableToShowBus(BusdbAcess.getAllBus()); break;
                case "Cancellation": CancellationDBAccess cdba = new CancellationDBAccess(db); CreateTableToShowCancellation(cdba.getAllCancellation()); break;
                case "Children": ChildrenDBAccess chdba = new ChildrenDBAccess(db); CreateTableToShowChildren(chdba.GetAllChildren()); break;
                case "Parent": ParentDBAccess pdba = new ParentDBAccess(db); CreateTableToShowParent(pdba.SelectAllParents()); break;
                case "Schools": SchoolDBAccess sdba = new SchoolDBAccess(db); CreateTableToShowSchools(sdba.getAllSchools()); break;
                case "Staff": StaffDBAccess stdba = new StaffDBAccess(db); CreateTableToShowStaff(stdba.getAllStaff()); break;
            
            }
        }
        //This method sets the grid up to work for displaying the bookings 
        public void createTableToShowBookings( List<BookingJoin> list) 
        {
            table = new DataTable();
            table.Columns.Add("Booking ID");
            table.Columns.Add("Date");
            table.Columns.Add("Paid");
            table.Columns.Add("Name");
            table.Columns.Add("Age");

            foreach (BookingJoin bookJoin in list)
            {
                table.Rows.Add(bookJoin.BookingId, bookJoin.Date, bookJoin.Paid, bookJoin.Name, bookJoin.Age);
                dataGridView1.DataSource = table;
            }
            dataGridView1.DataSource = table;
        }
        //Adds data to the comboboxes
        public void InitComboBox()
        {
            comboBox1.Items.Add("Parent & Child");
            comboBox1.Items.Add("Bookings");
            comboBox1.Items.Add("Bus");
            comboBox1.Items.Add("Cancellation");
            comboBox1.Items.Add("Children");
            comboBox1.Items.Add("Parent");
            comboBox1.Items.Add("Schools");
            comboBox1.Items.Add("Staff");

        }
        //When the 'Search' button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
        //The searched for name goes into the searcher variable
            string searcher = textBox1.Text;
            //If the user is searching for a child name in the Parent & Child table
            if (comboBox2.Text == "Child Name" && comboBox1.Text == "Parent & Child")
            {
            //display the data which matches the searched for childs name
                InnerJoinDBAccess injdba = new InnerJoinDBAccess(db);
                CreateTableToShowChildAndParent(injdba.GetChildrenAndParentWhereChildName(searcher));
            }
            //If the user is searching for the Parents name in the parent & child table
            if (comboBox2.Text == "Parent Name" && comboBox1.Text == "Parent & Child")
            {
            //diaplay the data which matches the searched for parents name
                InnerJoinDBAccess injdba = new InnerJoinDBAccess(db);
                CreateTableToShowChildAndParent(injdba.GetChildrenAndParentWhereParentName(searcher));
            }
            //If the user is searching for Driver
            if (comboBox2.Text == "Driver")
            {
            //display the data which matches the searched for Bus drivers name
                BusDBAccess bdba = new BusDBAccess(db);
                createTableToShowBus(bdba.getWhereDriverIs(searcher));
            }
            // This repeats for the rest of the IF statements, the program will update the grid to show where the data in the table matches the value that the user is searching for
            if (comboBox2.Text == "Route")
            {
                BusDBAccess bdba = new BusDBAccess(db);
                createTableToShowBus(bdba.getWhereRouteIs(searcher));
            }

            if (comboBox2.Text == "Time")
            {
                BusDBAccess bdba = new BusDBAccess(db);
                createTableToShowBus(bdba.getWhereTimeIs(comboBox3.Text, searcher));
            }

            if (comboBox2.Text == "Reason")
            {
                CancellationDBAccess cdba = new CancellationDBAccess(db);
                CreateTableToShowCancellation(cdba.GetCancellByName(searcher));
            }

            if (comboBox2.Text == "Child Name")
            {
                ChildrenDBAccess cdba = new ChildrenDBAccess(db);
                CreateTableToShowChildren(cdba.GetChildByName(searcher));
            }

            if (comboBox2.Text == "Age")
            {
                ChildrenDBAccess cdba = new ChildrenDBAccess(db);
                CreateTableToShowChildren(cdba.GetChildByAge(comboBox3.Text, searcher));
            }

            if (comboBox2.Text == "Medical Problems")
            {
                ChildrenDBAccess cdba = new ChildrenDBAccess(db);
                CreateTableToShowChildren(cdba.getChildByMedicalDetails());
            }

            if (comboBox2.Text == "Parent Name")
            {
                ParentDBAccess pdba = new ParentDBAccess(db);
                CreateTableToShowParent(pdba.SelectAllParentsWhereName(searcher));
            }

            if (comboBox2.Text == "Parent Phone")
            {
                ParentDBAccess pdba = new ParentDBAccess(db);
                CreateTableToShowParent(pdba.getParentWithPhone(searcher));
            }

            if (comboBox2.Text == "Parent Email")
            {
                ParentDBAccess pdba = new ParentDBAccess(db);
                CreateTableToShowParent(pdba.getAllParentByEmail(searcher));
            }

            if (comboBox2.Text == "Parent Address")
            {
                ParentDBAccess pdba = new ParentDBAccess(db);
                CreateTableToShowParent(pdba.getParentByAddress(searcher));
            }

            if (comboBox2.Text == "Parent Occupation")
            {
                ParentDBAccess pdba = new ParentDBAccess(db);
                CreateTableToShowParent(pdba.getParentByOccupation(searcher));

            }

            if (comboBox2.Text == "School Name")
            {
                SchoolDBAccess sdba = new SchoolDBAccess(db);
                CreateTableToShowSchools(sdba.getSchoolByName(searcher));
            }

            if (comboBox2.Text == "School Location")
            {
                SchoolDBAccess sdba = new SchoolDBAccess(db);
                CreateTableToShowSchools(sdba.getSchoolByLocation(searcher));
            }

            if (comboBox2.Text == "School Number")
            {
                SchoolDBAccess sdba = new SchoolDBAccess(db);
                CreateTableToShowSchools(sdba.getSchoolByNumber(searcher));
            }

            if (comboBox2.Text == "Paid")
            {
                string reason = textBox1.Text.ToLower();
                int num = 0;
                //If the user types in false or true, the program creates a variable called num which stores 0/1 depeneding on if the user has typed true or false
                switch (reason) 
                {
                    case "false": num = 0; break;
                    case "true": num = 1;  break; 
                }
                InnerJoinDBAccess injdba = new InnerJoinDBAccess(db);
                createTableToShowBookings(injdba.GetBookingWithPaid(num));
            }

            if (comboBox2.Text == "Name") 
            {
                string name = textBox1.Text;
                InnerJoinDBAccess injdba = new InnerJoinDBAccess(db);
                createTableToShowBookings(injdba.GetBookingWithName(name));
            }
        }
        //This method sets the grid up for displaying the child & parents data
        private void CreateTableToShowChildAndParent(List<objects.ChildParentJoin> list)
        {
            table = new DataTable();
            table.Columns.Add("Child ID");
            table.Columns.Add("Child Name");
            table.Columns.Add("Medical Details");
            table.Columns.Add("Age");
            table.Columns.Add("School Name");
            table.Columns.Add("Parent Name");
            table.Columns.Add("Parent Email");
            table.Columns.Add("Phone Number");
            table.Columns.Add("Address");

            foreach (ChildParentJoin childParent in list)
            {
                table.Rows.Add(childParent.ChildId, childParent.ChildName, childParent.MedicalDetails, childParent.Age, childParent.SchoolName, childParent.ParentName, childParent.ParentEmail, childParent.ParentPhone, childParent.Address);
                dataGridView1.DataSource = table;
            }
            dataGridView1.DataSource = table;
        }
        //This method sets the grid up for displaying the staffs data
        private void CreateTableToShowStaff(List<objects.Staff> list)
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
                dataGridView1.DataSource = table;
            }
            dataGridView1.DataSource = table;
        }
        //This method sets the grid up for displaying the schools data
        private void CreateTableToShowSchools(List<objects.Schools> list)
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
                dataGridView1.DataSource = table;
            }
            dataGridView1.DataSource = table;
        }
        //This method sets the grid up for displaying the parents data
        private void CreateTableToShowParent(List<objects.Parent> list)
        {
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
                dataGridView1.DataSource = table;

            }
            dataGridView1.DataSource = table;
        }
        //This method sets the grid up for displaying the childrens data
        private void CreateTableToShowChildren(List<objects.Children> list)
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
                dataGridView1.DataSource = table;
            }
            dataGridView1.DataSource = table;
        }

        //This method sets the grid up for displaying the cancellation data
        private void CreateTableToShowCancellation(List<objects.Cancellation> list)
        {
            table = new DataTable();
            table.Columns.Add("Cancellation ID:");
            table.Columns.Add("Booking ID:");
            table.Columns.Add("Child ID:");
            table.Columns.Add("Date:");
            table.Columns.Add("Reason:");

            foreach (Cancellation cancel in list)
            {
                table.Rows.Add(cancel.CancellationId, cancel.BookingId, cancel.ChildId, cancel.Date, cancel.Reason);
                dataGridView1.DataSource = table;
            }
            dataGridView1.DataSource = table;
        }
        //This method sets the grid up for displaying the bus data
        private void createTableToShowBus(List<objects.Bus> list)
        {
            table = new DataTable();
            table.Columns.Add("Bus ID");
            table.Columns.Add("Bus Route");
            table.Columns.Add("Bus Driver");
            table.Columns.Add("Time");

            foreach (Bus bus in list)
            {

                table.Rows.Add(bus.BusId, bus.BusDriver, bus.BusRoute, bus.BusTime);
                dataGridView1.DataSource = table;

            }
            dataGridView1.DataSource = table;
        }
        //This method saves the data to an excell document
        private void button2_Click(object sender, EventArgs e)
        {
        //Take the data and save it to an excell document
            var sb = new StringBuilder();

            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
            //Save to a file called ExportedData.csv
            SaveDataGridViewToCSV(@"ExportedData.csv");

            Process openExcel = new Process();
            openExcel.StartInfo.FileName = @"ExportedData.csv";
            openExcel.Start();


        }

        void SaveDataGridViewToCSV(string filename)
        {
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            dataGridView1.SelectAll();
            // Copy selected cells to DataObject
            DataObject dataObject = dataGridView1.GetClipboardContent();
            // Get the text of the DataObject, and serialize it to a file
            File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
        }

        //If the back button is clicked, the main app form will appear
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }
        //this doesnt do anything, but deleting it will cause the program to be unstable
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //When the user changes the selected combobox index
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        //Clear the data in the second combobox
            comboBox2.Items.Clear(); 
            //Switch the selected table
            switch (comboBox1.Text)
            {

            //If the selected table is this value: populate the second combobox with these values 
                case "Bookings": comboBox2.Items.Add("Name"); comboBox2.Items.Add("Paid"); InnerJoinDBAccess booking = new InnerJoinDBAccess(db); createTableToShowBookings(booking.GetAllBooking()); break;
                case "Bus": comboBox2.Items.Add("Driver");comboBox2.Items.Add("Route"); comboBox2.Items.Add("Time"); BusDBAccess BusdbAcess = new BusDBAccess(db); createTableToShowBus(BusdbAcess.getAllBus()); break;
                case "Cancellation": comboBox2.Items.Add("Reason"); CancellationDBAccess cdba = new CancellationDBAccess(db); CreateTableToShowCancellation(cdba.getAllCancellation()); break;
                case "Children": comboBox2.Items.Add("Child Name"); comboBox2.Items.Add("Age"); comboBox2.Items.Add("Medical Problems"); ChildrenDBAccess chdba = new ChildrenDBAccess(db); CreateTableToShowChildren(chdba.GetAllChildren()); break; break;
                case "Parent": comboBox2.Items.Add("Parent Name"); comboBox2.Items.Add("Parent Phone"); comboBox2.Items.Add("Parent Email"); comboBox2.Items.Add("Parent Address"); comboBox2.Items.Add("Parent Occupation"); ParentDBAccess pdba = new ParentDBAccess(db); CreateTableToShowParent(pdba.SelectAllParents()); break;
                case "Schools": comboBox2.Items.Add("School Name"); comboBox2.Items.Add("School Location"); comboBox2.Items.Add("School Number"); SchoolDBAccess sdba = new SchoolDBAccess(db); CreateTableToShowSchools(sdba.getAllSchools()); break;
                case "Staff": comboBox2.Items.Add("Staff Name"); comboBox2.Items.Add("Staff Voluntary"); StaffDBAccess stdba = new StaffDBAccess(db); CreateTableToShowStaff(stdba.getAllStaff()); break;
                case "Parent & Child": comboBox2.Items.Add("Parent Name"); comboBox2.Items.Add("Child Name"); InnerJoinDBAccess injdba = new InnerJoinDBAccess(db); CreateTableToShowChildAndParent(injdba.GetChildAndParent()); break;
            }
        }
        //If the user clicks the reset button, they will be taken back to the modify screen and can reselect a table if there'a big problem
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new modifyForm(db, "Search").Show();
        }

        //If the user clicks the question mark picture, the explanation screen appears
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new HowToSearch().Show();
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
