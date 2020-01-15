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
    public partial class SuccessForm : Form
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
        //The name of the registered child is passed in
        private Database db;

        public SuccessForm(Database db, String text)
        {
            InitializeComponent();
            //Put the form in the middle of the screen
            CenterToScreen();
            //This gets rid of the border and sets the borders as curved
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //The registered childs name is displayed
            label1.Text = text;
            this.db = db;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        //The form dissappears and the main application appears
            Hide();
            new MainApp(db).Show();
        }
    }
}

