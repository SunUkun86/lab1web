using lab1.app.Data.Models;

namespace lab1.app.Interfaces
{
    public interface ICinemaService
    {
        public Task<Cinema> AddCinemaAsync(Cinema cinema);
        public Task<Cinema?> GetCinemaByIdAsync(int cinemaId);
        public IEnumerable<Cinema> GetAllCinemas();
    }
}
