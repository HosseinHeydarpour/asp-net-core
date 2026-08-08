using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books")]
        public IActionResult Books()
        {
            return Content("<h1>Book Store</h1>", "text/html");
        }
    }
}
