using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.ViewComponents
{
    public class GridViewComponent: ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid)
        {

      


            return View("Sample", grid);
        }
    }
}
