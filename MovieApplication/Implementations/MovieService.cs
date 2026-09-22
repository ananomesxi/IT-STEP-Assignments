using MovieApplication.Interfaces;
using MovieDomain.DTOs;
using MovieDomain.Entities;
using MovieDomain.Intefraces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<ICollection<MovieDTO>> GetAllMoviesAsync() 
        {
            var movies = await _movieRepository.GetAllMovies();
            var movieDtos = movies.Select(m => new MovieDTO
            {
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                StudioName = m.Studio.Name
            }).ToList();
            return movieDtos;
        }

        public async Task AddMovieAsync (CreateMovieDTO createMovieDto)
        {
            if (createMovieDto == null)
            {
                throw new ArgumentNullException(nameof(createMovieDto));
            }
            if (string.IsNullOrWhiteSpace(createMovieDto.Title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(createMovieDto.Title));
            }
            if (createMovieDto.ReleaseYear <= 0)
            {
                throw new ArgumentException("Release year must be a positive integer.", nameof(createMovieDto.ReleaseYear));
            }
            if (createMovieDto.ReleaseYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Release year cannot be in the future.", nameof(createMovieDto.ReleaseYear));
            }
            if (createMovieDto.StudioId <= 0)
            {
                throw new ArgumentException("Studio ID must be a positive integer.", nameof(createMovieDto.StudioId));
            }
            var movie = new Movie
            {
                Title = createMovieDto.Title,
                ReleaseYear = createMovieDto.ReleaseYear,
                StudioId = createMovieDto.StudioId
            };
            await _movieRepository.AddMovie(movie);
        }

        public async Task<MovieDTO> GetMovieById (int id)
        {
            
            var movie = await _movieRepository.GetMovieById(id);

            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {id} not found.");
            }

            MovieDTO movieDto = new MovieDTO
            {
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                StudioName = movie.Studio.Name
            };
            return movieDto;
        }

        public async Task DeleteMovie (int id)
        {
            await _movieRepository.DeleteMovie(id);
        }

        public async Task UpdateMovie (int id,string title, int releaseYear, int studioId)
        {
            var movie = await _movieRepository.GetMovieById(id);

            if (movie == null)
                return;

            movie.Title = title;
            movie.ReleaseYear = releaseYear;
            movie.StudioId = studioId;

            await _movieRepository.UpdateMovie(movie);
        }
    }
}
