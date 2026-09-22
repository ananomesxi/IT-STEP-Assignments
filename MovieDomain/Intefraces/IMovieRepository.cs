using MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Intefraces
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetAllMovies();
        Task AddMovie(Movie movie);
        Task<Movie> GetMovieById(int id);
        Task DeleteMovie(int id);
        Task UpdateMovie(Movie movie);

    }
}
