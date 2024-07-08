﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public static class clsBondHeadersData
{
    public static async Task<DataTable> GetAllBondHeadersAsync()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetAllBondHeaders", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                   if(reader.HasRows)   dt.Load(reader); // Load data into DataTable
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.SetErrorLoggingEvent(ex.Message);
                }
            }
        }

        return dt;
    }

    public static async Task<int> AddNewBondHeaderAsync(
        int bondID,
        DateTime? bondDate,
        string bondNote,
        int bondType,
        bool? isPost,
        decimal? bondBalance,
        int? cashID,
        int? accountBankID,
        int? addedByUserID,
        DateTime? addDate,
        int? editedByUserID,
        DateTime? editDate)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_AddBondHeader", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BondID", bondID);
                command.Parameters.AddWithValue("@BondDate", (object)bondDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@BondNote", (object)bondNote ?? DBNull.Value);
                command.Parameters.AddWithValue("@BondType", (object)bondType ?? DBNull.Value);
                command.Parameters.AddWithValue("@IsPost", (object)isPost ?? DBNull.Value);
                command.Parameters.AddWithValue("@BondBalance", (object)bondBalance ?? DBNull.Value);
                command.Parameters.AddWithValue("@CashID", (object)cashID ?? DBNull.Value);
                command.Parameters.AddWithValue("@AccountBankID", (object)accountBankID ?? DBNull.Value);
                command.Parameters.AddWithValue("@AddedByUserID", (object)addedByUserID ?? DBNull.Value);
                command.Parameters.AddWithValue("@AddDate", (object)addDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@EditedByUserID", (object)editedByUserID ?? DBNull.Value);
                command.Parameters.AddWithValue("@EditDate", (object)editDate ?? DBNull.Value);

                try
                {
                    await connection.OpenAsync();
                    rowsAffected = await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.SetErrorLoggingEvent(ex.Message);
                }
            }
        }

        return rowsAffected;
    }

    public static async Task<bool> UpdateBondHeaderAsync(
        int bondID,
        DateTime? bondDate,
        string bondNote,
        int bondType,
        bool? isPost,
        decimal? bondBalance,
        int? cashID,
        int? accountBankID,
        int? addedByUserID,
        DateTime? addDate,
        int? editedByUserID,
        DateTime? editDate)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_UpdateBondHeader", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BondID", bondID);
                command.Parameters.AddWithValue("@BondDate", (object)bondDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@BondNote", (object)bondNote ?? DBNull.Value);
                command.Parameters.AddWithValue("@BondType", (object)bondType ?? DBNull.Value);
                command.Parameters.AddWithValue("@IsPost", (object)isPost ?? DBNull.Value);
                command.Parameters.AddWithValue("@BondBalance", (object)bondBalance ?? DBNull.Value);
                command.Parameters.AddWithValue("@CashID", (object)cashID ?? DBNull.Value);
                command.Parameters.AddWithValue("@AccountBankID", (object)accountBankID ?? DBNull.Value);
                command.Parameters.AddWithValue("@AddedByUserID", (object)addedByUserID ?? DBNull.Value);
                command.Parameters.AddWithValue("@AddDate", (object)addDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@EditedByUserID", (object)editedByUserID ?? DBNull.Value);
                command.Parameters.AddWithValue("@EditDate", (object)editDate ?? DBNull.Value);

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

    public static async Task<bool> DeleteBondHeaderAsync(int bondID)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_DeleteBondHeader", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BondID", bondID);

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

    public static bool FindBondHeaderByID(
        int bondID,
        out DateTime? bondDate,
        out string bondNote,
        out int bondType,
        out bool? isPost,
        out decimal? bondBalance,
        out int? cashID,
        out int? accountBankID,
        out int? addedByUserID,
        out DateTime? addDate,
        out int? editedByUserID,
        out DateTime? editDate)
    {
        bondDate = null;
        bondNote = null;
        bondType = 0;
        isPost = null;
        bondBalance = null;
        cashID = null;
        accountBankID = null;
        addedByUserID = null;
        addDate = null;
        editedByUserID = null;
        editDate = null;

        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetBondHeaderByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BondID", bondID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        bondDate = reader["BondDate"] != DBNull.Value ? (DateTime?)reader["BondDate"] : null;
                        bondNote = reader["BondNote"] != DBNull.Value ? Convert.ToString(reader["BondNote"]) : null;
                        bondType = reader["BondType"] != DBNull.Value ? Convert.ToInt32(reader["BondType"]) : 0;
                        isPost = reader["IsPost"] != DBNull.Value ? (bool?)reader["IsPost"] : null;
                        bondBalance = reader["BondBalance"] != DBNull.Value ? (decimal?)reader["BondBalance"] : null;
                        cashID = reader["CashID"] != DBNull.Value ? (int?)reader["CashID"] : null;
                        accountBankID = reader["AccountBankID"] != DBNull.Value ? (int?)reader["AccountBankID"] : null;
                        addedByUserID = reader["AddedByUserID"] != DBNull.Value ? (int?)reader["AddedByUserID"] : null;
                        addDate = reader["AddDate"] != DBNull.Value ? (DateTime?)reader["AddDate"] : null;
                        editedByUserID = reader["EditedByUserID"] != DBNull.Value ? (int?)reader["EditedByUserID"] : null;
                        editDate = reader["EditDate"] != DBNull.Value ? (DateTime?)reader["EditDate"] : null;
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
