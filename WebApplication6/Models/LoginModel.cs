using System;
using System.Data.SqlClient;

namespace WebApplication6.Models
{
    public class LoginModel
    {
        // Corrected connection string format
        public static string con_string = "Server=tcp:cldv-sqlserver.database.windows.net,1433;Initial Catalog=CLDV_DB;Persist Security Info=False;User ID=Nicholas;Password=your_password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int SelectUser(string email, string name)
        {


            int userId = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteNonQuery();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                     // Handle exception appropriately
                }
            }
            return userId;
        }
    }
}
