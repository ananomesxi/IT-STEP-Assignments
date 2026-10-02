using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApplication.Interfaces;
using MovieDomain.DTOs;

namespace MovieWeb.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieService _movieService;

        public EditModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [BindProperty]
        public UpdateMovieDTO Movie { get; set; } = new();

        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Id = id;
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            Movie = new UpdateMovieDTO
            {
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                StudioId = 1 //  ill fix this after
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _movieService.UpdateMovieAsync(id, Movie);
                TempData["Success"] = "Movie updated successfully.";
                return RedirectToPage("/Movies/Index");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return Page();
            }
        }
    }
}