using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication6.Models;

namespace CloudDevelopment.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Name)
        {
            // Authenticate user
            int userId = login.SelectUser(Email, Name);
            if (userId != -1)
            {
                // Store userID in session
                HttpContext.Session.SetInt32("UserID", userId);
                // User authenticated, redirect to home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // User not found, add error message to TempData and redirect back to login page
                TempData["ErrorMessage"] = "Invalid email or name. Please try again.";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
