using Microsoft.EntityFrameworkCore;
using MovieDomain.Entities;
using MovieInfrastructure.Data;
using MovieInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTest.Repositories
{
    public class MovieRepositoryTest
    {
        private MovieDbContext CreateContext ()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new MovieDbContext(options);
        }

        [Fact]
        public async Task GetAllMoviesAsync_ShouldReturnAllMovies() // name: WhatImTesting_WhatShouldHappen
        {
            // arrange
            var context = CreateContext();
            var country = new Country { Id = 1, Name = "USA" };
            var studio = new Studio { Id = 1, Name = "Warner Bros", Country = country };
            context.Countries.Add(country);
            context.Studios.Add(studio);
            var movie1 = new Movie { Id = 1, Title = "Inception", ReleaseYear = 2010, StudioId = studio.Id };
            var movie2 = new Movie { Id = 2, Title = "The Dark Knight", ReleaseYear = 2008, StudioId = studio.Id };
            context.Movies.AddRange(movie1, movie2);
            await context.SaveChangesAsync();

            var sut = new MovieRepository(context);

            //act
            var result = await sut.GetAllMoviesAsync();

            // assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, m => m.Title == "Inception" && m.ReleaseYear == 2010);
            var singleFilm = result.First(m => m.Title == "The Dark Knight");
            Assert.Equal(2, singleFilm.Id);
            Assert.NotNull(singleFilm.Studio);
            Assert.Equal(1, singleFilm.Studio.Id);
        }

        [Fact]
        public async Task AddMovieAsync_ShouldAddMovie()
        {
            var token = //Test.Current.CancellationToken; - this is what we would write in XUNIT V3
                new CancellationToken(); // todo
            // arrange
            var context = CreateContext();
            var country = new Country { Id = 1, Name = "USA" };
            var studio = new Studio { Id = 1, Name = "Warner Bros", Country = country };
            context.Countries.Add(country);
            context.Studios.Add(studio);
            await context.SaveChangesAsync(token);
            var sut = new MovieRepository(context);
            var newMovie = new Movie { Title = "Interstellar", ReleaseYear = 2014, StudioId = studio.Id };
            // act
            await sut.AddMovieAsync(newMovie);
            await context.SaveChangesAsync(token); // Save changes to the in-memory database
            // assert
            var addedMovie = await context.Movies.FirstOrDefaultAsync(m => m.Title == "Interstellar");
            Assert.NotNull(addedMovie);
            Assert.Equal(2014, addedMovie.ReleaseYear);
            Assert.Equal(studio.Id, addedMovie.StudioId);

        }
    }
}
