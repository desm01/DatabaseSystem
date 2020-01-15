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

namespace _2WoodSide3190.gui
{
    public partial class AddABus : Form
    {
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
        //Private varaibles declared, used to modify data later on in the program
        private int busId;
        private string _busRoute;
        private string _driver;
        private int _time;

        //Private variables declared. db used to connect to the SQL Database, table used to edit the grid
        private Database db;
        private DataTable table;

        //Constrcutor. db is passed in so it can be used to access the SQL Database
        public AddABus(Database db)
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
        }
       
        //Initalizes and fills the combobox with these items
        private void initComboBox () 
        {
            comboBox1.Items.Add("Show All");
            comboBox1.Items.Add("Driver Name");
        }

        //This takes the user back to the main application
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }

        //Create a new entry in the table using the entered data
        private void button1_Click(object sender, EventArgs e)
        {
            //Fill these variables using the data the user enters into the textboxes
            string BusRoute = bus.Text;
            string Driver = driver.Text;
            int time = Convert.ToInt32(timeBox.Text);

            //Try populating a new entry with the newly entered data
            BusDBAccess bdba = new BusDBAccess(db);

            bdba.InsertBus(BusRoute, Driver, time);

            new SuccessForm(db,"Success").Show();
        }

        //when the modify data button is clicked, the highlighted entry will be changed in the database to whatever the user has entered into the grid

        private void button4_Click(object sender, EventArgs e)
        { 
            BusDBAccess bdba = new BusDBAccess(db);
            bdba.ModifyBus(busId, _busRoute, _driver, _time);
            MessageBox.Show("The row in the database has been updated.", "Success");
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //formats the table to show all the Bus entries in the database
        private void createTableToShowBus(List<objects.Bus> list)
        {
            table = new DataTable();
            table.Columns.Add("Bus ID");
            table.Columns.Add("Bus Route");
            table.Columns.Add("Bus Driver");
            table.Columns.Add("Time");

            foreach (Bus bus in list)
            {

                table.Rows.Add(bus.BusId, bus.BusDriver, bus.BusRoute,  bus.BusTime);
                dataGridView1.DataSource = table;

            }
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Shows all the data for the Bus table when the 'View' button is clicked 
            if (comboBox1.Text == "Show All") 
            {
                BusDBAccess bdba = new BusDBAccess(db);
                createTableToShowBus(bdba.getAllBus());
            }
            //Shows all the data for the Bus table which matches the searched for Bus Driver name 
            else if (comboBox1.Text == "Driver Name") 
            {
                string selectedName = textBox1.Text;
                BusDBAccess bdba = new BusDBAccess(db);
                createTableToShowBus(bdba.getWhereDriverIs(selectedName));
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ///This allows data to be modified. Whenever a row is clicked; the data in that row is passed into a variable which can then be used to modify the database entries

            try
            {
                //Change the variables to whatever row the user has selected
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                busId = int.Parse(selectedRow.Cells[0].Value.ToString());
                _busRoute = selectedRow.Cells[1].Value.ToString();
                _driver = selectedRow.Cells[2].Value.ToString();
                _time = Convert.ToInt32(selectedRow.Cells[3].Value.ToString());
            }
            catch { }
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
