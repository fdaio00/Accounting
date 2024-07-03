using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AccountingPR_DataAccsessLA
{
     public static class CRUD_DB
    {

        static public void SetErrorLoggingEvent(string exMessage, string sourceName = "Accounting")
        {

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");

            }


            EventLog.WriteEntry(sourceName, exMessage, EventLogEntryType.Error);

        }
        //public static bool ExecuteCommand(string storedProcedureName, SqlParameter[] parameters)
        //{
        //    bool success = false;

        //    using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionStringWinAth))
        //    {
        //        using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            if (parameters != null)
        //            {
        //                command.Parameters.AddRange(parameters);
        //            }

        //            try
        //            {
        //                connection.Open();
        //                command.ExecuteNonQuery();
        //                success = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Error executing command: " + ex.Message);
        //                success = false;
        //            }
        //        }
        //    }

        //    return success;
        //}

        //public static DataTable GetData(string storedProcedureName, SqlParameter[] parameters)
        //{
        //    DataTable dt = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionStringWinAth))
        //    {
        //        using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            if (parameters != null)
        //            {
        //                command.Parameters.AddRange(parameters);
        //            }

        //            try
        //            {
        //                connection.Open();
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        dt.Load(reader);
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Error retrieving data: " + ex.Message);
        //                // You might handle exceptions differently based on your application's needs
        //            }
        //        }
        //    }

        //    return dt;
        //}
    }
}
