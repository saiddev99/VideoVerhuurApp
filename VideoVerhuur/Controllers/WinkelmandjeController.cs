using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using VideoVerhuur.Filters;
using VideoVerhuur.Repositories;
using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Controllers;
[ForceLoginFilter("Index", "Home")]
public class WinkelmandjeController : Controller
{
    private readonly IFilmRepository _filmRepository;

    public WinkelmandjeController(IFilmRepository filmRepository)
    {
            _filmRepository = filmRepository;
    }
    public IActionResult Index()
    {
        string sessionFilms = HttpContext.Session.GetString("Films");

        if (sessionFilms.IsNullOrEmpty())
        {
            return View();
        }

        List<Film>? films = JsonSerializer.Deserialize<List<Film>>(sessionFilms);

        if (films.IsNullOrEmpty())
        {
            return View();
        }
        else
        {
            ViewBag.lastAddedFilm = JsonSerializer.Deserialize<List<Film>>(sessionFilms).Last().GenreId;
            return View(JsonSerializer.Deserialize<List<Film>>(sessionFilms));
        }
    }

    public IActionResult Verwijdering(int id = 0)
    {
        if (id == 0)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(_filmRepository.Get(id));
    }

    public IActionResult Verwijder(int id = 0)
    {
        if (id == 0)
        {
            return RedirectToAction(nameof(Index));
        }

        var sessionFilms = HttpContext.Session.GetString("Films");
        List<Film>? films = JsonSerializer.Deserialize<List<Film>>(sessionFilms);
        Film film = _filmRepository.Get(id);
        films.Remove(films.FirstOrDefault(x => x.FilmId == film.FilmId));


        HttpContext.Session.SetString("Films", JsonSerializer.Serialize(films));
        Console.WriteLine(JsonSerializer.Serialize(films));
        Console.WriteLine(HttpContext.Session.GetString("Films"));
        return RedirectToAction("Index");
    }
}
