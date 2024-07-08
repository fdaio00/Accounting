﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public static class clsAccountTypeData
{
    public static async Task<DataTable> GetAllAccountTypeIDsAsync()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetAllAccountTypeIDs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    dt.Load(reader); // Load data into DataTable
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.SetErrorLoggingEvent(ex.Message);
                }
            }
        }

        return dt;
    }

    public static async Task<int> AddNewAccountTypeIDAsync(string AccountTypeIDNameAr, string AccountTypeIDNameEn)
    {
        int AccountTypeIDID = -1;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_AddAccountTypeID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountTypeIDNameAr", AccountTypeIDNameAr);
                command.Parameters.AddWithValue("@AccountTypeIDNameEn", (object)AccountTypeIDNameEn ?? DBNull.Value);

                try
                {
                    await connection.OpenAsync();
                    AccountTypeIDID = Convert.ToInt32(await command.ExecuteScalarAsync());
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.SetErrorLoggingEvent(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        return AccountTypeIDID;
    }

    public static async Task<bool> UpdateAccountTypeIDAsync(int AccountTypeIDID, string AccountTypeIDNameAr, string AccountTypeIDNameEn)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_UpdateAccountTypeID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountTypeIDID", AccountTypeIDID);
                command.Parameters.AddWithValue("@AccountTypeIDNameAr", AccountTypeIDNameAr);
                command.Parameters.AddWithValue("@AccountTypeIDNameEn", (object)AccountTypeIDNameEn ?? DBNull.Value);

                try
                {
                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.SetErrorLoggingEvent(ex.Message);
                }
            }
        }

        return success;
    }

    public static async Task<bool> DeleteAccountTypeIDAsync(int AccountTypeIDID)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_DeleteAccountTypeID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountTypeIDID", AccountTypeIDID);

                try
                {
                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.SetErrorLoggingEvent(ex.Message);
                }
            }
        }

        return success;
    }

    public static bool FindAccountTypeIDByID(int AccountTypeIDID, ref string AccountTypeIDNameArRef, ref string AccountTypeIDNameEnRef)
    {
        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetAccountTypeIDByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountTypeIDID", AccountTypeIDID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        // Set ref parameters with null check
                        AccountTypeIDNameArRef = reader["AccountTypeIDNameAr"] != DBNull.Value ? Convert.ToString(reader["AccountTypeIDNameAr"]) : null;
                        AccountTypeIDNameEnRef = reader["AccountTypeIDNameEn"] != DBNull.Value ? Convert.ToString(reader["AccountTypeIDNameEn"]) : null;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.SetErrorLoggingEvent(ex.Message);
                }
            }
        }

        return isFound;
    }
}
