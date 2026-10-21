using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {

        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            // this is not used in real world
            //return new ViewResult() { ViewName = "abc"};


            ViewData["appTitle"] = "Asp.Net Core App 1";

            //string welcomeMessage = "Welcome";


            List<Person> people = new List<Person>()
    {
                new Person() { Name = "John", DateOfBirth = Convert.ToDateTime("2000-03-02"), PersonGender=Gender.Male },
                new Person() { Name = "Pam", DateOfBirth = Convert.ToDateTime("2001-04-22"), PersonGender=Gender.Female },
                new Person() { Name = "Al", DateOfBirth = null, PersonGender=Gender.Other }
            };

            ViewData["welcomeMessage"] = "Welcome";

            ViewData["people"] = people;

            return View();  // if ypu do not specify view name it will be : Index.cshtml  --> Views/Home/Index.cshtml expected location - if is not present asp cannot rexognize
            //return View("abc"); // abc.cshtml

            
        }
    }
}
