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
    class BusDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;


        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and changed

        public BusDBAccess(Database db) 
    {
            this.db = db;
    }
        //This method is used to add Buses to the database. These variables are being passed in from the Add A Bus form

        public void InsertBus(string BusRoute, string Driver, int Time) 
    {
        
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "INSERT INTO Bus (BusRoute, Driver, Time) " +
                " VALUES (" + "'" + BusRoute + "', '" + Driver + "', " + Time + ")";
                db.Cmd.ExecuteNonQuery();
    
        }

        //This method updates and modifys entries dependent on the passed in booking ID
        public void ModifyBus(int busId, string busRoute, string driver, int time) 
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "UPDATE Bus SET BusRoute = '" + busRoute + "' , Driver = '" + driver + "', Time = " + time + "  WHERE BusId = " + busId;
            db.Cmd.ExecuteNonQuery();
        }

        //Show all the buses which match the entered driver name

        public List<Bus> getWhereDriverIs(string driverName)
        {
            //Creates a list of objects of type bus
            List<Bus> results = new List<Bus>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Bus WHERE Driver = '" + driverName + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getBusFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }
        //Show all the buses which match the entered drivers route
        public List<Bus> getWhereRouteIs(string route)
        {
            //Creates a list of objects of type bus
            List<Bus> results = new List<Bus>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Bus WHERE BusRoute = '" + route + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getBusFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the buses which match the entered route time
        public List<Bus> getWhereTimeIs(string descion, string time)
        {
            //Creates a list of objects of type bus
            List<Bus> results = new List<Bus>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Bus WHERE Time " + descion +  " " + time + "";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getBusFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //This method work to initalize each individual object which will be stored in the list
        public Bus getBusFromReader(SqlDataReader reader)
        {
            Bus newBus = new Bus();
            newBus.BusId = reader.GetInt32(0);
            newBus.BusDriver = reader.GetString(1);
            newBus.BusRoute = reader.GetString(2);
            newBus.BusTime = reader.GetInt32(3);
            return newBus;
        }

        //This method gets all the buses from the database
        public List<objects.Bus> getAllBus()
        {
            //Creates a list of objects of type bus
            List<Bus> results = new List<Bus>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Bus";
            db.Rdr = db.Cmd.ExecuteReader();

            while (db.Rdr.Read())
            {
                results.Add(getBusFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

    }
}
