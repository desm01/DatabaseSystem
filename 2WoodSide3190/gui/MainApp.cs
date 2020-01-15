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

namespace _2WoodSide3190.gui
{
    public partial class MainApp : Form
    {
    //Declaration of private variables
        private Database db;
        private int ParentId;

        //This makes the form curved
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
   //Constrctor, gets the database object db passed into it
        public MainApp(Database db)
        {

        //Puts the form in the centre of the screen and curves the edges and removes the borders
            InitializeComponent();
              CenterToScreen();
              this.FormBorderStyle = FormBorderStyle.None;
              Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); 
              this.db = db;
        }

        private void MainApp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        //This shows the AddAParentMessageBox form and if the user clicks 'yes', the SelectAParentForm will appear, if they click 'No', the AddAParentForm will appear 
            using (var form = new AddAParentMessageBox())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    new SelectAParentForm(db).Show();
                }

                else if (result == DialogResult.No)
                {
                    this.Hide();
                    new AddAParent(db).Show();
                }
            }

        }




        //If the 'X' picture is clicked, the program will close down
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //If the 'Minimize' picture is clicked, the program will minimize down to the application tray
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //This shows the MakeABookingChoice form and if the user clicks 'Bus', the BusBookingForm will appear, if they click 'Booking', the BookingForm will appear 
        private void button2_Click(object sender, EventArgs e)
        {
            using (var form = new MakeABookingChoice())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    new BusBookingForm(db).Show();
                }

                else if (result == DialogResult.No)
                {
                    this.Hide();
                    new BookingForm(db).Show();
                }
            }
        }
        //This shows the AddAParentMessageBox form and if the user clicks 'yes', the SelectAParentForm will appear, if they click 'No', the AddAParentForm will appear 
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            using (var form = new AddAParentMessageBox())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    new SelectAParentForm(db).Show();
                }

                else if (result == DialogResult.No)
                {
                    this.Hide();
                    new AddAParent(db).Show();
                }
            }
        }


        //This shows the AddAParentMessageBox form and if the user clicks 'yes', the SelectAParentForm will appear, if they click 'No', the AddAParentForm will appear 
        private void childToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (var form = new AddAParentMessageBox())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    new SelectAParentForm(db).Show();
                }

                else if (result == DialogResult.No)
                {
                    this.Hide();
                    new AddAParent(db).Show();
                }
            }
        }
        //This shows the MakeABookingChoice form and if the user clicks 'Bus', the BusBookingForm will appear, if they click 'Booking', the BookingForm will appear 
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (var form = new MakeABookingChoice())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    new BusBookingForm(db).Show();
                }

                else if (result == DialogResult.No)
                {
                    this.Hide();
                    new BookingForm(db).Show();
                }
            }
        }

        //These pieces of code enable the toolstrip to work properly

        private void parentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddAParent(db).Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellForm(db).Show();
        }
        
        private void childToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SelectAParentForm(db).Show();
        }

        private void parentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SelectAParentForm(db).Show();
        }

        private void staffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SelectAParentForm(db).Show();
        }

        private void busToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SelectAParentForm(db).Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new modifyForm(db,null).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
             new modifyForm(db,null).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellForm(db).Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellForm(db).Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToString();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new modifyForm(db,null).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new modifyForm(db,null).Show();
        }



        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellationTable(db).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellationTable(db).Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HelpForm(db).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HelpForm(db);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HelpForm(db).Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void viewCancellationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CancellationTable(db).Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            string decider = "Search";
            this.Hide();
            new modifyForm(db, decider).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string decider = "Search";
            this.Hide();
            new modifyForm(db, decider).Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ReportForm(db).Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ReportForm(db).Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ContactForm(db).Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ContactForm(db).Show();
        }
    }
}
