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
    public partial class CancellationTable : Form
    {
        //Make the edges of the form curved
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

        //Declaration of private variables which will be used in the form
        private int cancellationId;
        private int bookingId;
        private int childId;
        private DateTime date;
        private string reason;

        //Declaring the database object which will allow me to connect to the SQL database and declaring the table which will allow me to edit the grid
        private Database db;
        private DataTable table;

      
        //Constructor
        public CancellationTable(Database db)
        {
            //Makes the forms borders disappear, puts it in the centre of the screen & makes the edges curved
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CenterToScreen();
            //Passes the database into a new object that lets it be called elsewhere in the form
            this.db = db;
            //Makes the grid show all the cancellations
            CancellationDBAccess cdba = new CancellationDBAccess(db);
            createTableToShowAllCancells(cdba.getAllCancellation());
        }

        public void createTableToShowAllCancells(List<objects.Cancellation> list) 
        {
            //Formats the table to show all the cancellations
            table = new DataTable();
            table.Columns.Add("Cancellation ID:");
            table.Columns.Add("Booking ID:");
            table.Columns.Add("Child ID:");
            table.Columns.Add("Date:");
            table.Columns.Add("Reason:");

            foreach (Cancellation cancel in list)
            {
               table.Rows.Add(cancel.CancellationId, cancel.BookingId, cancel.ChildId, cancel.Date, cancel.Reason);
               dataGridView2.DataSource = table;
            }
            dataGridView2.DataSource = table;
        }
        //Close the form and go back to the main menu
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }
        //If the user decides to edit one of the entries, this code does it.
        private void button3_Click(object sender, EventArgs e)
        {
            CancellationDBAccess bbdba = new CancellationDBAccess(db);
            //These variables are passed into the updateProject method in the cancellationDBAcces class
            bbdba.updateProject(cancellationId, bookingId, childId, date, reason);
            MessageBox.Show("The row in the database has been updated.", "Success");
            //Make the grid have nothing in it. Bring the user back to the main menu
            dataGridView2.DataSource = null;

            this.Hide();
            new MainApp(db).Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This shows all the cancellation which match the searched for name
            CancellationDBAccess cdba = new CancellationDBAccess(db);
            string reason = textBox1.Text;
            createTableToShowAllCancells(cdba.GetCancellByName(reason));
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Every time a cell is clicked. The varibales are updated for the selected row
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[index];
            cancellationId = int.Parse(selectedRow.Cells[0].Value.ToString());
            bookingId = int.Parse(selectedRow.Cells[1].Value.ToString());
            childId = int.Parse(selectedRow.Cells[2].Value.ToString());
            date = Convert.ToDateTime(selectedRow.Cells[3].Value.ToString());
            reason = selectedRow.Cells[4].Value.ToString();
        }
    }
}
