using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;
namespace MyFirstApp.Controllers
{
    public class ValidationsWithModelBindingController : Controller
    {

        [Route("/register")]
        public IActionResult Index(Person person)
        {
            //if (string.IsNullOrEmpty(person.PersonName))
            //{
            //    return BadRequest("Person Name is not provided");
            //}


            return Content($"{person}");

        }
    }
}
