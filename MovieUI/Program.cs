using Microsoft.Extensions.DependencyInjection;
using MovieApplication.Implementations;
using MovieApplication.Interfaces;
using MovieDomain.DTOs;
using MovieDomain.Entities;
using MovieDomain.Intefraces;
using MovieInfrastructure.Data;
using MovieInfrastructure.Repositories;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace MovieUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region without di container
            var dbContext = new MovieDbContext();
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

            service.AddScoped<IActorRepository, ActorRepository>();
            service.AddScoped<IActorService, ActorService>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            var serviceProvider = service.BuildServiceProvider();
            var movieService = serviceProvider.GetRequiredService<IMovieService>();
            var actorService = serviceProvider.GetRequiredService<IActorService>();

            #region Old Code
            //// ვამატებთ ფილმს ბაზაში
            //CreateMovieDTO createMovieDTO = new CreateMovieDTO { Title = "The Matrix", ReleaseYear = 1999, StudioId = 1 };
            //await movieService.AddMovieAsync(createMovieDTO);
            //await dbContext.SaveChangesAsync();

            // ვიღებთ ფილმების სიას
            //var movies = await movieService.GetAllMoviesAsync();
            //foreach (MovieDTO movie in movies)
            //{
            //    Console.WriteLine(movie);
            //}
            #endregion

            //var studio = new Studio
            //{
            //    Name = "Warner Bros",
            //    CountryId = 1
            //};
            //dbContext.Studios.Add(studio);
            //await dbContext.SaveChangesAsync();

            //var st = await dbContext.Studios.FirstOrDefaultAsync(s => s.Name == "Warner Bros");
            //var movieDto = new CreateMovieDTO { Title = "Home Alone 3", ReleaseYear = 1996, StudioId = st.Id };
            //var movieDto2 = new CreateMovieDTO { Title = "Home Alone 4", ReleaseYear = 1998, StudioId = st.Id };
            //await movieService.AddMovieAsync(movieDto);
            //await movieService.AddMovieAsync(movieDto2); // save changes not needed because of unit of work

            //var actorDto = new CreateActorDTO { FirstName = "Jon", LastName = "Doe" };
            //await actorService.AddActorAsync(actorDto);

            //var film1 = await dbContext.Movies.FirstAsync(m => m.Title == "Home Alone 3");
            //var film2 = await dbContext.Movies.FirstAsync(m => m.Title == "Home Alone 4");

            //var updateActorDto = new UpdateActorMovieDTO { MovieIds = new List<int> { film1.Id, film2.Id } };
            //await actorService.UpdateActorMovieAsync(1, updateActorDto);

            //var actorsWithMovies = await dbContext.Actors.Include(a => a.Movies).ToListAsync();
            //foreach (var item in actorsWithMovies)
            //{
            //    Console.Write($"{item.FirstName} {item.LastName}");
            //    foreach (var movie in item.Movies)
            //    {
            //        Console.Write($" - {movie.Title}");
            //    }
            //    Console.WriteLine();
            //}

            var searched = await movieService.SearchMoviesByStudioAsync(1500, "Warner Bros", 1);
            foreach (var item in searched)
            {
                Console.WriteLine(item);
            }
        }
    }
}
