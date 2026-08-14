using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
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

            if(!ModelState.IsValid)
            {
                //List<string> errorList = new List<string>();
                //foreach (var val in ModelState.Values)
                //{
                //    foreach (var error in val.Errors)
                //    {
                //        errorList.Add(error.ErrorMessage);
                //    } 
                //}

                List<string> errorList  =  ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage).ToList();


                string errors =  string.Join("\n", errorList);

                return BadRequest(errors);

            } else
            {
                return Content($"{person}");
            }


            

        }
    }
}
