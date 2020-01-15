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
using _2WoodSide3190.gui;

namespace _2WoodSide3190
{
    public partial class LoginForm : Form
    {
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

        public LoginForm()
        {
        //This puts the form in the centre of the screen and makes the edges curved
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //A new database object is created using the SQL connection string from the textbox
          Database db = new Database(textBox1.Text);
            //Connect to the database
            db.connect();
            
            //show the main application
                this.Hide();
             new MainApp(db).Show();
     

        }
    }
}
