using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ORACLELab.Models
{
    public class OracleDB
    {
        //OracleConnection
        private static OracleConnection aConn = null;

        public static OracleConnection Instance()
        {
            OracleConnection myConnection;

            if (OracleDB.aConn != null)
            {
                myConnection = OracleDB.aConn;
            }
            else
            {
                myConnection = new OracleConnection();
            }

            return myConnection;
        }

        private List<client> aListOfClients = new List<client>();

        public List<client> GetClientList()
        {
            string SQL = "SELECT * FROM TBL_CLIENTS";
            aConn = OracleDB.Instance();
            aConn.ConnectionString = @"DATA SOURCE=localhost:1521/orcl;USER ID=SYSTEM;Password=Password1";
            aConn.Open();
            OracleCommand aCommand = aConn.CreateCommand();
            aCommand.CommandText = SQL;

            OracleDataReader aReader = aCommand.ExecuteReader();
            while (aReader.Read())
            {
                int aClientID = Convert.ToInt32((long)(aReader)["CLIENTID"]);
                string aLName = (string)(aReader)["LNAME"];
                string aFName = (string)(aReader)["FNAME"];
                string aStreetAddress = (string)(aReader)["STEETADDRESS"];
                string aZip = (string)(aReader)["ZIP"];
                string aDateOfBirth = (string)(aReader)["DATEOFBIRTH"];
                string aBorough = (string)(aReader)["BOROUGH"];

                client aClient = new client();
                aClient.ClientID = aClientID;
                aClient.LName = aLName;
                aClient.FName = aFName;
                aClient.StreetAddress = aStreetAddress;
                aClient.Zip = aZip;
                aClient.DateOfBirth = aDateOfBirth;
                aClient.Borough = aBorough;

                aListOfClients.Add(aClient);
            }
            aConn.Close();
            return aListOfClients;
        }

        public List<client> GetClientById(int clientID)
        {
            string SQL = "SELECT * FROM TBL_CLIENTS WHERE CLIENTID = :clientID";
            aConn = OracleDB.Instance();
            aConn.ConnectionString = @"DATA SOURCE=localhost:1521/orcl;USER ID=SYSTEM;Password=Password1";

            using (OracleCommand aCommand = new OracleCommand(SQL, aConn))
            {
                aCommand.CommandType = System.Data.CommandType.Text;
                aCommand.Parameters.Add(new OracleParameter("CLIENTID", clientID));

                aConn.Open();

               using (OracleDataReader aReader = aCommand.ExecuteReader()) {
                    while (aReader.Read())
                    {
                        int aClientID = Convert.ToInt32((long)(aReader)["CLIENTID"]);
                        string aLName = (string)(aReader)["LNAME"];
                        string aFName = (string)(aReader)["FNAME"];
                        string aStreetAddress = (string)(aReader)["STEETADDRESS"];
                        string aZip = (string)(aReader)["ZIP"];
                        string aDateOfBirth = (string)(aReader)["DATEOFBIRTH"];
                        string aBorough = (string)(aReader)["BOROUGH"];

                        client aClient = new client();
                        aClient.ClientID = aClientID;
                        aClient.LName = aLName;
                        aClient.FName = aFName;
                        aClient.StreetAddress = aStreetAddress;
                        aClient.Zip = aZip;
                        aClient.DateOfBirth = aDateOfBirth;
                        aClient.Borough = aBorough;

                        aListOfClients.Add(aClient);
                    }
                }
                aConn.Close();
            }        
            return aListOfClients;
        }


        public bool addClient(string LName, string FName, string StreetAddress, string Zip, string DateOfBirth, string Borough)
        {
            bool aFlag = false;
            string SQL = "INSERT INTO TBL_CLIENTS(CLIENTID, LNAME, FNAME, STEETADDRESS, ZIP, DATEOFBIRTH, BOROUGH) VALUES ( seq_person.nextval  , :LName, :FName,:StreetAddress, :Zip, :DateOfBirth, :Borough) ";
            aConn = OracleDB.Instance();
            aConn.ConnectionString = @"DATA SOURCE=localhost:1521/orcl;USER ID=SYSTEM;Password= Password1";

            using (OracleCommand aCommand = new OracleCommand(SQL, aConn))
            {
                aCommand.CommandType = System.Data.CommandType.Text;
                aCommand.Parameters.Add(new OracleParameter("LNAME", LName));
                aCommand.Parameters.Add(new OracleParameter("FNAME", FName));
                aCommand.Parameters.Add(new OracleParameter("STEETADDRESS", StreetAddress));
                aCommand.Parameters.Add(new OracleParameter("ZIP", Zip));
                aCommand.Parameters.Add(new OracleParameter("DATEOFBIRTH", DateOfBirth));
                aCommand.Parameters.Add(new OracleParameter("BOROUGH", Borough));
                aConn.Open();
                aCommand.ExecuteNonQuery();

            } 
                aFlag = true;
                aConn.Close();
                return aFlag;
        }

       public bool updateCLient(int clientID, string LName, string FName, string StreetAddress, string Zip, string DateOfBirth, string Borough)
       {
            bool aFlag = false;
            string SQL = "UPDATE TBL_CLIENTS SET LNAME = :LName, FNAME = :FName, STEETADDRESS = :StreetAddress, ZIP = :Zip, DATEOFBIRTH = :DateOfBirth, BOROUGH = :Borough Where CLIENTID = :clientID";
            
            aConn = OracleDB.Instance();
            aConn.ConnectionString = @"DATA SOURCE=localhost:1521/orcl;USER ID=SYSTEM;Password= Password1";

            using (OracleCommand aCommand = new OracleCommand(SQL, aConn))
            {
                aCommand.CommandType = System.Data.CommandType.Text;
                aCommand.Parameters.Add(new OracleParameter("LNAME", LName));
                aCommand.Parameters.Add(new OracleParameter("FNAME", FName));
                aCommand.Parameters.Add(new OracleParameter("STEETADDRESS", StreetAddress));
                aCommand.Parameters.Add(new OracleParameter("ZIP", Zip));
                aCommand.Parameters.Add(new OracleParameter("DATEOFBIRTH", DateOfBirth));
                aCommand.Parameters.Add(new OracleParameter("BOROUGH", Borough));
                aCommand.Parameters.Add(new OracleParameter("CLIENTID", clientID));
                aConn.Open();
                aCommand.ExecuteNonQuery();
            }
            aFlag = true;
            aConn.Close();
            return aFlag;
        }

        public bool deleteClient(int clientID)
        {
            bool aFlag = false;
            string SQL = "DELETE FROM TBL_CLIENTS Where CLIENTID = :clientID";
            aConn = OracleDB.Instance();
            aConn.ConnectionString = @"DATA SOURCE=localhost:1521/orcl;USER ID=SYSTEM;Password= Password1";

            using (OracleCommand aCommand = new OracleCommand(SQL, aConn))
            {
                aCommand.CommandType = System.Data.CommandType.Text;
                aCommand.Parameters.Add(new OracleParameter("CLIENTID", clientID));

                aConn.Open();
                aCommand.ExecuteNonQuery();
            }

            aFlag = true;
            aConn.Close();
            return aFlag;
        }
    }
}