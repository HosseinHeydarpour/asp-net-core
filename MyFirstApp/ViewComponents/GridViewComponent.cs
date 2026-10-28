using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.ViewComponents
{
    public class GridViewComponent: ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {

            PersonGridModel model = new PersonGridModel();

            model.GridTitle = "View Component Data";

            model.PersonList = new List<Person> {
                new Person() {PersonName="John Doe", JobTitle="Cashier"},
                new Person() {PersonName="Jane Smith", JobTitle="Analyst"},
                new Person() {PersonName="John Mop", JobTitle="Data"}
            };

            //ViewData["Grid"] = model;


            return View("Sample", model);
        }
    }
}
