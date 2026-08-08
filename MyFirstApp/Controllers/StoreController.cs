using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MyFirstApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{bookId}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["bookId"]);

            return Content($"<h1>Book Store</h1> <p>Book Id: {id}</p>", "text/html");
        }
    }
}
