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
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ICollection<MovieDTO>> GetAllMoviesAsync() 
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
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
            await _movieRepository.AddMovieAsync(movie);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<MovieDTO> GetMovieByIdAsync (int id)
        {
            
            var movie = await _movieRepository.GetMovieByIdAsync(id);

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

        public async Task DeleteMovieAsync (int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Movie id must be positive", nameof(id));
            }
            await _movieRepository.DeleteMovieAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(int id, UpdateMovieDTO movieDto)
        {

            if (movieDto == null)
            {
                throw new ArgumentNullException(nameof(movieDto));
            }
            if (string.IsNullOrWhiteSpace(movieDto.Title))
            {
                throw new ArgumentException("Movie title cannot be null or empty.", nameof(movieDto.Title));
            }
            if (movieDto.ReleaseYear < 0)
            {
                throw new ArgumentException("Movie release year cannot be negative.", nameof(movieDto.ReleaseYear));
            }
            if (movieDto.ReleaseYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Movie release year cannot be from future.", nameof(movieDto.ReleaseYear));
            }
            if (movieDto.StudioId <= 0)
            {
                throw new ArgumentException("Movie studio ID must be a positive integer.", nameof(movieDto.StudioId));
            }

            var movie = new Movie
            {
                Title = movieDto.Title,
                ReleaseYear = movieDto.ReleaseYear,
                StudioId = movieDto.StudioId
            };
            await _movieRepository.UpdateMovieAsync(id, movie);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<SearchMovieDTO>> SearchMoviesByStudioAsync(int year, string studioName, int minActorCount) 
        { 
            if (year < 0)
            {
                throw new ArgumentException("Year cannot be negative.", nameof(year));
            }
            if (string.IsNullOrWhiteSpace(studioName))
            {
                throw new ArgumentNullException("Studio name cannot be null or empty", nameof(studioName));
            }
            if(minActorCount < 0)
            {
                throw new ArgumentException("Actor count cannot be negative.", nameof(minActorCount));
            }
            var movies = await _movieRepository.SearchMoviesByStudioAsync(year, studioName, minActorCount);
            var movieDtos = movies.Select(MapSearchMovieDTO).ToList();
            return movieDtos;
        }

        public async Task<ICollection<SearchMovieDTO>> SearchMoviesByCountryAsync(string countryName, int minYear, int maxActorCount)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                throw new ArgumentNullException("Country name cannot be null or empty", nameof(countryName));
            }
            if (minYear < 0)
            {
                throw new ArgumentException("Year cannot be negative.", nameof(minYear));
            }
            if (maxActorCount < 0)
            {
                throw new ArgumentException("Actor count cannot be negative.", nameof(maxActorCount));
            }
            var movies = await _movieRepository.SearchMoviesByCountryAsync(countryName, minYear, maxActorCount);
            var movieDtos = movies.Select(MapSearchMovieDTO).ToList();
            return movieDtos;
        }

        public async Task<ICollection<SearchMovieDTO>> SearchMoviesAdvancedAsync(int fromYear, int toYear, string countryName, string titleText, int minActorCount)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                throw new ArgumentNullException("Country name cannot be null or empty", nameof(countryName));
            }
            if (string.IsNullOrWhiteSpace(titleText))
            {
                throw new ArgumentNullException("Text cannot be null or empty", nameof(titleText));
            }
            if (fromYear < 0)
            {
                throw new ArgumentException("Year cannot be negative.", nameof(fromYear));
            }
            if (toYear < 0)
            {
                throw new ArgumentException("Year cannot be negative.", nameof(toYear));
            }
            if (minActorCount < 0)
            {
                throw new ArgumentException("Actor count cannot be negative.", nameof(minActorCount));
            }
            var movies = await _movieRepository.SearchMoviesAdvancedAsync(fromYear, toYear, countryName, titleText, minActorCount);
            var movieDtos = movies.Select(MapSearchMovieDTO).ToList();
            return movieDtos;

        }

        private static SearchMovieDTO MapSearchMovieDTO (Movie movie)
        {
            return new SearchMovieDTO
            {
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                StudioName = movie.Studio.Name,
                CountryName = movie.Studio.Country.Name,
                ActorCount = movie.Actors.Count(),
            };
        }

    }
}
