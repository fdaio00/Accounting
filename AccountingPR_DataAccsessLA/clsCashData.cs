using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public static class clsCashData
{
    public static async Task<DataTable> GetAllCashesAsync()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetAllCashes", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                   if(reader.HasRows) 
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

    public static async Task<int> AddNewCashAsync(string CashNameAr, string CashNameEn)
    {
        int cashID = -1;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_AddCash", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CashNameAr", CashNameAr);
                command.Parameters.AddWithValue("@CashNameEn", (object)CashNameEn ?? DBNull.Value);

                try
                {
                    await connection.OpenAsync();
                    cashID = Convert.ToInt32(await command.ExecuteScalarAsync());
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

        return cashID;
    }

    public static async Task<bool> UpdateCashAsync(int CashID, string CashNameAr, string CashNameEn)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_UpdateCash", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CashID", CashID);
                command.Parameters.AddWithValue("@CashNameAr", CashNameAr);
                command.Parameters.AddWithValue("@CashNameEn", (object)CashNameEn ?? DBNull.Value);

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

    public static async Task<bool> DeleteCashAsync(int cashID)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_DeleteCash", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CashID", cashID);

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

    public static bool FindCashByID(int cashID, ref string cashNameArRef, ref string cashNameEnRef)
    {
        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetCashByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CashID", cashID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        cashNameArRef = reader["CashNameAr"] != DBNull.Value ? Convert.ToString(reader["CashNameAr"]) : null;
                        cashNameEnRef = reader["CashNameEn"] != DBNull.Value ? Convert.ToString(reader["CashNameEn"]) : null;
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
