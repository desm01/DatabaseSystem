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
    class ParentDBAccess
    {
        //Private database db used to connect to the SQL database
        private Database db;

        //Constructor passes in the Database object from the form and uses it here to gain access to the SQL Database, so the database can be edited and changed
        public ParentDBAccess(Database db)
        {
            this.db = db;
        }

        //This method work to initalize each individual object which will be stored in the list

        public Parent getParentFromReader(SqlDataReader reader)
        {
            Parent newParent = new Parent();
            newParent.ParentId = reader.GetInt32(0);
            newParent.ParentName = reader.GetString(1);
            newParent.ParentPhone = reader.GetString(2);
            newParent.ParentEmail = reader.GetString(3);
            newParent.ParentAddress = reader.GetString(4);
            newParent.ParentOccupation = reader.GetString(5);
            return newParent;
        }

        //This method is used to add Parents to the database. These variables are being passed in from the Add A Parent form
        public void InsertParent(string ParentName, string ParentPhone, string ParentEmail, string ParentAddress, string ParentOccupation)
        {
            try
            {
                db.Cmd = db.Conn.CreateCommand();
                db.Cmd.CommandText = "INSERT INTO Parent (ParentName, ParentPhone, ParentEmail, ParentAddress, ParentOccupation) " +
                " VALUES (" + "  '" + ParentName + "' , '" + ParentPhone + "' , '" + ParentEmail + "' , '" + ParentAddress + "' , '" + ParentOccupation + "')";
                db.Cmd.ExecuteNonQuery();
            }
            //If there's a problem, display the error form
            catch (SqlException ex)
            {
                new ErrorBox(ex).Show();
            }
        }

        //Show all the Parents in the database
        public List<objects.Parent> SelectAllParents()
        {
            //Creates a list of objects of type Parent
            List<Parent> results = new List<Parent>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Parent";
             db.Rdr = db.Cmd.ExecuteReader();

            while (db.Rdr.Read())
            {
                results.Add(getParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the Parents which match the entered Parents Name
        public List<Parent> SelectAllParentsWhereName(string ParentName)
        {
            //Creates a list of objects of type Parent
            List<Parent> results = new List<Parent>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Parent WHERE ParentName = '" + ParentName + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        //Show all the Parents which match the entered Parents Town
        public List<Parent> SelectAllParentsWhereTown(string TownName)
        {
            //Creates a list of objects of type Parent
            List<Parent> results = new List<Parent>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Parent WHERE ParentAddress = '" + TownName + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                results.Add(getParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }


        public void updateProject(int parentId, string parentName, string parentPhone, string parentEmail, string parentAddress, string parentOccupation)
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "UPDATE Parent SET ParentName = '"
                + parentName + "' , ParentPhone = '"
                + parentPhone + "' , ParentEmail = '"
                + parentEmail + "', ParentAddress = '"
                + parentAddress + "', ParentOccupation = '"
                + parentOccupation + "' " + "WHERE ParentId = "
                + parentId;
            db.Cmd.ExecuteNonQuery();
        }

        //Show all the Parents which match the entered Parents ID
        public List<Parent> getParentWithID(int id)
        {
            //Creates a list of objects of type Parent
            List<Parent> result = new List<Parent>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Parent WHERE ParentId = " + id;
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //Show all the Parents which match the entered Parents Phone
        public List<Parent> getParentWithPhone(string phone)
        {
            //Creates a list of objects of type Parent
            List<Parent> result = new List<Parent>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Parent WHERE ParentPhone = '" + phone + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //Show all the Parents which match the entered Parents Address
        public List<Parent> getParentByAddress(string address)
        {
            //Creates a list of objects of type Parent
            List<Parent> result = new List<Parent>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Parent WHERE ParentAddress = '" + address + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //Show all the Parents which match the entered Parents Occupation
        public List<Parent> getParentByOccupation(string occupation)
        {
            //Creates a list of objects of type Parent
            List<Parent> result = new List<Parent>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Parent WHERE ParentEmail = '" + occupation + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }

        //Show all the Parents which match the entered Parents Email
        public List<Parent> getAllParentByEmail(string email)
        {
            //Creates a list of objects of type Parent
            List<Parent> result = new List<Parent>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM Parent WHERE ParentEmail = '" + email + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            //Populates the list of objects with entries from the database where the searched for criteria is met
            while (db.Rdr.Read())
            {
                result.Add(getParentFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return result;
        }
    }
}


