using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public static class clsUserData
{
    public static async Task<DataTable> GetAllUsersAsync()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetAllUsers", connection))
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

    public static async Task<int> AddNewUserAsync(string FullName, string UserName, string Password, string Phone, string Email, byte[] Image)
    {
        int userID = -1;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_AddUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FullName", FullName);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Phone", (object)Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Image", (object)Image ?? DBNull.Value);

                try
                {
                    await connection.OpenAsync();
                    userID = Convert.ToInt32(await command.ExecuteScalarAsync());
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

        return userID;
    }

    public static async Task<bool> UpdateUserAsync(int UserID, string FullName, string UserName, string Password, string Phone, string Email, byte[] Image)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@FullName", FullName);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Phone", (object)Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Image", (object)Image ?? DBNull.Value);

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

    public static async Task<bool> DeleteUserAsync(int UserID)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);

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

    public static bool FindUserByID(int UserID, ref string FullNameRef, ref string UserNameRef, ref string PasswordRef, ref string PhoneRef, ref string EmailRef, ref byte[] ImageRef)
    {
        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetUserByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        // Set ref parameters with null check
                        FullNameRef = reader["FullName"] != DBNull.Value ? Convert.ToString(reader["FullName"]) : null;
                        UserNameRef = reader["UserName"] != DBNull.Value ? Convert.ToString(reader["UserName"]) : null;
                        PasswordRef = reader["Password"] != DBNull.Value ? Convert.ToString(reader["Password"]) : null;
                        PhoneRef = reader["Phone"] != DBNull.Value ? Convert.ToString(reader["Phone"]) : null;
                        EmailRef = reader["Email"] != DBNull.Value ? Convert.ToString(reader["Email"]) : null;
                        if (reader["Image"] != DBNull.Value)
                        {
                            ImageRef = (byte[])reader["Image"];
                        }
                        else
                        {
                            ImageRef = null;
                        }
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

    public static bool FindByUserNameAndPassword(ref int UserID, ref string FullName,  string UserName,  string Password, ref string PhoneRef, ref string EmailRef, ref byte[] ImageRef)
    {
        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_GetUserByUserNameAndPassword", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        // Set ref parameters with null check
                        UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : -1;
                        FullName = reader["FullName"] != DBNull.Value ? Convert.ToString(reader["FullName"]) : null;
                        PhoneRef = reader["Phone"] != DBNull.Value ? Convert.ToString(reader["Phone"]) : null;
                        EmailRef = reader["Email"] != DBNull.Value ? Convert.ToString(reader["Email"]) : null;
                        if (reader["Image"] != DBNull.Value)
                        {
                            ImageRef = (byte[])reader["Image"];
                        }
                        else
                        {
                            ImageRef = null;
                        }
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


