using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class ProductsController : Controller
    {

        [Route("products/all")]
        public IActionResult All()
        {
            return View();
            // the view will be resolved in two different locations: 1 - Views/Products/All.cshtml  |||  2 - Views/Shared/All.cshtml
        }
    }
}
