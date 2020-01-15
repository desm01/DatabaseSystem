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
    public partial class AddAParent : Form
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
        private int parentId;
        private string parentName;
        private string parentPhone;
        private string parentEmail;
        private string parentAddress;
        private string parentOccupation;


        //Private variables declared. db used to connect to the SQL Database, table used to edit the grid
        private Database db;
        private DataTable table;

        //Constrcutor. db is passed in and so is the selected Parent ID from the last form
        public AddAParent(Database db)
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


        private void button1_Click(object sender, EventArgs e)
        {
            //Try to fill these variables using the data the user enters into the textboxes
            try
            {
                string parentName = ParentName.Text;
                string parentNumber = ParentNumber.Text;
                string parentEmail = ParentEmail.Text;
                string parentAddress = ParentAddress.Text;
                string parentOccupation = ParentOccupation.Text;

                ParentDBAccess pdba = new ParentDBAccess(db);

                //Populate a new entry with entered data
                pdba.InsertParent(parentName, parentNumber, parentEmail, parentAddress, parentOccupation);

                //Show the message box to check if the user wants to add another child
                using (var form = new AddAChildMessage())
                {
                    var result = form.ShowDialog();

                    //If they do want to add another child, show the SelectAParentForm
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();

                        new SelectAParentForm(db).Show();
                    }
                    //If they don't want to register another child, take the user back to the main application
                    else if (result == DialogResult.No)
                    {
                        this.Hide();

                        new MainApp(db).Show();
                    }
                }

            }
            //If there's an error, display it a new form
            catch (SqlException ex) 
            {
                new ErrorBox(ex).Show();
            }
        }
        // This method initalizes and fills the combobox with these items
        public void initComboBox()
        {
            comboBox1.Items.Add("Parent Name");
            comboBox1.Items.Add("Town");
            comboBox1.Items.Add("Show All");
        }

        //formats the table to show all the parent entries in the database
        private void createTable(List<objects.Parent> list)
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
                parentGridView.DataSource = table;

            }
            parentGridView.DataSource = table;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Shows all the data for the parent table which matches the searched for parent name 
            if (comboBox1.Text == "Parent Name") 
            {
                ParentDBAccess pdba = new ParentDBAccess(db);
                string name = searchBox.Text;
                createTable(pdba.SelectAllParentsWhereName(name));
            }
            //Shows all the data for the parent table which matches the searched for parent town 
            else if (comboBox1.Text == "Town") 
            {
                ParentDBAccess pdba = new ParentDBAccess(db);
                string townName = searchBox.Text;
                createTable(pdba.SelectAllParentsWhereTown(townName));
            }
            //Shows all the data for the parent table when the 'View' button is clicked 
            else if (comboBox1.Text == "Show All") 
            {
                ParentDBAccess pdba = new ParentDBAccess(db);
                createTable(pdba.SelectAllParents());
            }
            //If a problem arises, display this error message
            else 
            {
                MessageBox.Show("ERROR");
                this.Hide();
                new MainApp(db).Show();
            }

        }
        //Take the userb back to the main menu if they click the 'back' button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }

        //when the modify data button is clicked, the highlighted entry will be changed in the database to whatever the user has entered into the grid

        private void button4_Click(object sender, EventArgs e)
        {
            ParentDBAccess pdba = new ParentDBAccess(db);

            pdba.updateProject(parentId, parentName, parentPhone, parentEmail, parentAddress, parentOccupation);
            MessageBox.Show("The row in the database has been updated.", "Success");
            parentGridView.DataSource = null;
        }

        private void parentGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void parentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ///This allows data to be modified. Whenever a row is clicked; the data in that row is passed into a variable which can then be used to modify the database entries

            try
            {
                int index = e.RowIndex;

                DataGridViewRow selectedRow = parentGridView.Rows[index];
                parentId = int.Parse(selectedRow.Cells[0].Value.ToString());
                parentName = selectedRow.Cells[1].Value.ToString();
                parentPhone = selectedRow.Cells[2].Value.ToString();
                parentEmail = selectedRow.Cells[3].Value.ToString();
                parentAddress = selectedRow.Cells[4].Value.ToString();
                parentOccupation = selectedRow.Cells[5].Value.ToString();
            }

            catch (Exception ex)
            {
                new ErrorBox(null).Show();
            }
        }

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

