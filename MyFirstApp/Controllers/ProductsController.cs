using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class ProductsController : Controller
    {

        [Route("/products")]
        public IActionResult Index()
        {
            return View();
            // the view will be resolved in two different locations: 1 - Views/Products/Index.cshtml  |||  2 - Views/Shared/Index.cshtml
        }



        [Route("/search-products/{ProductID?}")]
        public IActionResult Search(int? ProductID)
        {

            ViewBag.ProductID = ProductID;

            return View();
        }

        [Route("/order-product")]
        public IActionResult Order()
        {
            return View();
        }
    }
}
