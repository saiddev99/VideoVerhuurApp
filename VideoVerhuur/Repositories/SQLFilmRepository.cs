using Microsoft.EntityFrameworkCore;
using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Repositories;

public class SQLFilmRepository : IFilmRepository
{
    private readonly VideoVerhuurContext _context;

    public SQLFilmRepository(VideoVerhuurContext context)
    {
        _context = context;
    }
    public Film? Get(int id)
    {
        return _context.Films.Find(id);
    }

    public List<Film> GetAll()
    {
        return _context.Films.ToList();
    }

    public void TransactionInVoorraad(int id)
    {
        _context.Films.Find(id).InVoorraad -= 1;
        _context.SaveChanges();
    }
}
