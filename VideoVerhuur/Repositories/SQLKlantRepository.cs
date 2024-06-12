namespace VideoVerhuur.Repositories;

using System.Collections.Generic;
using VideoVerhuurLibrary.Models;
public class SQLKlantRepository: IKlantRepository
{
    private readonly VideoVerhuurContext _context;

    public SQLKlantRepository(VideoVerhuurContext context)
    {
        _context = context;
    }

    public Klant? GetKlant(string Naam, string PostCode)
    {
        return _context.Klanten
            .Where(x => x.Naam == Naam)
            .FirstOrDefault(x => x.PostCode == PostCode);
    }
}
