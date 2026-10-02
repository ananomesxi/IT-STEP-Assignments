using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApplication.Interfaces;
using MovieDomain.DTOs;

namespace MovieWeb.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IMovieService _movieService;

        public CreateModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [BindProperty]
        public CreateMovieDTO Movie { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                await _movieService.AddMovieAsync(Movie);
                TempData["Success"] = "Movie added successfully.";
                TempData.Remove("Error");
                Movie = new();
                ModelState.Clear();
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return Page();
        }

    }
}