using Microsoft.AspNetCore.Mvc;


namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("Home")]
        public IActionResult Index()
        {
            ViewData["ListTitle"] = "Cities";
            ViewData["ListItems"] = new List<string>() 
            {
                "Paris",
                "New York",
                "New Mumbai",
                "Rome"
            };
      

            return View();
        }


        [Route("Privacy")]

        [Route("Home/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }


        [Route("Home/About")]
        public IActionResult About()
        {
            return View();
        }
    }
}
