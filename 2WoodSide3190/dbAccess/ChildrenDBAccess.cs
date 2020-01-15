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
    class ChildrenDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;

        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and changed
        public ChildrenDBAccess(Database db)
        {
            this.db = db;
        }

        //This method work to initalize each individual object which will be stored in the list
        public Children getChildrenFromReader(SqlDataReader reader)
        {
            Children newChild = new Children();
            newChild.ChildId = reader.GetInt32(0);
            newChild.ParentId = reader.GetInt32(1);
            newChild.SchoolId = reader.GetInt32(2);
            newChild.ChildName = reader.GetString(3);
            newChild.MedicalDetails = reader.GetString(4);
            newChild.Age = reader.GetInt32(5);
            return newChild;
        }

        //This method is used to add Children to the database. These variables are being passed in from the Add A Child form
        public void InsertChild( int parentId, int schoolId, string childName, string medicalDetails, int childAge)
        {
       //     try
        //    {
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "INSERT INTO Children ( ParentId, SchoolId, ChildName, MedicalDetails, ChildAge) " +
                " VALUES (" + "" + parentId + ", " + schoolId + ", '" + childName + "', '" + medicalDetails + "', " + childAge + ")";
                db.Cmd.ExecuteNonQuery();
         //   }
            //If there's a problem, display the error form
          //  catch (SqlException ex) 
          //  {
          //      new ErrorBox(ex).Show();
          //  }
        }


        //This method updates and modifys entries dependent on the passed in Child ID

        public void updateProject(int childId, int parentId, int schoolId, string name, string medicalDetails, int age)
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "UPDATE Children SET ChildName = '"
                + name + "' , MedicalDetails = '"
                + medicalDetails + "' , ChildAge = "
                + age + " WHERE ChildId = " + childId;
            db.Cmd.ExecuteNonQuery();
        }

        //Show all the Children which match the entered child name
        public List<Children> GetChildByName(string searchedName) 
        {
            //Creates a list of objects of type children
            List<Children> results = new List <Children>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Children WHERE ChildName = '" + searchedName + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getChildrenFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }
        //Show all the Children which match the entered medical details
        public List<Children> getChildByMedicalDetails()
        {
            //Creates a list of objects of type children
            List<Children> results = new List<Children>();

            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Children WHERE MedicalDetails != 'None'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getChildrenFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the Children which match the entered child age
        public List<Children> GetChildByAge(string decider, string searchedAge)
        {
            //Creates a list of objects of type children
            List<Children> results = new List<Children>();
            try
            {
               
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "SELECT * FROM Children WHERE ChildAge " + decider + " " + searchedAge;
                db.Rdr = db.Cmd.ExecuteReader();
                //Populates the list of objects with entries from the database where the searched for criteria is met
                while (db.Rdr.Read())
                {
                    results.Add(getChildrenFromReader(db.Rdr));
                }
                db.Rdr.Close();
                return results;
            }
            catch(SqlException ex)
            { new ErrorBox(ex).Show(); return results; }
        }

        //Show all the Children in the database
        public List<objects.Children> GetAllChildren()
        {
            //Creates a list of objects of type children
            List<Children> results = new List<Children>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Children";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getChildrenFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the Children which match the entered child ID
        public Children getChildWithID(int id)
        {
            //Creates a list of objects of type children
            Children result = new Children();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Children WHERE ChildId = " + id;
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result = getChildrenFromReader(db.Rdr);
            }
            db.Rdr.Close();
            return result;
        }
    }
}
