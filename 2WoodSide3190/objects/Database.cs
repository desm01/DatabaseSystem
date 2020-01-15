using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _2WoodSide3190.objects
{
    public class Database
    {
    //Declareing the private attrcibutes
        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataReader rdr;
        private string _connectionString;


        //Default constructor, the connection string from the connection form is passed in
        public Database(string connectionString)
        {
            ConnectionString = connectionString;
        }


        //Initalising the database properties

        public SqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        public SqlDataReader Rdr
        {
            get { return rdr; }
            set { rdr = value; }
        }
        //This method connect the program to the database, a boolean is used to check whether the program connects or not
        public bool connect()
        {
        //Sets the connection
            SqlConnectionStringBuilder scStrBuild = new SqlConnectionStringBuilder();
            scStrBuild.DataSource = ConnectionString;
            scStrBuild.InitialCatalog = "Woodside3190";
            scStrBuild.IntegratedSecurity = true;
            conn = new SqlConnection(scStrBuild.ToString());

            //Trys to open the database connection
            try
            {
                conn.Open();
            }

            //If there's an error, write the error to the console
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            //If the database succesfully connects, return the boolean true
            if (conn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }

            //If it doenst connect, return false
            else
            {
                return false;
            }

        }
        //Encapsulation of private variables.
        public string ConnectionString 
        { 
        get { return _connectionString; }
        set { _connectionString = value; }
        }
    }
}
