

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


        [Route("file-download")]
        // we use virtual file result if file is present in wwwroot folder
        public VirtualFileResult FileDownload()
        {
            // return new VirtualFileResult("/docs.pdf","application/pdf");


            // Shortcut
            return File("/docs.pdf", "application/pdf");
        }


        [Route("file-download2")]
        // This is not a good practice - virtaul file result is a better choice
        public PhysicalFileResult PhysicalFileResult()
        {
            // return new PhysicalFileResult(@"D:\backend\ASP Core .NET\MyFirstApp\MyFirstApp\wwwroot\Sample.txt", "text/plain");


            // Shortcut
            return PhysicalFile(@"D:\backend\ASP Core .NET\MyFirstApp\MyFirstApp\wwwroot\Sample.txt", "text/plain");
        }

        [Route("file-download3")]
        // Very useful when you want to read imgaes from DB
        public FileContentResult FileContentResult()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"D:\backend\ASP Core .NET\MyFirstApp\MyFirstApp\wwwroot\img.jpg");

            // return new FileContentResult(bytes, "text/plain");

            // Shortcut
            return File(bytes, "image/jpeg");
        }




    }
}
