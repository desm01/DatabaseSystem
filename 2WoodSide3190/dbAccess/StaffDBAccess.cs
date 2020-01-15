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
    class StaffDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;

        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and chang
        public StaffDBAccess (Database db) 
        {

            this.db = db;
        }

        //Show all the Staff in the database
        public List<objects.Staff> getAllStaff()
        {
            //Creates a list of objects of type Staff
            List<Staff> results = new List<Staff>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Staff";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getStaffFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the Staff which match the entered Staff Name
        public List<Staff> GetStaffByName(string name) 
        {
            //Creates a list of objects of type Staff
            List< Staff> result = new List<Staff>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Staff WHERE StaffName = '" + name +"'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read()) 
            {
                result.Add(getStaffFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //This method updates and modifys entries dependent on the passed in Child ID
        public void updateProject(int StaffId, string StaffName, string StaffNumber, string StaffAddress, string StaffEmail, bool StaffVoluntary)
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "UPDATE Staff SET StaffName = '"
                + StaffName + "' , StaffNumber = '"
                + StaffNumber + "' , StaffAddress = '"
                + StaffAddress + "', StaffEmail = '"
                + StaffEmail + "', StaffVoluntary = '"
                + StaffVoluntary + "' " + "WHERE StaffId = "
                + StaffId;
            db.Cmd.ExecuteNonQuery();
        }

        //This method is used to add Staff to the database. These variables are being passed in from the Add A Staff form
        public void InsertStaff(string StaffName, string StaffNumber, string StaffAddress, string StaffEmail, int StaffVoluntary)
        {
            
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "INSERT INTO Staff (StaffName, StaffNumber, StaffAddress, StaffEmail, StaffVoluntary) " +
                " VALUES (" + "  '" + StaffName + "' , " + StaffNumber + " , '" + StaffAddress + "' , '" + StaffEmail + "' , " + StaffVoluntary + ")";
                db.Cmd.ExecuteNonQuery();
            }



        //Show all the Staff which match the entered voluntary ID
        public List<Staff> getStaffByVoluntary(bool decider) 
        {
            //Creates a list of objects of type Staff
            List<Staff> result = new List<Staff>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Staff Where Voluntary = " + decider;
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read()) 
            {
                result.Add(getStaffFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //Show all the Staff which match the entered Staff ID
        public List<Staff> getStaffWithID(int id)
        {
            //Creates a list of objects of type Staff
            List<Staff> result = new List <Staff>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Staff WHERE StaffId = " + id;
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getStaffFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //This method work to initalize each individual object which will be stored in the list
        public Staff getStaffFromReader(SqlDataReader reader)
        {
            Staff newStaff = new Staff();
            newStaff.StaffId = reader.GetInt32(0);
            newStaff.StaffName = reader.GetString(1);
            newStaff.StaffNumber = reader.GetInt32(2);
            newStaff.StaffAddress = reader.GetString(3);
            newStaff.StaffEmail = reader.GetString(4);
            newStaff.StaffVoluntary = reader.GetBoolean(5);
            return newStaff;
        }

    }
}
