using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _2WoodSide3190.gui;
using _2WoodSide3190.objects;

namespace _2WoodSide3190.dbAccess
{
    class BookingDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;

        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and changed
    public BookingDBAccess (Database db) 
    {
            this.db = db;    
    }
        //This method is used to add bookings to the database. These variables are being passed in from the booking form
        public void InsertBooking(int ChildId, int BusBookingId, int cancelled, string time)
        {
            try
            {
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "INSERT INTO Booking (ChildId, BusBookingId, Paid, Date) " +
                " VALUES (" + ChildId + " , " + BusBookingId + " , " + cancelled + " , '" + time + "' " + ")";
                db.Cmd.ExecuteNonQuery();
            }
            //If there's a problem, display the error form
           catch (SqlException ex)
            {
                new ErrorBox(ex).Show();
            }
            }


        
    //Show all the bookings which match the entered ID
        public List<Booking> getBookWithID(int id)
        {
            //Creates a list of objects of type booking
           List <Booking> result = new List<Booking>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Booking WHERE BookingId = " + id;
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getBookFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }
        //This method work to initalize each individual object which will be stored in the list
        public Booking getBookFromReader(SqlDataReader reader)
        {

            try {
                Booking newBook = new Booking();
                newBook.BookingId = reader.GetInt32(0);
                newBook.ChildId = reader.GetInt32(1);
                newBook.BusBookingId = reader.GetInt32(2);
                newBook.Paid = reader.GetBoolean(3);
                newBook.Time = reader.GetDateTime(4);
                return newBook;
            }
            catch { return null; }
        }

        //This method deletes entries from the booking table where the entered Booking ID matches entries in the database with the same booking id
        public void DeleteEntry(int id)
        {

            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "DELETE FROM Booking WHERE BookingId = " + id;
            db.Rdr = db.Cmd.ExecuteReader();
        }



            //This adds up and calculates how many people have not paid
        public List<Booking> calculateBooking() 
        {
            //Creates a list of objects of type booking

            List<Booking> results = new List<Booking>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT COUNT(Paid) FROM Booking WHERE Paid = 'False'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read()) 
            {
                results.Add(getBookFromReader(db.Rdr));

            }
            db.Rdr.Close();
            return results;
        }

        //This method gets all the bookings from the database
        public List<objects.Booking> getAllBook()
        {
            List<Booking> results = new List<Booking>();
            //Creates a list of objects of type booking
            try
            {
              
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "SELECT * FROM Booking";
                db.Rdr = db.Cmd.ExecuteReader();
            }
            catch { }
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getBookFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //This method updates and modifys entries dependent on the passed in booking ID
        public void UpdateBooking(int bookingId, int childId, int busBookingId, bool paid, DateTime time  ) 
        {
            try
            {
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "UPDATE Booking SET ChildId = " + childId + " , BusBookingId = " + busBookingId + ", Paid = " +paid + ", Date = " + time + "  WHERE BookingId = " + bookingId;
                db.Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { new ErrorBox(ex).Show(); }
        }

        
      /*  public BusBooking SelectWhereBookingID(int bookingId)
        {
            BusBooking results = new BusBooking();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM BusBooking WHERE BusBookingId = " + bookingId + "";
            db.Rdr = db.Cmd.ExecuteReader();

            while (db.Rdr.Read())
            {
               // results = getBookFromReader(db.Rdr);
            }
            db.Rdr.Close();
            return results;
        }
        */
    }
}
