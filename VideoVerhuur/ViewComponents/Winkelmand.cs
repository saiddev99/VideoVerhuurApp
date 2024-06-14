using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace VideoVerhuur.ViewComponents;

public class Winkelmand:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string? ingelogd = HttpContext.Session.GetString("ingelogd");

        if (ingelogd != null)
        {
            return View();
        }


        return new ContentViewComponentResult(string.Empty);
    }
}
