using Microsoft.EntityFrameworkCore;
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



        public async Task AddMovie(Movie movie)
        {
            await _movieDbContext.Movies.AddAsync(movie);
            await _movieDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> GetAllMovies()
        {
            return await _movieDbContext.Movies.Include(m => m.Studio).ToListAsync();
        }

        public async Task<Movie> GetMovieById (int id)
        {
            return await _movieDbContext.Movies.Include(m => m.Studio).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _movieDbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return;
            }
            _movieDbContext.Movies.Remove(movie);
            await _movieDbContext.SaveChangesAsync();
        }

        public async Task UpdateMovie (Movie movie)
        {
            var exMovie = await _movieDbContext.Movies.FindAsync(movie.Id);
            if (exMovie == null)
            {
                return;
            }
            exMovie.Title = movie.Title;
            exMovie.ReleaseYear = movie.ReleaseYear;
            exMovie.StudioId = movie.StudioId;

            await _movieDbContext.SaveChangesAsync();
        }
    }
}
