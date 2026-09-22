using Microsoft.Extensions.DependencyInjection;
using MovieApplication.Implementations;
using MovieApplication.Interfaces;
using MovieDomain.DTOs;
using MovieDomain.Entities;
using MovieDomain.Intefraces;
using MovieInfrastructure.Data;
using MovieInfrastructure.Repositories;
using System.Reflection;

namespace MovieUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region without di container
            //var dbContext = new MovieDbContext();
            //var movieRepository = new MovieRepository(dbContext);
            //var movieService = new MovieService(movieRepository);
            #endregion
            //// ამას სატესტოდ ვაკეთებ და სტუდიოს სერვისს რომ შევქმნი მერე გავაკეთებ როგორც საჭიროა:
            //Studio studio = new Studio { Name = "Warner Bros", CountryId = 1 };
            //dbContext.Studios.Add(studio);
            //await dbContext.SaveChangesAsync();

            //di container
            var service = new ServiceCollection();
            service.AddDbContext<MovieDbContext>();
            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<IMovieService, MovieService>();
            var serviceProvider = service.BuildServiceProvider();
            var movieService = serviceProvider.GetRequiredService<IMovieService>();

            //// ვამატებთ ფილმს ბაზაში
            //CreateMovieDTO createMovieDTO = new CreateMovieDTO { Title = "The Matrix", ReleaseYear = 1999, StudioId = 1 };
            //await movieService.AddMovieAsync(createMovieDTO);
            //await dbContext.SaveChangesAsync();

            // ვიღებთ ფილმების სიას
            var movies = await movieService.GetAllMoviesAsync();
            foreach (MovieDTO movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
}
