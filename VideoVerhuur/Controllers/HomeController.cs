using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using VideoVerhuur.Models;
using VideoVerhuur.Repositories;
using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Controllers;
public class HomeController : Controller
{
    private readonly IKlantRepository _klantRepository;
    public HomeController(IKlantRepository klantRepository)
    {
       _klantRepository = klantRepository;
    }

    public IActionResult Index()
    {
        InlogViewModel inlogViewModel = new InlogViewModel();

        return View(inlogViewModel);
    }

    public IActionResult Inloggen(InlogViewModel inlogViewModel)
    {
        Klant? klant = _klantRepository.GetKlant(inlogViewModel.Naam, inlogViewModel.PostCode);

        if (!inlogViewModel.Naam.IsNullOrEmpty())
        {
            if (inlogViewModel.Naam != klant.Naam)
            {
                ViewBag.ErrorMessage = "Onbekende klant, probeer opnieuw.";
            }
        }
        else
        {
            ViewBag.ErrorMessage = "";
        }

        return View(nameof(Index), inlogViewModel);
    }

  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
