using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;


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


        [Route("/programming-languages")]
        public IActionResult ProgrammingLanguages() 
        {
            ListModel listModel = new ListModel();
            listModel.ListTitle = "Programming LANGS";
            listModel.ListItems = new List<string>()
            {
                "C#",
                "Javascript",
                "Go",
                "Rust",
                "COBOL"
            };

            return PartialView("_ListPartialView", listModel);

        
        }


        [Route("/friends-list")]
        public IActionResult LoadFriendsList()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Friends",
                PersonList = new List<Person>()
                {
                    new Person()
                    {
                        PersonName = "John",
                        JobTitle = "CEO"
                    },
                    new Person()
                    {
                        PersonName = "Marry",
                        JobTitle = "Marketing agent"
                    },
                    new Person()
                    {
                        PersonName = "Juana",
                        JobTitle = "Rec"
                    }
                }
            };

            return ViewComponent("Grid", new {  grid= personGridModel });
        }
    }
}
