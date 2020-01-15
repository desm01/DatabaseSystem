using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2WoodSide3190.objects;
using System.Data.SqlClient;

namespace _2WoodSide3190.dbAccess
{
    class InnerJoinDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;

        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and changed
        public InnerJoinDBAccess(Database db) 
        {
            this.db = db;
        }

        //Show all the Children and Parents which are rergistered in the database that match the entered childrens name
        public List <ChildParentJoin> GetChildrenAndParentWhereChildName(string name) 
        {
            //Creates a list of objects of type children and parents
            List<ChildParentJoin> result = new List<ChildParentJoin>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT Children.ChildId, Children.ChildName, Children.ChildAge, Children.MedicalDetails, Parent.ParentName, Parent.ParentEmail, Parent.ParentPhone, Parent.ParentAddress, Schools.SchoolName FROM Children INNER JOIN Parent ON Children.ParentId = Parent.ParentId INNER JOIN Schools ON Children.SchoolId = Schools.SchoolId WHERE Children.ChildName = '" + name + "';";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getChildrenAndParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //Show all the Children and Parents which are rergistered in the database 
        public List <ChildParentJoin> GetChildrenAndParentWhereParentName( string name) 
        {
            //Creates a list of objects of type children and parents
            List<ChildParentJoin> result  = new List<ChildParentJoin>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT Children.ChildId, Children.ChildName, Children.ChildAge, Children.MedicalDetails, Parent.ParentName, Parent.ParentEmail, Parent.ParentPhone, Parent.ParentAddress, Schools.SchoolName FROM Children INNER JOIN Parent ON Children.ParentId = Parent.ParentId INNER JOIN Schools ON Children.SchoolId = Schools.SchoolId WHERE Parent.ParentName = '" + name + "';";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getChildrenAndParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //Show all the Booking entries which are registed in the database
                public List<BookingJoin> GetBookingWithName(string name) 
        {
            //Creates a list of objects of type BookingJoin
            List<BookingJoin> result = new List<BookingJoin>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT Booking.BookingId, Booking.Date, Booking.Paid, Children.ChildName, Children.ChildAge FROM Booking INNER JOIN Children ON Booking.ChildId = Children.ChildId WHERE Children.ChildName = '" + name + "';";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read()) 
            {
                result.Add(getBookingFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
       }
        //Show all the Booking entries which are registed in the database
        public List <BookingJoin> GetAllBooking() 
        {
            //Creates a list of objects of type BookingJoin
            List<BookingJoin> result = new List<BookingJoin>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT Booking.BookingId, Booking.Date, Booking.Paid, Children.ChildName, Children.ChildAge FROM Booking INNER JOIN Children ON Booking.ChildId = Children.ChildId;";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read()) 
            {
                result.Add(getBookingFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        public  List<BookingJoin> GetBookingWithPaid(int paid) 
        {
            List<BookingJoin> result = new List<BookingJoin>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT Booking.BookingId, Booking.Date, Booking.Paid, Children.ChildName, Children.ChildAge FROM Booking INNER JOIN Children ON Booking.ChildId = Children.ChildId WHERE Booking.Paid = " + paid + "";
            db.Rdr = db.Cmd.ExecuteReader();

            while(db.Rdr.Read()) 
            {
                result.Add(getBookingFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }
        //This method work to initalize each individual object which will be stored in the list
        public BookingJoin getBookingFromReader(SqlDataReader reader) 
        {
            BookingJoin newBook = new BookingJoin();
            newBook.BookingId = reader.GetInt32(0);
            newBook.Date = reader.GetDateTime(1);
            newBook.Paid = reader.GetBoolean(2);
            newBook.Name = reader.GetString(3);
            newBook.Age = reader.GetInt32(4);

            return newBook;
        }
        //This method work to initalize each individual object which will be stored in the list
        public ChildParentJoin getChildrenAndParentFromReader(SqlDataReader reader)
        {
            ChildParentJoin newChild = new ChildParentJoin();
            newChild.ChildId = reader.GetInt32(0);
            newChild.ChildName = reader.GetString(1);
            newChild.Age = reader.GetInt32(2);
            newChild.MedicalDetails = reader.GetString(3);
            newChild.ParentName = reader.GetString(4);
            newChild.ParentEmail = reader.GetString(5);
            newChild.ParentPhone = reader.GetString(6);
            newChild.Address = reader.GetString(7);
            newChild.SchoolName = reader.GetString(8);
            return newChild;
        }

        //Show all the Children and Parents which are rergistered in the database
        public List<ChildParentJoin> GetChildAndParent()
        {
            //Creates a list of objects of type children and parents
            List<ChildParentJoin> result = new List<ChildParentJoin>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT Children.ChildId, Children.ChildName, Children.ChildAge, Children.MedicalDetails, Parent.ParentName, Parent.ParentEmail, Parent.ParentPhone, Parent.ParentAddress, Schools.SchoolName FROM Children INNER JOIN Parent ON Children.ParentId = Parent.ParentId INNER JOIN Schools ON Children.SchoolId = Schools.SchoolId;";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getChildrenAndParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

    }
}