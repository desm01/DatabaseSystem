using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace _2WoodSide3190.gui
{
    public partial class ErrorBox : Form
    {

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
        //Pass in an SQL Exception
        public ErrorBox(SqlException ex)
        {
            try
            {
                //Put the form in the centre of the screen, make borders disapper and the edges curved
                InitializeComponent();
                CenterToScreen();
                this.FormBorderStyle = FormBorderStyle.None;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                //Set the text on the screen to whatever the error message is
                label2.Text = ex.ToString();
            }
            //If there's a problem in passing in the message show a generic error
            catch 
            {
                label2.Text = "ERROR !";
            }
        }
        //Close the application
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
