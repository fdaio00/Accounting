using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AccountingPR_DataAccsessLA
{

    public class clsConnectionData
    {
        private static string _Mode;
        private static string _Password;
        private static string _Server;
        private static string _DB;
        private static string _UserID;
     
        public string ConnectionString;
        public clsConnectionData()
        {
            string Mode = _Mode;
            switch (Mode)
            {
                case "WIN":
                    ConnectionString = $"server = {_Server}; database = {_DB};integrated security = true;";
                    break;

                case "USER":
                    ConnectionString = $"server = {_Server}; database = {_DB};integrated security = true;user id = {_UserID} , password = {_Password}";
                    break;

                default:
                    ConnectionString = $"server = {_Server}; database = {_DB};integrated security = true;";
                    break;
            }

            //_conn = new SqlConnection(ConnectionString);


        }

        //public clsConnection GetInstance()
        //{
        //    if(_conn == null)
        //        return new clsConnection();


        //}

        //public void Open()
        //{
        //    if (_conn.State != System.Data.ConnectionState.Open)
        //    {
        //        _conn.Open();
        //    }
        //}

        //public void Close()
        //{
        //    if (_conn.State != System.Data.ConnectionState.Closed)
        //    {
        //        _conn.Close();
        //    }
        //}

        public bool ExecuteCommand(string storedProcedureName, SqlParameter[] parameters)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        CRUD_DB.SetErrorLoggingEvent(ex.Message);
                        success = false;
                    }
                }
            }

            return success;
        }


        public static void SetServerSettings(string Mode, string ServerName, string databaseName, string UserId = "", string Password = "")
        {
            _Mode = Mode;
            _Server = ServerName;
            _DB = databaseName;
            _UserID = UserId;
            _Password = Password;
        }
        public DataTable GetData(string storedProcedureName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CRUD_DB.SetErrorLoggingEvent(ex.Message);
                        // You might handle exceptions differently based on your application's needs
                    }
                }
            }

            return dt;
        }
    }


}
