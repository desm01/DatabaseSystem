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
using System.IO;
using System.Diagnostics;

namespace _2WoodSide3190.gui
{
    public partial class CancellForm : Form
    {
        //Declare private variable, db used to get access to SQL database. table used to change the grid 
        private Database db;
        private DataTable table;


        //This makes the forms edges curved
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
        //Constrcutor. db object passed in
        public CancellForm(Database db)
        {
            //Put the form in the centre of the screen, make the edges curved and borders disappear
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CenterToScreen();
            //Pass the database object into a new one so that it can be accessed in other methods in this form
            this.db = db;
            //Trigger method
            InitalizeTable();
        }

        private void InitalizeTable()
        {
            //Create new object of type BookingDBAccess. Update table to show all bookings
            BookingDBAccess bdba = new BookingDBAccess(db);
            createTable(bdba.getAllBook());
        }

        private void createTable(List<objects.Booking> list)
        {
            //Updates the grid to show all the current bookings
            table = new DataTable();
            table.Columns.Add("Booking ID");
            table.Columns.Add("Child ID");
            table.Columns.Add("Bus Booking ID");
            table.Columns.Add("Paid");
            table.Columns.Add("Date");

            foreach (Booking book in list)
            {

                table.Rows.Add(book.BookingId, book.ChildId, book.BusBookingId, book.Paid, book.Time);

            }
            Results.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //Creates a form to check if the user is sure they want to delete data or not
                using (var form = new DeleteValidate())
                {
                    var result = form.ShowDialog();
                //If the user clicks 'Yes'
                    if (result == DialogResult.Yes)
                    {
                    //Make the form hide
                        this.Hide();
                        BookingDBAccess bdba = new BookingDBAccess(db);

                    //If the user hasn't selected a row
                        if (Results.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("No Row Selected Was Selected", "Error");
                            this.Hide();
                            new MainApp(db).Show();

                        }
                        //If there's more than one row selected, show an error message
                        else if (Results.SelectedRows.Count > 1)
                        {
                            MessageBox.Show("There are too many rows selected. Only select one please.", "Error");
                        }
                        //If the user has selected one row delete that row from the booking table and populate it in the cancelation table with the entered reason
                        else if (Results.SelectedRows.Count == 1)
                        {
                            int rowNum = Results.SelectedRows[0].Index;
                            int cancellationId = int.Parse(Results.Rows[rowNum].Cells[0].Value.ToString());
                        int childId = int.Parse(Results.Rows[rowNum].Cells[1].Value.ToString());
                        DateTime date = Convert.ToDateTime(Results.Rows[rowNum].Cells[4].Value.ToString());
                        string reason = reasonBox.Text;
                        List<Booking> results = new List<Booking>();
                            results = bdba.getBookWithID(cancellationId);

                            CancellationDBAccess cdba = new CancellationDBAccess(db);
                            cdba.InsertCancell(cancellationId, childId, date, reason);  



                            foreach (Booking book in results)
                            {
                            //When the entry is deleted show a message saying 'Success'
                                bdba.DeleteEntry(book.BookingId);
                                new SuccessForm(db,"Success, Booking Cancelled").Show();
                                this.Hide();
                                new MainApp(db).Show();
                            }
                        }

                        //If the user clicks 'No', make the form dissappear
                        else if (result == DialogResult.No)
                        {
                            this.Hide();
                            new CancellForm(db).Show();
                        }
                    }
                }
            }
        
        //Makes the main app appear
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }
        //Export the data to an excel file
        private void button3_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            var headers = Results.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in Results.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
            //Save the data to a CSV file which excel can read called ExportedData
            SaveDataGridViewToCSV(@"ExportedData.csv");
            //Open the file once it has been saved
            Process openExcel = new Process();
            openExcel.StartInfo.FileName = @"ExportedData.csv";
    

 
            openExcel.Start();
        }
        void SaveDataGridViewToCSV(string filename)
        {
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            Results.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            Results.SelectAll();
            // Copy selected cells to DataObject
            DataObject dataObject = Results.GetClipboardContent();
            // Get the text of the DataObject, and serialize it to a file
            File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
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
