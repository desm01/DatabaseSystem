using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _2WoodSide3190.objects;
using _2WoodSide3190.gui;

namespace _2WoodSide3190.dbAccess
{
    class SchoolDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;

        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and changed
        public SchoolDBAccess(Database db)
        {
            this.db = db;
        }

        //This method updates and modifys entries dependent on the passed in Child ID
        public void updateProject(int schoolId, string schoolName, string schoolLocation, string schoolAddress, string schoolNumber, string schoolEmail)
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "UPDATE Schools SET SchoolName = '"
                + schoolName + "' , SchoolLocation = '"
                + schoolLocation + "' , SchoolAddress = '"
                + schoolAddress + "', SchoolNumber = '"
                + schoolNumber + "', SchoolEmail = '"
                + schoolEmail + "' " + "WHERE SchoolId = "
                + schoolId;
            db.Cmd.ExecuteNonQuery();
        }

        //This method is used to add Schools to the database. These variables are being passed in from the Add A School form
        public void InsertSchool(string SchoolName, string SchoolLocation, string SchoolAddress, int SchoolNumber, string SchoolEmail)
        {
            try
            {
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "INSERT INTO Schools (SchoolName, SchoolLocation, SchoolAddress, SchoolNumber, SchoolEmail) " +
                " VALUES (" + "  '" + SchoolName + "' , '" + SchoolLocation + "' , '" + SchoolAddress + "' , " + SchoolNumber + " , '" + SchoolEmail + "')";
                db.Cmd.ExecuteNonQuery();
            }
            //If there's a problem, display the error form
            catch (SqlException ex)
            {
                new ErrorBox(ex).Show();
            }
        }

        //Show all the Schools in the database
        public List<objects.Schools> getAllSchools()
        {
            //Creates a list of objects of type Schools
            List<Schools> results = new List<Schools>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Schools";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getSchoolFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //This method work to initalize each individual object which will be stored in the list
        public Schools getSchoolFromReader(SqlDataReader reader)
        {
            Schools newSchool = new Schools();
            newSchool.SchoolId = reader.GetInt32(0);
            newSchool.SchoolName = reader.GetString(1);
            newSchool.SchoolLocation = reader.GetString(2);
            newSchool.SchoolAddress = reader.GetString(3);
            newSchool.SchoolNumber = reader.GetInt32(4);
            newSchool.SchoolEmail = reader.GetString(5);
            return newSchool;
        }

        //Show all the Schools which match the entered School Name
        public List <Schools> getSchoolByName(string searchedName)
        {
            //Creates a list of objects of type Schools
            List<Schools> results = new List<Schools>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Schools WHERE SchoolName = '" + searchedName + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getSchoolFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the Schools which match the entered School Number
        public List<Schools> getSchoolByNumber(string number)
        {
            //Creates a list of objects of type Schools
            List<Schools> results = new List<Schools>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Schools WHERE SchoolNumber = '" + number + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getSchoolFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the Schools which match the entered School Location
        public List<Schools> getSchoolByLocation(string searchedLocation)
        {
            //Creates a list of objects of type Schools
            List<Schools> results = new List<Schools>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Schools WHERE SchoolLocation = '" + searchedLocation + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getSchoolFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the Schools which match the entered School ID
        public Schools getSchoolWithID(int id)
        {
            //Creates a list of objects of type Schools
            Schools result = new Schools();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Schools WHERE SchoolId = " + id;
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result = getSchoolFromReader(db.Rdr);
            }
            db.Rdr.Close();
            return result;
        }
    }
}
