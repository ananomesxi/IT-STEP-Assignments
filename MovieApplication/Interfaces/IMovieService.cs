using MovieDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Interfaces
{
    public interface IMovieService
    {
        Task<ICollection<MovieDTO>> GetAllMoviesAsync();
        Task AddMovieAsync(CreateMovieDTO createMovieDto);
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task DeleteMovieAsync(int id);
        Task UpdateMovieAsync(int id, UpdateMovieDTO movieDto);
        Task<ICollection<SearchMovieDTO>> SearchMoviesByStudioAsync(int year, string studioName, int minActorCount);
        Task<ICollection<SearchMovieDTO>> SearchMoviesByCountryAsync(string countryName, int minYear, int maxActorCount);
        Task<ICollection<SearchMovieDTO>> SearchMoviesAdvancedAsync(int fromYear, int toYear, string countryName, string titleText, int minActorCount);

    }
}
