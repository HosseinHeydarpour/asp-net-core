using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class IActionResultExampleController : Controller
    {

        [Route("book")]
        // public ContentResult Index() - this definition of  the method gives us an error when returning the file content 
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;

                return Content("Book id is not supplied!");
            }

            // Book id cannot be empty!
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;

                return Content("Book id cannot be null or empty!");
            }

            // Book id cannot be over 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId > 1000 || bookId<=0)
            {
                Response.StatusCode = 400;

                return Content("Book id cannot be over 1000 or below 0! It must be 1 and 1000");

            }


            // isloggedin should be true
            bool isUserLoggedIn = Convert.ToBoolean(Request.Query["isloggedin"]);
            if (!isUserLoggedIn) 
            {
                Response.StatusCode = 401;

                return Content("User must be authenticatd...");
            }


            

            return File($"/docs.pdf", "application/pdf");
        }
    }
}
