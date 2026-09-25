using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MovieDomain.Entities;
using MovieDomain.Intefraces;
using MovieInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieInfrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }



        public async Task AddMovieAsync(Movie movie)
        {
            await _movieDbContext.Movies.AddAsync(movie);
            //await _movieDbContext.SaveChangesAsync(); ჩავანაცვლეთ unitOfWork-ით
        }

        public async Task<ICollection<Movie>> GetAllMoviesAsync()
        {
            return await _movieDbContext.Movies.Include(m => m.Studio).ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync (int id)
        {
            return await _movieDbContext.Movies.Include(m => m.Studio).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteMovieAsync(int id)
        {

            var movieExists = await _movieDbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieExists == null)
            {
                throw new ArgumentException("Movie not found");
            }

            _movieDbContext.Movies.Remove(movieExists);
            //await _movieDbContext.SaveChangesAsync();

        }

        public async Task UpdateMovieAsync (int id, Movie movie)
        {
            var movieEx = await _movieDbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                throw new ArgumentException("Movie not found.");
            }
            movieEx.Title = movie.Title;
            movieEx.ReleaseYear = movie.ReleaseYear;
            movieEx.StudioId = movie.StudioId;
            //await _movieDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> SearchMoviesByStudioAsync (int year, string studioName, int minActorCount) {
            var movies = await _movieDbContext.Movies
                .Include(m => m.Studio)
                .ThenInclude(s => s.Country)
                .Include(m => m.Actors)
                .Where(m => m.ReleaseYear >= year && m.Studio.Name == studioName && m.Actors.Count() >= minActorCount)
                .OrderByDescending(m => m.ReleaseYear)
                .ThenBy(m => m.Title)
                .ToListAsync();
            return movies;
        }

        public async Task<ICollection<Movie>> SearchMoviesByCountryAsync (string countryName, int minYear, int maxActorCount)
        {
            var movies = await _movieDbContext.Movies
                .Include(m => m.Actors)
                .Include(m => m.Studio)
                .ThenInclude(s => s.Country)
                .Where(m => m.Studio.Country.Name == countryName && m.ReleaseYear >= minYear && m.Actors.Count() <= maxActorCount)
                .OrderBy(m => m.Actors.Count())
                .ThenByDescending(m => m.ReleaseYear)
                .ThenBy(m => m.Title)
                .ToListAsync();
            return movies;
        }

        public async Task<ICollection<Movie>> SearchMoviesAdvancedAsync (int fromYear, int toYear, string countryName, string titleText, int minActorCount)
        {
            var movies = await _movieDbContext.Movies
                .Include(m => m.Actors)
                .Include(m => m.Studio)
                .ThenInclude(s => s.Country)
                .Where(m => m.ReleaseYear >= fromYear && m.ReleaseYear <= toYear && m.Studio.Country.Name == countryName && m.Title.Contains(titleText) && m.Actors.Count() >= minActorCount)
                .OrderByDescending(m => m.Actors.Count())
                .ThenByDescending(m => m.ReleaseYear)
                .ThenBy(m => m.Studio.Name)
                .ThenBy(m => m.Title)
                .ToListAsync();
            return movies;
        }
    }
}
