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
using _2WoodSide3190.dbAccess;
using _2WoodSide3190.objects;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Diagnostics;

namespace _2WoodSide3190.gui
{
    public partial class ContactForm : Form
    {
        //Private database db used to connect to the database
        private Database db;

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

        public ContactForm(Database db)
        {
            //This puts the form in the centre of the screen, the makes the border disappear and the edges curved
            InitializeComponent();
            CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //This assigns the passed in database object to the new database object so it can be called in other methods in the form 
            this.db = db;
        }

        private void FinanceForm_Load(object sender, EventArgs e)
        {
            //Refresh the report when the form loads
            //     this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //When the back button is clicked, the main application will appear
            this.Hide();
            new MainApp(db).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update the report with the searched for name when the button is clicked
            this.dataTable1TableAdapter1.FillByName(this.childSet.DataTable1 , textBox1.Text);
            this.reportViewer1.RefreshReport();
        }

        private void fillByNameToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataTable1TableAdapter1.FillByName(this.childSet.DataTable1, textBox1.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //This outputs the data in the grid view to a PDF
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids , out warnings );

            using (FileStream fs = new FileStream("output.pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
            //Put the data in a PDF called output
            Process openPdf = new Process();
            openPdf.StartInfo.FileName = @"output.pdf";
            //Open the PDF
         
            openPdf.Start();

        }
    }
}
