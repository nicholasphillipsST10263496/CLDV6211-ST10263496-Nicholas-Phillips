using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebApplication6.Models
{
    public class UserTable
    {

        //public static string con_string = "Server=tcp:clouddev-sql-server.database.windows.net,1433;Initial Catalog=CLDVDatabase;Persist Security Info=False;User ID=Byron;Password=RockeyM12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static string con_string = "Server=tcp:cldv-sqlserver.database.windows.net,1433;Initial Catalog=ST10263496-DB;Persist Security Info=False;User ID=Nicholas;Password=Lotuskiller341;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);



        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }





        public int insert_User(UserTable m)
        {

            try
            {
                string sql = "INSERT INTO userTable (userName, userPassword, userEmail) VALUES (@Name, @Password, @Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", m.Name);
                cmd.Parameters.AddWithValue("@Email", m.Email);
                cmd.Parameters.AddWithValue("@Password", m.Password);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }


    }
}
