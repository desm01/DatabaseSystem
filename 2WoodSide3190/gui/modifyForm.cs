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
    public partial class modifyForm : Form
    {
    //This makes the corners of the form curved
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

       //Declare the private variables
        private Database db;
        public string WhichForm;
        //Constrcutor gets the database and a variable called decider passed in. Decider will be passed to check whether the user wants to modify or search for data
        public modifyForm(Database db, string Decider)
        {
        //The choosen function is passed into a variable called WhichForm
            WhichForm = Decider;
            //Put the form in the centre of the screen and make borders disappear and edges the curved
            InitializeComponent();
            CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));   
            this.db = db;
        }
        //Go back to the main application
        private void button7_Click(object sender, EventArgs e)
        {
            if (WhichForm == "Search")
            {
                this.Hide();
                new MainApp(db).Show();
            }

            else
            {
                this.Hide();
                new MainApp(db).Show();
            }
        }
        //If the minimzation picture is clicked, minimize the form to the application tray
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //If the 'X' picture is clicked, the application will close
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        private void button1_Click(object sender, EventArgs e)
        {
        //If the user wants to search for Children, the searchform will appear and it will be populated with all the childrens data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Children").Show();
            }
            //Or if they want to modify data, the form to modify the childrens data will appear
            else
            {
                this.Hide();
                new AddChild(db, Convert.ToInt32(null)).Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Children, the searchform will appear and it will be populated with all the childrens data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Children").Show();
            }
            //Or if they want to modify data, the form to modify the childrens data will appear
            else
            {
                this.Hide();
                new AddChild(db, Convert.ToInt32(null)).Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Parents, the searchform will appear and it will be populated with all the Parents data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Parent").Show();
            }
            //Or if they want to modify data, the form to modify the parents data will appear
            else
            {
                this.Hide();
                new AddAParent(db).Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Parents, the searchform will appear and it will be populated with all the Parents data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Parent").Show();
            }
            //Or if they want to modify data, the form to modify the parents data will appear
            else
            {
                this.Hide();
                new AddAParent(db).Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Schools, the searchform will appear and it will be populated with all the Schools data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Schools").Show();
            }
            //Or if they want to modify data, the form to modify the schools data will appear
            else
            {
                this.Hide();
                new AddASchool(db).Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Schools, the searchform will appear and it will be populated with all the Schools data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Schools").Show();
            }
            //Or if they want to modify data, the form to modify the schools data will appear
            else
            {
                this.Hide();
                new AddASchool(db).Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Buses, the searchform will appear and it will be populated with all the Buses data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Bus").Show();
            }
            //Or if they want to modify data, the form to modify the Buses data will appear
            else
            {
                this.Hide();
                new AddABus(db).Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Buses, the searchform will appear and it will be populated with all the Buses data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Bus").Show();
            }
            //Or if they want to modify data, the form to modify the Buses data will appear
            else
            {
                this.Hide();
                new AddABus(db).Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Staff, the searchform will appear and it will be populated with all the Staff data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Staff").Show();
            }
            //Or if they want to modify data, the form to modify the Staff data will appear
            else
            {
                this.Hide();
                new AddStaff(db).Show();
            }
        }
       
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Staff, the searchform will appear and it will be populated with all the Staff data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "Staff").Show();
            }
            //Or if they want to modify data, the form to modify the Staff data will appear
            else
            {
                this.Hide();
                new AddStaff(db).Show();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Bus Booking, the searchform will appear and it will be populated with all the BusBooking data
            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "BusBooking").Show();
            }
            //Or if they want to modify data, the form to modify the BusBooking data will appear
            else
            {
                this.Hide();
                new BusBookingForm(db).Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //If the user wants to search for Bus Booking, the searchform will appear and it will be populated with all the BusBooking data

            if (WhichForm == "Search")
            {
                this.Hide();
                new SearchForm(db, "BusBooking").Show();
            }
            //Or if they want to modify data, the form to modify the BusBooking data will appear
            else
            {
                this.Hide();
                new BusBookingForm(db).Show();
            }
        }
    }
}
