using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using VideoVerhuur.Filters;
using VideoVerhuur.Repositories;
using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Controllers;
[ForceLoginFilter("Index", "Home")]
public class AfrekeningController : Controller
{
    private IFilmRepository _filmRepository;

    public AfrekeningController(IFilmRepository filmRepository)
    {
            _filmRepository = filmRepository;
    }

    public IActionResult Index()
    {
        string sessionFilms = HttpContext.Session.GetString("Films");
        string sessionKlant = HttpContext.Session.GetString("klant");

        if (sessionFilms.IsNullOrEmpty())
        {
            return RedirectToAction("Index", "Genre");
        }

        List<Film>? films = JsonSerializer.Deserialize<List<Film>>(sessionFilms);
        ViewBag.Totaal = films.Sum(x => x.Prijs);
        ViewBag.Klant = JsonSerializer.Deserialize<Klant>(sessionKlant);

        foreach (var film in films)
        {
            _filmRepository.TransactionInVoorraad(film.FilmId);
        }

        return View(JsonSerializer.Deserialize<List<Film>>(sessionFilms));
        
    }

    public IActionResult Home()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
