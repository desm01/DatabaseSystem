using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using _2WoodSide3190.objects;

namespace _2WoodSide3190.gui
{
    public partial class HelpForm : Form
    {

        private Database db;

        //This makes the edges curved
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

        public HelpForm(Database db)
        {
            //Make the PDF appear at the right side of the form
            InitializeComponent();
            try
            {
                axAcroPDF1.src =  @"UserGuide.pdf" ;
            }
            catch { }

            //Put the form in the center of the screen, make borders disappear and edges curved
            //This the database object that lets the user acces the database
            this.db = db;
            CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        //If the back button is clicked, the main menu form will appear
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }
        //If the picture is clicked, the main menu form will appear
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }
        //If the user clicks the modify data button, the modify form will appear
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new modifyForm(db, null).Show();
        }
        //If the parent clicks to add a child
        private void button2_Click(object sender, EventArgs e)
        {
            //AddAParentMessageBox appears 
            using (var form = new AddAParentMessageBox())
            {

                //If the user clicks 'Yes'
                var result = form.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    //The SelectAParentForm appears
                    this.Hide();
                    new SelectAParentForm(db).Show();
                }
                //If the user clicks 'No'
                else if (result == DialogResult.No)
                {
                    //The add a parent screen appears
                    this.Hide();
                    new AddAParent(db).Show();
                }
            }
        }
        //If the add a child picture is clicked
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (var form = new AddAParentMessageBox())
            {

                var result = form.ShowDialog();
                //If the user clicks 'Yes'
                if (result == DialogResult.Yes)
                {
                    //The SelectAParentForm appears
                    this.Hide();
                    new SelectAParentForm(db).Show();
                }
                //If the user clicks 'No'
                else if (result == DialogResult.No)
                {
                    //The add a parent screen appears
                    this.Hide();
                    new AddAParent(db).Show();
                }
            }
        }
        //Show the modify form
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new modifyForm(db,null).Show();
        }

        //If the 'Make A Booking button is clicked'
        private void button5_Click(object sender, EventArgs e)
        {
            //Show the form
            using (var form = new MakeABookingChoice())
            {

                var result = form.ShowDialog();
                //If the user clicks  'Bus'
                if (result == DialogResult.Yes)
                {
                    //Show the busbooking form
                    this.Hide();
                    new BusBookingForm(db).Show();
                }
                //If the user clicks 'Booking'
                else if (result == DialogResult.No)
                {
                    //show the booking form
                    this.Hide();
                    new BookingForm(db).Show();
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Show the MakeABookingChoice form
            using (var form = new MakeABookingChoice())
            {
                var result = form.ShowDialog();
                //If the user clicks 'Bus'
                if (result == DialogResult.Yes)
                {
                    //Show the BusBooking form
                    this.Hide();
                    new BusBookingForm(db).Show();
                }

                //If the user clicks 'Booking'
                else if (result == DialogResult.No)
                {
                    //Show the booking form
                    this.Hide();
                    new BookingForm(db).Show();
                }
            }
        }
        //Show the modify form
        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new modifyForm(db,null).Show();
        }
        //Show the modify form
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new modifyForm(db,null).Show();
        }
        //Show thre cancellationForm
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellForm(db).Show();
        }
        //Show the cancellationForm
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellForm(db).Show();
        }
        //Show the cancellation table
        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellationTable(db).Show();
        }
        //Show the cancellation table
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellationTable(db).Show();
        }

        private void makeABookingToolStripMenuItem_Click(object sender, EventArgs e)
        {

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