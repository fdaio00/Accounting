using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public static class clsAccountData
{
    public static async Task<DataTable> GetAllAccountsAsync()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetAllAccounts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
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

    public static async Task<int> AddNewAccountAsync(
        int AccountParentNo,
        string AccountNameAr,
        string AccountNameEn,
        int AccountTypeID,
        int AccountReportID,
        int AccountLevel,
        decimal AccountDebit,
        decimal AccountCredit,
        decimal AccountBalance)
    {
        int accountID = -1;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_AddAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountParentNo", AccountParentNo);
                command.Parameters.AddWithValue("@AccountNameAr", AccountNameAr);
                command.Parameters.AddWithValue("@AccountNameEn", (object)AccountNameEn ?? DBNull.Value);
                command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
                command.Parameters.AddWithValue("@AccountReportID", AccountReportID);
                command.Parameters.AddWithValue("@AccountLevel", AccountLevel);
                command.Parameters.AddWithValue("@AccountDebit", AccountDebit);
                command.Parameters.AddWithValue("@AccountCredit", AccountCredit);
                command.Parameters.AddWithValue("@AccountBalance", AccountBalance);

                try
                {
                    await connection.OpenAsync();
                    accountID = Convert.ToInt32(await command.ExecuteScalarAsync());
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

        return accountID;
    }

    public static async Task<bool> UpdateAccountAsync(
        int AccountNo,
        int AccountParentNo,
        string AccountNameAr,
        string AccountNameEn,
        int AccountTypeID,
        int AccountReportID,
        int AccountLevel,
        decimal AccountDebit,
        decimal AccountCredit,
        decimal AccountBalance)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_UpdateAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountNo", AccountNo);
                command.Parameters.AddWithValue("@AccountParentNo", AccountParentNo);
                command.Parameters.AddWithValue("@AccountNameAr", AccountNameAr);
                command.Parameters.AddWithValue("@AccountNameEn", (object)AccountNameEn ?? DBNull.Value);
                command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
                command.Parameters.AddWithValue("@AccountReportID", AccountReportID);
                command.Parameters.AddWithValue("@AccountLevel", AccountLevel);
                command.Parameters.AddWithValue("@AccountDebit", AccountDebit);
                command.Parameters.AddWithValue("@AccountCredit", AccountCredit);
                command.Parameters.AddWithValue("@AccountBalance", AccountBalance);

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

    public static async Task<bool> DeleteAccountAsync(int accountID)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_DeleteAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountNo", accountID);

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

    public static bool FindAccountByID(
        int accountID,
        ref int accountParentNoRef,
        ref string accountNameArRef,
        ref string accountNameEnRef,
        ref int AccountTypeIDRef,
        ref int accountReportRef,
        ref int accountLevelRef,
        ref decimal accountDebitRef,
        ref decimal accountCreditRef,
        ref decimal accountBalanceRef)
    {
        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetAccountByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountNo", accountID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        accountParentNoRef = reader["AccountParentNo"] != DBNull.Value ? Convert.ToInt32(reader["AccountParentNo"]) : 0;
                        accountNameArRef = reader["AccountNameAr"] != DBNull.Value ? Convert.ToString(reader["AccountNameAr"]) : "";
                        accountNameEnRef = reader["AccountNameEn"] != DBNull.Value ? Convert.ToString(reader["AccountNameEn"]) : null;
                        AccountTypeIDRef = reader["AccountTypeID"] != DBNull.Value ? Convert.ToInt32(reader["AccountTypeID"]) : 0;
                        accountReportRef = reader["AccountReportID"] != DBNull.Value ? Convert.ToInt32(reader["AccountReportID"]) : 0;
                        accountLevelRef = reader["AccountLevel"] != DBNull.Value ? Convert.ToInt32(reader["AccountLevel"]) : 0;
                        accountDebitRef = reader["AccountDebit"] != DBNull.Value ? Convert.ToDecimal(reader["AccountDebit"]) : 0;
                        accountCreditRef = reader["AccountCredit"] != DBNull.Value ? Convert.ToDecimal(reader["AccountCredit"]) : 0;
                        accountBalanceRef = reader["AccountBalance"] != DBNull.Value ? Convert.ToDecimal(reader["AccountBalance"]) : 0;
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
