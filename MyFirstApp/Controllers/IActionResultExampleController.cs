using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyFirstApp.Controllers
{
    public class IActionResultExampleController : Controller
    {

        [Route("bookstore")]
        // public ContentResult Index() - this definition of  the method gives us an error when returning the file content 
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                //=================
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied!");
                //=================

                //return new BadRequestResult();
                return BadRequest("Book id is not supplied!");
            }

            // Book id cannot be empty!
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;

                //return Content("Book id cannot be null or empty!");


                return BadRequest("Book id cannot be null or empty!");
            }

            // Book id cannot be over 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId > 1000 )
            {
                //Response.StatusCode = 400;

                //return Content("Book id cannot be over 1000 or below 0! It must be 1 and 1000");

                return NotFound($"Book with id: {bookId} not found :( ");

            } 
            if(bookId <= 0)
            {
                return BadRequest("Book id cannot be negative or 0! It must be 1 and 1000");
            }


            // isloggedin should be true
            bool isUserLoggedIn = Convert.ToBoolean(Request.Query["isloggedin"]);
            if (!isUserLoggedIn) 
            {
                //Response.StatusCode = 401;

                //return Content("User must be authenticatd...");


                // return Unauthorized("User must be authenticatd...");

                return StatusCode(401, "User must be authenticatd...");
            }




            //return File($"/docs.pdf", "application/pdf");

            // Pay attention when we pass StoreController we omit the Controller part
            //
            // RedirectToActionResult(actionName, ControllerName, route values, permanant => by default it is false)
            //return new RedirectToActionResult("Books", "Store", new { }); // 302 - Found
            // 302 means temp redirection - 302 means permanant redirection
            return new RedirectToActionResult("Books", "Store", new { }, permanent:true); // 301 - Found --> when permamant set to true - Moved permanently
        }
    }
}
