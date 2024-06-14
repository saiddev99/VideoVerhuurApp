using Microsoft.EntityFrameworkCore;
using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Repositories;

public class SQLGenreRepository : IGenreRepository
{
    private readonly VideoVerhuurContext _context;

    public SQLGenreRepository(VideoVerhuurContext context)
    {
        _context = context;
    }
    public Genre? Get(int id)
    {
        return _context.Genres.Include("Films").FirstOrDefault(x => x.GenreId == id);
    }

    public List<Genre> GetAll()
    {
        return _context.Genres.ToList();
    }
}
