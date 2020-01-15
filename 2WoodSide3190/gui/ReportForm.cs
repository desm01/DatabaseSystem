using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2WoodSide3190.gui;
using _2WoodSide3190.objects;
using System.Runtime.InteropServices;

namespace _2WoodSide3190
{
    public partial class ReportForm : Form
    {
    //Make the current form curved
        private Database db;
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
        public ReportForm(Database db)
        {
        //Put the form in the centre of the screen and make the borders disappear and the edges curved
            InitializeComponent();
            CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.db = db;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Reporting.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.Reporting.DataTable1);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //When the back button is clicked, make the main application appear
            this.Hide();
            new MainApp(db).Show();
        }
        //When the search button is clicked, fill the report using the selected datetime
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime time = dateTimePicker1.Value.Date;
                //Convert the DateTime to this format so it will work
                var time1 = time.ToString("MM-dd-yyyy");

                this.dataTable1TableAdapter1.FillByDate(this.Reporting.DataTable1, Convert.ToDateTime(time1));
                this.reportViewer1.RefreshReport();
            }
            catch { }
        }
    }
}
