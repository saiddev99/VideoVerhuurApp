using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Repositories;

public interface IKlantRepository
{
    Klant? GetKlant(string Naam, string PostCode);
}
