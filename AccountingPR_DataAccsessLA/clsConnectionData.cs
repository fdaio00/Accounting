﻿using AccountingPR_DataAccsessLA;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Diagnostics;

public class clsConnectionData
{
    // Singleton instance
    private static clsConnectionData _instance;
    private static readonly object _lock = new object();

    private static string _Mode;
    private static string _Password;
    private static string _Server;
    private static string _DB;
    private static string _UserID;

    public string ConnectionString { get; private set; }

    // Private constructor to prevent direct instantiation
    private clsConnectionData()
    {
        SetConnectionString();
    }

    public static clsConnectionData GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new clsConnectionData();
                }
            }
        }
        return _instance;
    }
    static public void SetErrorLoggingEvent(string exMessage, string sourceName = "Accounting")
    {

        if (!EventLog.SourceExists(sourceName))
        {
            EventLog.CreateEventSource(sourceName, "Application");

        }
    EventLog.WriteEntry(sourceName, exMessage, EventLogEntryType.Error);
    }

        private void SetConnectionString()
    {
        string Mode = _Mode;
        switch (Mode)
        {
            case "WIN":
                ConnectionString = $"server = {_Server}; database = {_DB};Trusted_Connection=True;TrustServerCertificate=true;";
                break;

            case "USER":
                ConnectionString = $"server = {_Server}; database = {_DB};Trusted_Connection=True;TrustServerCertificate=true;user id = {_UserID};password = {_Password}";
                break;

            default:
                ConnectionString = $"server = {_Server}; database = {_DB};Trusted_Connection=True;TrustServerCertificate=true;";
                break;
        }
    }

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
                   SetErrorLoggingEvent(ex.Message);
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

        // Ensure the singleton instance updates its connection string
        if (_instance != null)
        {
            _instance.SetConnectionString();
        }
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
                    SetErrorLoggingEvent(ex.Message);
                    // You might handle exceptions differently based on your application's needs
                }
            }
        }

        return dt;
    }
}
