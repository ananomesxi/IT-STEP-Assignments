using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
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

        [BindProperty]
        public int Year { get; set; }
        [BindProperty]
        public string StudioName { get; set; } = string.Empty;
        [BindProperty]
        public int MinActorCount { get; set; }

        public async Task OnPostSearchAsync()
        {
            try
            {
                var searchResult = await _movieService.SearchMoviesByStudioAsync(Year, StudioName, MinActorCount);
                Movies = searchResult.Select(m => new MovieDTO
                {
                    Title = m.Title,
                    ReleaseYear = m.ReleaseYear,
                    StudioName = m.StudioName
                }).ToList();
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                // await OnGetAsync();
            }
        }


        public ICollection<MovieDTO> Movies { get; set; } = new List<MovieDTO>();
        public async Task OnGetAsync()
        {
            Movies = await _movieService.GetAllMoviesAsync();
        }


        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                await _movieService.DeleteMovieAsync(id);
                TempData["Success"] = "Movie deleted successfully.";
                Movies = await _movieService.GetAllMoviesAsync();
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToPage(); // Refresh the page after deletion
        }



        //public async Task OnPostDeleteAsync(int id)
        //{
        //    try
        //    {
        //        await _movieService.DeleteMovieAsync(id);
        //        TempData["Success"] = "Movie deleted successfully.";
        //        Movies = await _movieService.GetAllMoviesAsync();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        TempData["Error"] = ex.Message;
        //    }
        //    await OnGetAsync(); // Refresh the list after deletion
        //}


        //public List<string> Movies = new List<string>();

        //public void OnGet()
        //{
        //    Movies.Add("Inception");
        //    Movies.Add("Interstellar");
        //}

    }
}
