using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.ViewComponents
{
    public class GridViewComponent: ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Sample");
        }
    }
}
