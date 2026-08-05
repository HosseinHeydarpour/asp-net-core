

using Microsoft.AspNetCore.Mvc;

// Import created models into controller
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    // [Controller] - this is optional and can get removed because our class has the suffix Controller
    public class HomeController : Controller 
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            //return new ContentResult() 
            //{
            //    Content = "Hello From Index", ContentType = "text/plain"
            //};

            // shortcut version of the code ablove - remeber the class must inherit Microsoft.AspNetCore.Mvc.Controller
            // return Content("Hello From Index", "text/plain");

            return Content("<h1> WELCOMCE </h1> <h2> Hello From Index </h2>", "text/html");
        }


        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("person")]
        public JsonResult Person()
        {

            // Not a good way!
            //return "{\"name\": \"Al\", \"lastName\": \"Miola\"}";


            Person person = new Person() { Id = Guid.NewGuid(), FirstName="John", LastName="Marston",  Age= 34 };

            //return new JsonResult(person);

            // shortcut way - equivalant to:  new JsonResult(person)
            return Json(person);

       

        }



        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
     
        public string Contact()
        {
            return "Hello from Contact";
        }
    }
}
