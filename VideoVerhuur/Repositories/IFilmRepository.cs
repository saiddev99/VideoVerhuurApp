using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Repositories;

public interface IFilmRepository
{
    List<Film> GetAll();
    Film? Get(int id);
    void TransactionInVoorraad(int id);
}
