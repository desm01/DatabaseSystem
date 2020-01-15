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
    public partial class MenuSelection : Form
    {
    //Declare a private variable db of type Database
        private Database db;

        //This code makes the borders of the form curved
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

           //Constructor
        public MenuSelection()
        {
        //Set the form in the middle of the screen and make the borders disappear and edges curved
            InitializeComponent();
            CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }
        //If the after-schools club button is clicked, the login form will appear
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
        //If a button is clicked for any area but the after-schools club, an error will appear saying the selected area is coming soon
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creche is coming soon");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transport Services is coming soon");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advice services is coming soon");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Classes is coming soon");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Groups is coming soon");
        }
        //If the 'X' picture is clicked; the program will close 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //If the 'Minimization' button is clicked; the form will be minimized to the application tray
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //If the tool strip is clicked, the an error will appear saying the choosen area is coming soon
        private void crecheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creche is coming soon");
        }

        private void transportServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transport is coming soon");
        }

        private void adviceServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advice is coming soon");
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Classes is coming soon");
        }

        private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Groups is coming soon");
        }

        private void childToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void parentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

    }
}
