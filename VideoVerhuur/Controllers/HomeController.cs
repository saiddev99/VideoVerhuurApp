using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text.Json;
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
        string? ingelogd = HttpContext.Session.GetString("ingelogd");

        if (ingelogd == null)
        {
            InlogViewModel? inlogViewModel = new InlogViewModel();
            return View(inlogViewModel);
        }
        else
        {
            return RedirectToAction("Index", "Genre");
        }
        
    }

    public IActionResult Inloggen(InlogViewModel? inlogViewModel)
    {
        Klant? klant = _klantRepository.GetKlant(inlogViewModel.Naam, inlogViewModel.PostCode);

        if (klant == null)
        {
            inlogViewModel = null;
           ViewBag.ErrorMessage = "Onbekende klant, probeer opnieuw.";
            return View(nameof(Index), inlogViewModel);
        }
        else
        {
            string fullname = $"{klant.Voornaam} {klant.Naam}";
            HttpContext.Session.SetString("klant", JsonSerializer.Serialize(klant));
            HttpContext.Session.SetString("ingelogd", fullname);
            return RedirectToAction("Index", "Genre");   
        }
        
    }

  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
