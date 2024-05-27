using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class ProductController : Controller
    {
        public ProductTable prodtbl = new ProductTable();

        [HttpPost]
        public ActionResult MyWork(ProductTable products)
        {
            var result2 = prodtbl.InsertProduct(products); // Corrected method name
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}
