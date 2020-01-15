namespace _2WoodSide3190.gui
{
    partial class BookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bookResults = new System.Windows.Forms.DataGridView();
            this.childId = new System.Windows.Forms.TextBox();
            this.busBookingId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.cancelled = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.afterSchoolsClubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeABookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookAPlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.busToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCancellationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crecheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adviceServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bookResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(54, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Child ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(54, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bus Booking ID";
            // 
            // bookResults
            // 
            this.bookResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.bookResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookResults.GridColor = System.Drawing.Color.Red;
            this.bookResults.Location = new System.Drawing.Point(384, 96);
            this.bookResults.Name = "bookResults";
            this.bookResults.Size = new System.Drawing.Size(698, 348);
            this.bookResults.TabIndex = 2;
            this.bookResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookResults_CellClick);
            this.bookResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookResults_CellContentClick);
            // 
            // childId
            // 
            this.childId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.childId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.childId.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.childId.ForeColor = System.Drawing.Color.Red;
            this.childId.Location = new System.Drawing.Point(41, 79);
            this.childId.Name = "childId";
            this.childId.Size = new System.Drawing.Size(278, 25);
            this.childId.TabIndex = 0;
            // 
            // busBookingId
            // 
            this.busBookingId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.busBookingId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.busBookingId.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.busBookingId.ForeColor = System.Drawing.Color.Red;
            this.busBookingId.Location = new System.Drawing.Point(41, 181);
            this.busBookingId.Name = "busBookingId";
            this.busBookingId.Size = new System.Drawing.Size(278, 25);
            this.busBookingId.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(66, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Paid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(66, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Date";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(58, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 64);
            this.button1.TabIndex = 4;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(202, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 64);
            this.button2.TabIndex = 5;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.comboBox1.ForeColor = System.Drawing.Color.Red;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(411, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 32);
            this.comboBox1.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(951, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 43);
            this.button3.TabIndex = 8;
            this.button3.Text = "View";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // date
            // 
            this.date.CalendarForeColor = System.Drawing.Color.Red;
            this.date.CalendarMonthBackground = System.Drawing.Color.Blue;
            this.date.CalendarTitleBackColor = System.Drawing.Color.Black;
            this.date.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.date.CalendarTrailingForeColor = System.Drawing.Color.Red;
            this.date.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.date.Location = new System.Drawing.Point(41, 351);
            this.date.Name = "date";
            this.date.RightToLeftLayout = true;
            this.date.Size = new System.Drawing.Size(278, 32);
            this.date.TabIndex = 3;
            // 
            // cancelled
            // 
            this.cancelled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.cancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelled.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.cancelled.ForeColor = System.Drawing.Color.Red;
            this.cancelled.FormattingEnabled = true;
            this.cancelled.Location = new System.Drawing.Point(41, 278);
            this.cancelled.Name = "cancelled";
            this.cancelled.Size = new System.Drawing.Size(278, 32);
            this.cancelled.TabIndex = 2;
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.searchBox.ForeColor = System.Drawing.Color.Red;
            this.searchBox.Location = new System.Drawing.Point(605, 40);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(316, 25);
            this.searchBox.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(444, 450);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 54);
            this.button4.TabIndex = 9;
            this.button4.Text = "Modify Row";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(227, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Show Children";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(227, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "Show BusBooking";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_2WoodSide3190.Properties.Resources.Question;
            this.pictureBox1.Location = new System.Drawing.Point(1088, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(740, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 48);
            this.label7.TabIndex = 24;
            this.label7.Text = "You Can Only Modify \r\nOne Row At A Time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afterSchoolsClubToolStripMenuItem,
            this.crecheToolStripMenuItem,
            this.transportServicesToolStripMenuItem,
            this.adviceServiceToolStripMenuItem,
            this.classesToolStripMenuItem,
            this.groupsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1222, 28);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // afterSchoolsClubToolStripMenuItem
            // 
            this.afterSchoolsClubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeABookingToolStripMenuItem,
            this.addAChildToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.modifyDataToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.viewCancellationsToolStripMenuItem});
            this.afterSchoolsClubToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.afterSchoolsClubToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.afterSchoolsClubToolStripMenuItem.Name = "afterSchoolsClubToolStripMenuItem";
            this.afterSchoolsClubToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.afterSchoolsClubToolStripMenuItem.Text = "After-Schools Club";
            // 
            // makeABookingToolStripMenuItem
            // 
            this.makeABookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.busBookingToolStripMenuItem,
            this.bookAPlaceToolStripMenuItem});
            this.makeABookingToolStripMenuItem.Name = "makeABookingToolStripMenuItem";
            this.makeABookingToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.makeABookingToolStripMenuItem.Text = "Make a booking";
            // 
            // busBookingToolStripMenuItem
            // 
            this.busBookingToolStripMenuItem.Name = "busBookingToolStripMenuItem";
            this.busBookingToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.busBookingToolStripMenuItem.Text = "Bus Booking";
            this.busBookingToolStripMenuItem.Click += new System.EventHandler(this.busBookingToolStripMenuItem_Click);
            // 
            // bookAPlaceToolStripMenuItem
            // 
            this.bookAPlaceToolStripMenuItem.Name = "bookAPlaceToolStripMenuItem";
            this.bookAPlaceToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.bookAPlaceToolStripMenuItem.Text = "Book a place";
            this.bookAPlaceToolStripMenuItem.Click += new System.EventHandler(this.bookAPlaceToolStripMenuItem_Click);
            // 
            // addAChildToolStripMenuItem
            // 
            this.addAChildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.childToolStripMenuItem,
            this.parentToolStripMenuItem,
            this.busToolStripMenuItem,
            this.schoolToolStripMenuItem,
            this.staffToolStripMenuItem});
            this.addAChildToolStripMenuItem.Name = "addAChildToolStripMenuItem";
            this.addAChildToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.addAChildToolStripMenuItem.Text = "Add Data";
            // 
            // childToolStripMenuItem
            // 
            this.childToolStripMenuItem.Name = "childToolStripMenuItem";
            this.childToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.childToolStripMenuItem.Text = "Child";
            this.childToolStripMenuItem.Click += new System.EventHandler(this.childToolStripMenuItem_Click);
            // 
            // parentToolStripMenuItem
            // 
            this.parentToolStripMenuItem.Name = "parentToolStripMenuItem";
            this.parentToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.parentToolStripMenuItem.Text = "Parent";
            this.parentToolStripMenuItem.Click += new System.EventHandler(this.parentToolStripMenuItem_Click);
            // 
            // busToolStripMenuItem
            // 
            this.busToolStripMenuItem.Name = "busToolStripMenuItem";
            this.busToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.busToolStripMenuItem.Text = "Bus";
            this.busToolStripMenuItem.Click += new System.EventHandler(this.busToolStripMenuItem_Click);
            // 
            // schoolToolStripMenuItem
            // 
            this.schoolToolStripMenuItem.Name = "schoolToolStripMenuItem";
            this.schoolToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.schoolToolStripMenuItem.Text = "School";
            this.schoolToolStripMenuItem.Click += new System.EventHandler(this.schoolToolStripMenuItem_Click);
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.staffToolStripMenuItem.Text = "Staff";
            this.staffToolStripMenuItem.Click += new System.EventHandler(this.staffToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.cancelToolStripMenuItem.Text = "Cancel an appointment";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // modifyDataToolStripMenuItem
            // 
            this.modifyDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.childToolStripMenuItem1,
            this.parentToolStripMenuItem1,
            this.staffToolStripMenuItem1,
            this.busToolStripMenuItem1,
            this.schoolToolStripMenuItem1});
            this.modifyDataToolStripMenuItem.Name = "modifyDataToolStripMenuItem";
            this.modifyDataToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.modifyDataToolStripMenuItem.Text = "Modify Data";
            // 
            // childToolStripMenuItem1
            // 
            this.childToolStripMenuItem1.Name = "childToolStripMenuItem1";
            this.childToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.childToolStripMenuItem1.Text = "Child";
            this.childToolStripMenuItem1.Click += new System.EventHandler(this.childToolStripMenuItem1_Click);
            // 
            // parentToolStripMenuItem1
            // 
            this.parentToolStripMenuItem1.Name = "parentToolStripMenuItem1";
            this.parentToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.parentToolStripMenuItem1.Text = "Parent";
            this.parentToolStripMenuItem1.Click += new System.EventHandler(this.parentToolStripMenuItem1_Click);
            // 
            // staffToolStripMenuItem1
            // 
            this.staffToolStripMenuItem1.Name = "staffToolStripMenuItem1";
            this.staffToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.staffToolStripMenuItem1.Text = "Staff";
            this.staffToolStripMenuItem1.Click += new System.EventHandler(this.staffToolStripMenuItem1_Click);
            // 
            // busToolStripMenuItem1
            // 
            this.busToolStripMenuItem1.Name = "busToolStripMenuItem1";
            this.busToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.busToolStripMenuItem1.Text = "Bus";
            this.busToolStripMenuItem1.Click += new System.EventHandler(this.busToolStripMenuItem1_Click);
            // 
            // schoolToolStripMenuItem1
            // 
            this.schoolToolStripMenuItem1.Name = "schoolToolStripMenuItem1";
            this.schoolToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.schoolToolStripMenuItem1.Text = "School";
            this.schoolToolStripMenuItem1.Click += new System.EventHandler(this.schoolToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // viewCancellationsToolStripMenuItem
            // 
            this.viewCancellationsToolStripMenuItem.Name = "viewCancellationsToolStripMenuItem";
            this.viewCancellationsToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.viewCancellationsToolStripMenuItem.Text = "View Cancellations";
            this.viewCancellationsToolStripMenuItem.Click += new System.EventHandler(this.viewCancellationsToolStripMenuItem_Click);
            // 
            // crecheToolStripMenuItem
            // 
            this.crecheToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.crecheToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.crecheToolStripMenuItem.Name = "crecheToolStripMenuItem";
            this.crecheToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.crecheToolStripMenuItem.Text = "Creche";
            // 
            // transportServicesToolStripMenuItem
            // 
            this.transportServicesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.transportServicesToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.transportServicesToolStripMenuItem.Name = "transportServicesToolStripMenuItem";
            this.transportServicesToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.transportServicesToolStripMenuItem.Text = "Transport Services";
            // 
            // adviceServiceToolStripMenuItem
            // 
            this.adviceServiceToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.adviceServiceToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.adviceServiceToolStripMenuItem.Name = "adviceServiceToolStripMenuItem";
            this.adviceServiceToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.adviceServiceToolStripMenuItem.Text = "Advice Service";
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.classesToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.classesToolStripMenuItem.Text = "Classes";
            // 
            // groupsToolStripMenuItem
            // 
            this.groupsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupsToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
            this.groupsToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.groupsToolStripMenuItem.Text = "Groups";
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1222, 516);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.cancelled);
            this.Controls.Add(this.date);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.busBookingId);
            this.Controls.Add(this.childId);
            this.Controls.Add(this.bookResults);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BookingForm";
            this.Text = "BookingForm";
            ((System.ComponentModel.ISupportInitialize)(this.bookResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView bookResults;
        private System.Windows.Forms.TextBox childId;
        private System.Windows.Forms.TextBox busBookingId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.ComboBox cancelled;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem afterSchoolsClubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeABookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookAPlaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem childToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem childToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem busToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem schoolToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCancellationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crecheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adviceServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupsToolStripMenuItem;
    }
}