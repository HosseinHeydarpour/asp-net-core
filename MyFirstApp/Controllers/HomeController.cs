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

            

            // instead of using ViewBag or ViewData we send the data as arg in View return
            // first view name the model object
            return View("Index",people);  // if ypu do not specify view name it will be : Index.cshtml  --> Views/Home/Index.cshtml expected location - if is not present asp cannot rexognize
            //return View("abc"); // abc.cshtml

            
        }


        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if(name == null)
            {
                return BadRequest("Person name cannot be null");
            }

            List<Person> people = new List<Person>()
            {
                new Person() { Name = "John", DateOfBirth = Convert.ToDateTime("2000-03-02"), PersonGender=Gender.Male },
                new Person() { Name = "Pam", DateOfBirth = Convert.ToDateTime("2001-04-22"), PersonGender=Gender.Female },
                new Person() { Name = "Al", DateOfBirth = null, PersonGender=Gender.Other }
            };

            Person? foundPerson = people.Where(p => p.Name == name).FirstOrDefault();

            return View(foundPerson); // Calling Views/Home/Details.cshtml

        }


        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {

            Person person = new Person() { Name = "Sara", DateOfBirth = Convert.ToDateTime("2000-03-02"), PersonGender = Gender.Male };

            Product product = new Product()
            {
                ProductId= 1, 
                ProductName = "Gamin Mouse"
            };


            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel
            {
                PersonData = person,
                ProductData = product
            };
                
            return View(personAndProductWrapperModel);
        }


    
    
    }



    



}
