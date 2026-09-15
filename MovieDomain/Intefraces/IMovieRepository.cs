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
    }
}
