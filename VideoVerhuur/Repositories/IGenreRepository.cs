using VideoVerhuurLibrary.Models;

namespace VideoVerhuur.Repositories;

public interface IGenreRepository
{
    List<Genre> GetAll();
    Genre? Get(int id);
}
