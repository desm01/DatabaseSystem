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

namespace _2WoodSide3190.gui
{
    public partial class SelectAParentForm : Form
    {
        private int parentId;
        private DataTable table;
        private Database db;

        private int numsBeforeAdd = 0;

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

        public SelectAParentForm(Database db)
        {
            InitializeComponent();
            CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.db = db;
            ParentDBAccess pdba = new ParentDBAccess(db);
            createTableToChooseParents(pdba.SelectAllParents());
        }

        private void createTableToChooseParents(List<Parent> list)
        {
            table = new DataTable();
            table.Columns.Add("Parent ID");
            table.Columns.Add("Parent Name");
            table.Columns.Add("Parent Phone");
            table.Columns.Add("Parent Email");
            table.Columns.Add("Parent Address");
            table.Columns.Add("Parent Occupation");

            foreach (Parent prnt in list)
            {
                table.Rows.Add(prnt.ParentId, prnt.ParentName, prnt.ParentPhone, prnt.ParentEmail, prnt.ParentAddress, prnt.ParentOccupation);
            }

            parentResults.DataSource = table;


        }

        private void SelectAParentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'woodSide3190DataSet.Parent' table. You can move, or remove it, as needed.


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SearchedName = textBox1.Text;
            ParentDBAccess pdba = new ParentDBAccess(db);
            SelectAllWhereName(pdba.SelectAllParentsWhereName(SearchedName));

        }


        private void SelectAllWhereName(List<Parent> list)
        {
            table = new DataTable();
            table.Columns.Add("Parent ID");
            table.Columns.Add("Parent Name");
            table.Columns.Add("Parent Phone");
            table.Columns.Add("Parent Email");
            table.Columns.Add("Parent Address");
            table.Columns.Add("Parent Occupation");

              foreach (Parent prnt in list)
                {
                  table.Rows.Add(prnt.ParentId, prnt.ParentName, prnt.ParentPhone, prnt.ParentEmail, prnt.ParentAddress, prnt.ParentOccupation);
               } 

            parentResults.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        //Create an object of type ParentDBAccess, this allows the user to get access to the methods
            ParentDBAccess pdba = new ParentDBAccess(db);
            //Update the table tp show all the parents
            createTableToChooseParents(pdba.SelectAllParents());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        //Take the entered text and pass it into a variable
            string SearchedName = textBox1.Text;
            //Create a new ParentDBAcccess, giving access to the methods in that class
            ParentDBAccess pdba = new ParentDBAccess(db);
            //If the textbox is left empty diplay an error message
            if (SearchedName == "")
            {
                MessageBox.Show("Error, SearchBox Must Not Be Left Blank ");
            }
            //If it's not empty, update the table to show all the names in the database that match the searched for parents name
            else
            {
                SelectAllWhereName(pdba.SelectAllParentsWhereName(SearchedName));
            }
        }
        //When a cell is clicked
        private void parentResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //If the row has been clicked
            if (parentResults.SelectedRows.Count >= 0)
            {
            //Take the ParentID from the selected row and show the AddChild Form, the selected Parent ID is passed into this form too 
                DataGridViewRow row = this.parentResults.Rows[e.RowIndex];
                int parentId = Convert.ToInt32(row.Cells["Parent Id"].Value.ToString());
                this.Hide();
                new AddChild(db, parentId).Show();
            }
        }
        //If the picture is clicked, the main app will appear
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }
        //if the label is clicked, the main app will appear
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainApp(db).Show();
        }
    }

}