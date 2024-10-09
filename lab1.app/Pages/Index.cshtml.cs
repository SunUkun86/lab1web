using lab1.app.Data.Models;
using lab1.app.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1.app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IFilmService _filmService;

        public IEnumerable<Film> Films { get; set; } = null!;

        public IndexModel(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public async Task OnGetAsync()
        {
            Films = _filmService.GetAllFilm();
        }
    }
}
