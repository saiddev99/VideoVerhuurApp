using Microsoft.AspNetCore.Mvc;

namespace VideoVerhuur.ViewComponents;
public class Begroeting: ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string? ingelogd = HttpContext.Session.GetString("ingelogd");

        if (ingelogd == null)
        {
            ViewBag.Session = "Welkom! Meld je aan om te kunnen huren!";
            return View((object)ViewBag.Session);
        }

        ViewBag.Session = $"Welkom, {ingelogd}";
        return View((object)ViewBag.Session);
    }
}
