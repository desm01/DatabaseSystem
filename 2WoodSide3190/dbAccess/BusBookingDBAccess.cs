using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2WoodSide3190.objects;
using System.Data.SqlClient;
using _2WoodSide3190.gui;

namespace _2WoodSide3190.dbAccess
{
    class BusBookingDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;

        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and changed

        public BusBookingDBAccess(Database db)
        {
            this.db = db;
        }
        //This method is used to add bus bookings to the database. These variables are being passed in from the bus booking form

        public void InsertBusBook(int BusId, int StaffId)
        {
            try
            {
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "INSERT INTO BusBooking (BusId, StaffId )" +
                " VALUES (" + "  " + BusId + " , " + StaffId + ")";
                db.Cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                new ErrorBox(ex).Show();
            }

        }

        //This method updates and modifys entries dependent on the passed in bus booking ID
        public void UpdateBooking(int busBookingId, int staffId, int busId)
        {

            try {
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "UPDATE BusBooking SET StaffId = " + staffId + " , BusId = " + busId + "" + "  WHERE BusBookingId = " + busBookingId;
                db.Cmd.ExecuteNonQuery();
            } 
            catch(SqlException ex) { new ErrorBox(ex).Show(); }
            }

        //Show all the bus bookings which match the entered ID
        public List<BusBooking> SelectWhereBookingID(int bookingId)
        {
            //Creates a list of objects of type bus booking
            List<BusBooking> results = new List<BusBooking>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM BusBooking WHERE BusBookingId = " + bookingId + "";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getBusBookingFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        public List<objects.BusBooking> getAllBusBooking()
        {
            //Creates a list of objects of type bus booking
            List<BusBooking> results = new List<BusBooking>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM BusBooking";
            db.Rdr = db.Cmd.ExecuteReader();

            while (db.Rdr.Read())
            {
                results.Add(getBusBookingFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //This method work to initalize each individual object which will be stored in the list
        public BusBooking getBusBookingFromReader(SqlDataReader reader)
        {
            BusBooking newBus = new BusBooking();
            newBus.BusBookingId = reader.GetInt32(0);
            newBus.BusId = reader.GetInt32(1);
            newBus.StaffId = reader.GetInt32(2);
            return newBus;
        }
    }
}