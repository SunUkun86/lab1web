using lab1.app.Data.Models;

namespace lab1.app.Interfaces
{
    public interface IFilmService
    {
        public Task<Film> AddFilmAsync(Film filmToAdd);

        public Task<Film?> GetFilmByIdAsync(int filmId);

        public IEnumerable<Film> GetAllFilm();
    }
}
