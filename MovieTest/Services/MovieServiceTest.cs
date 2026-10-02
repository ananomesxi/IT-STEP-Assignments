using Moq;
using MovieApplication.Implementations;
using MovieDomain.DTOs;
using MovieDomain.Entities;
using MovieDomain.Intefraces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTest.Services
{
    public class MovieServiceTest
    {
        [Fact]
        public async Task AddMovieAsync_ValidMovie_CallsRepo()
        {
            // arrange
            var repoMock = new Mock<IMovieRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            repoMock.Setup(r => r.AddMovieAsync(It.IsAny<Movie>())).Returns(Task.CompletedTask);

            var movieService = new MovieService(repoMock.Object, unitOfWorkMock.Object);

            var dto = new CreateMovieDTO() { Title = "Test Movie", ReleaseYear = 2020, StudioId = 1 };

            // act
            await movieService.AddMovieAsync(dto);

            // assert
            repoMock.Verify(repo => repo.AddMovieAsync(It.IsAny<Movie>()), Times.Once);
        }

        [Fact]
        public async Task AddMovieAsync_NotValidMovie_CallsRepoZero()
        {
            // arrange
            var repoMock = new Mock<IMovieRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            repoMock.Setup(r => r.AddMovieAsync(It.IsAny<Movie>())).Returns(Task.CompletedTask);

            var movieService = new MovieService(repoMock.Object, unitOfWorkMock.Object);

            var dto = new CreateMovieDTO() { Title = "", ReleaseYear = 2020, StudioId = 1 };

            // act
            //await movieService.AddMovieAsync(dto);
            var res = await Assert.ThrowsAsync<ArgumentException>(() => movieService.AddMovieAsync(dto));

            // assert

            Assert.NotNull(res);

            //repoMock.Verify(repo => repo.AddMovieAsync(It.IsAny<Movie>()), Times.Never);


        }
    }
}
