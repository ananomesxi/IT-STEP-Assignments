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
        Task<MovieDTO> GetMovieById(int id);
        Task DeleteMovie(int id);
        Task UpdateMovie(int id, string title, int releaseYear, int studioId);

    }
}
