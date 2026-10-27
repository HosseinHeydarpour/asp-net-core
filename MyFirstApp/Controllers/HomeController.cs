using Microsoft.AspNetCore.Mvc;


namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("Home")]
        public IActionResult Index()
        {
           
      

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
