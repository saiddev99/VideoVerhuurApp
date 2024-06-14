using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using VideoVerhuur.Filters;
using VideoVerhuur.Repositories;
using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Controllers;
[ForceLoginFilter("Index", "Home")]
public class GenreController : Controller
{
    private IGenreRepository _genreRepository;
    private IFilmRepository _filmRepository;
    public GenreController(IGenreRepository genreRepository, IFilmRepository filmRepository)
    {
        _genreRepository = genreRepository;
        _filmRepository = filmRepository;

    }
    public IActionResult Index()
    {
        return View(_genreRepository.GetAll());
    }

    public IActionResult Detail(int id)
    {
        var errorCheck = HttpContext.Session.GetString("Error");

        if (errorCheck != null)
        {
            ViewBag.IsToegevoegd = true;
            ViewBag.Error = errorCheck;
        }
        else
        {
            ViewBag.IsToegevoegd = false;
            ViewBag.Error = "";
        }

        return View(_genreRepository.Get(id));
    }

    public IActionResult Toevoegen(int id = 0)
    {
        if (id == 0)
        {
            return RedirectToAction(nameof(Index));
        }

        var sessionFilms = HttpContext.Session.GetString("Films");
        List<Film>? films;

        if (sessionFilms.IsNullOrEmpty())
        {
            films = new List<Film>();
        }
        else
        {
            films = JsonSerializer.Deserialize<List<Film>>(sessionFilms);
        }

        Film film = _filmRepository.Get(id);

        if (!films.Any(x => x.FilmId == film.FilmId))
        {
            ViewBag.IsToegevoegd = false;

            films?.Add(film);

            HttpContext.Session.SetString("Films", JsonSerializer.Serialize(films));

            HttpContext.Session.Remove("Error");

            return RedirectToAction("Index", "Winkelmandje");
        }
        else
        {
            HttpContext.Session.SetString("Error", "Je mag een film maar 1 keer toevoegen");
            return RedirectToAction(nameof(Detail), new {id = film.GenreId});
        }
    }
}
