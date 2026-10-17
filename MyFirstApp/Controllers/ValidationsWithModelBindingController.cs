using Microsoft.AspNetCore.Mvc;
using MyFirstApp.CustomeModelBinders;
using MyFirstApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace MyFirstApp.Controllers
{
    public class ValidationsWithModelBindingController : Controller
    {

        //[Route("/register")]
        // public IActionResult Index([Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]
        //Person person)


        // Example JSON: {"PersonName": "William", "Email": "william@example.com", "Phone": "123456", "Password":"william123", "ConfirmPassword": "william123"}
        [Route("/register")]
        //public IActionResult Index([FromBody] [ModelBinder(BinderType = typeof(PersonModelBinder))] Person person)
        // We have model binder provider for Person now
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")]string UserAgent)
        {
          

            if (!ModelState.IsValid)
            {
         

                List<string> errorList  =  ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage).ToList();


                string errors =  string.Join("\n", errorList);

                return BadRequest(errors);

            }

                // This is the way you can retrive from request headers - but this is lengthy
                // ControllerContext.HttpContext.Request.Headers["key"]
                return Content($"{person}, {UserAgent}");
            


            

        }
    }
}
