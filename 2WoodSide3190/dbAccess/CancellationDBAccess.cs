using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2WoodSide3190.objects;
using _2WoodSide3190.gui;
using System.Data.SqlClient;

namespace _2WoodSide3190.dbAccess
{
    class CancellationDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;

        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and changed
        public CancellationDBAccess(Database db) 
    {
            this.db = db;
    }

        //This method gets all the Cancellation from the database
        public List<objects.Cancellation> getAllCancellation()
        {
            //Creates a list of objects of type Cancellation
            List<Cancellation> results = new List<Cancellation>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Cancellation";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getCancellationFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //This method work to initalize each individual object which will be stored in the list
        public Cancellation getCancellationFromReader(SqlDataReader reader)
        {
            Cancellation newCancell = new Cancellation();
            newCancell.CancellationId = reader.GetInt32(0);
            newCancell.BookingId = reader.GetInt32(1);
            newCancell.ChildId = reader.GetInt32(2);
            newCancell.Date = reader.GetDateTime(3);
            newCancell.Reason = reader.GetString(4);

            return newCancell ;
        }

        //This method updates and modifys entries dependent on the passed in Cancellation ID

        public void updateProject(int CancellationId, int BookingId, int ChildId, DateTime date, string reason) 
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "UPDATE Cancellation SET BookingId = "
            + BookingId + " , ChildId = "
            + ChildId + " , Date = '"
            + date + "' , Reason = '" + reason + "' WHERE CancellationId = " + CancellationId;
            db.Cmd.ExecuteNonQuery();
        }

        //This method is used to add cancellations to the database. These variables are being passed in from the cancellation form

        public void InsertCancell( int bookingId, int childId, DateTime Date, string reason) 
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "INSERT INTO Cancellation (BookingId, ChildId, Date, Reason) " +
            " VALUES ("  +  "" + bookingId + ", " + childId + ", '" + Date + "', '" + reason + "')";
            db.Cmd.ExecuteNonQuery();
        }

        //This method gets all the Cancellation from the database
        public List<Cancellation> GetCancellByName(string reason)
        {
            //Creates a list of objects of type Cancellation
            List<Cancellation> results = new List<Cancellation>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Cancellation WHERE Reason = '" + reason + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getCancellationFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }


    }
}
