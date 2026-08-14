using Microsoft.AspNetCore.Mvc;
using System.Net;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class IActionResultExampleController : Controller
    {

        [Route("bookstore/{bookid:int?}/{isloggedin:bool?}")]
        // public ContentResult Index() - this definition of  the method gives us an error when returning the file content 
        //public IActionResult Index([FromRoute]int? bookid, [FromRoute]bool? isloggedin)
        public IActionResult Index([FromQuery] int? bookid, [FromRoute] bool? isloggedin, Book book)
        {
            if (bookid.HasValue == false)
            {
                //=================
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied!");
                //=================

                //return new BadRequestResult();
                return BadRequest("Book id is not supplied!");
            }


            // Book id cannot be over 1000
       
            if (bookid > 1000 )
            {
                //Response.StatusCode = 400;

                //return Content("Book id cannot be over 1000 or below 0! It must be 1 and 1000");

                return NotFound($"Book with id: {bookid} not found :( ");

            } 
            if(bookid <= 0)
            {
                return BadRequest("Book id cannot be negative or 0! It must be 1 and 1000");
            }


            // isloggedin should be true
         
            if (isloggedin == false) 
            {
                //Response.StatusCode = 401;

                //return Content("User must be authenticatd...");


                // return Unauthorized("User must be authenticatd...");

                return StatusCode(401, "User must be authenticatd...");
            }




            
            return Content($"Book with id: {bookid}, Book: {book}", "text/plain");



        }
    }
}
