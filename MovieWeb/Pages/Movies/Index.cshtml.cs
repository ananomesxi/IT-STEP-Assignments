using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApplication.Interfaces;
using MovieDomain.DTOs;
using MovieDomain.Intefraces;

namespace MovieWeb.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService _movieService;

        public IndexModel (IMovieService movieService)
        {
            _movieService = movieService;
        }

        public ICollection<MovieDTO> Movies { get; set; } = new List<MovieDTO>();
        public async Task OnGetAsync()
        {
            Movies = await _movieService.GetAllMoviesAsync();
        }

        //public List<string> Movies = new List<string>();

        //public void OnGet()
        //{
        //    Movies.Add("Inception");
        //    Movies.Add("Interstellar");
        //}

    }
}
