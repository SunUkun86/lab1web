using lab1.app.Data;
using lab1.app.Data.Models;
using lab1.app.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab1.app.Services
{
    public class FilmService : IFilmService
    {
        private readonly CinemaDbContext _context;

        public FilmService(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Film> AddFilmAsync(Film filmToAdd)
        {
            await _context.Films.AddAsync(filmToAdd);
            await _context.SaveChangesAsync();

            return filmToAdd;
        }

        public async Task<Film?> GetFilmByIdAsync(int filmId)
        {
            var film = await _context.Films.FirstOrDefaultAsync(f => f.Id == filmId);
            return film;
        }

        public IEnumerable<Film> GetAllFilm()
        {
            var films = _context.Films.AsEnumerable();
            return films;
        }
    }
}
