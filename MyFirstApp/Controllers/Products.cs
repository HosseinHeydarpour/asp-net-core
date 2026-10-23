using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class Products : Controller
    {

        [Route("products/all")]
        public IActionResult All()
        {
            return View();
        }
    }
}
