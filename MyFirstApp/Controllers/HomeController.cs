using Microsoft.AspNetCore.Mvc;

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


            return View();  // if ypu do not specify view name it will be : Index.cshtml  --> Views/Home/Index.cshtml expected location - if is not present asp cannot rexognize
            //return View("abc"); // abc.cshtml

            
        }
    }
}
