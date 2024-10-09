using lab1.app.Data;
using lab1.app.Data.Models;
using lab1.app.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab1.app.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly CinemaDbContext _context;

        public CinemaService(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Cinema> AddCinemaAsync(Cinema filmToAdd)
        {
            await _context.Cinemas.AddAsync(filmToAdd);
            await _context.SaveChangesAsync();

            return filmToAdd;
        }

        public async Task<Cinema?> GetCinemaByIdAsync(int filmId)
        {
            var film = await _context.Cinemas.FirstOrDefaultAsync(f => f.Id == filmId);
            return film;
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
            var cinemas = _context.Cinemas.AsEnumerable();
            return cinemas;
        }
    }
}
