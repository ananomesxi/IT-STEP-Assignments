using MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Intefraces
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetAllMoviesAsync();
        Task AddMovieAsync(Movie movie);
        Task<Movie> GetMovieByIdAsync(int id);
        Task DeleteMovieAsync(int id);
        Task UpdateMovieAsync(int id, Movie movie);
        Task<ICollection<Movie>> SearchMoviesByStudioAsync(int year, string studioName, int minActorCount);
        Task<ICollection<Movie>> SearchMoviesByCountryAsync(string countryName, int minYear, int maxActorCount);
        Task<ICollection<Movie>> SearchMoviesAdvancedAsync(int fromYear, int toYear, string countryName, string titleText, int minActorCount);

    }
}
