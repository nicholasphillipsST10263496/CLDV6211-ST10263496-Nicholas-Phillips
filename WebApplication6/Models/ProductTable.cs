using System;
using System.Data.SqlClient;

namespace WebApplication6.Models
{
    public class ProductTable
    {
        // Connection string to your database
        public static string con_string = "Server=tcp:cldv-sqlserver.database.windows.net,1433;Initial Catalog=ST10263496-DB;Persist Security Info=False;User ID=Nicholas;Password=Lotuskiller341;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // SqlConnection instance
        public static SqlConnection con = new SqlConnection(con_string);

        // Properties of the ProductTable
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }

        // Method to insert a product into the database
        public int InsertProduct(ProductTable product)
        {
            try
            {
                string sql = "INSERT INTO ProductTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@Availability", product.Availability);
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
        // Method to retrieve all products from the database
        public static List<ProductTable> GetAllProducts()
        {
            List<ProductTable> products = new List<ProductTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProductTable product = new ProductTable();
                    product.ProductID = Convert.ToInt32(rdr["productID"]);
                    product.Name = rdr["productName"].ToString();
                    product.Price = rdr["productPrice"].ToString();
                    product.Category = rdr["productCategory"].ToString();
                    product.Availability = rdr["productAvailability"].ToString();

                    products.Add(product);
                }
            }

            return products;
        }

    }
}

