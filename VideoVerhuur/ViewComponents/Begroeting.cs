using Microsoft.AspNetCore.Mvc;

namespace VideoVerhuur.ViewComponents;
public class Begroeting: ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
