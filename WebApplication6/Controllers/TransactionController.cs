using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class TransactionController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(UserTable.con_string))
                {
                    string sql = "INSERT INTO transactionTable (userId, productId) VALUES (@UserID, @ProductID)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            //return Json(new { success = true, message = "Order placed successfully!" });
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            //return Json(new { success = false, message = "Failed to place order." });
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while placing the order." });
            }
        }
    }
}
