using MovieApplication.Interfaces;
using MovieDomain.DTOs;
using MovieDomain.Entities;
using MovieDomain.Intefraces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Implementations
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActorService(IActorRepository actorRepository, IUnitOfWork unitOfWork)
        {
            _actorRepository = actorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<ActorDTO>> GetAllActorsAsync()
        {
            var actors = await _actorRepository.GetAllActorsAsync();

            var actorDtos = actors.Select(a => new ActorDTO
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                MovieTitles = a.Movies.Select(m => m.Title).ToList()
            }).ToList();

            return actorDtos;
        }

        public async Task<ActorDTO> GetActorByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be positive");
            }
            var actor = await _actorRepository.GetActorByIdAsync(id);

            if (actor == null)
            {
                throw new KeyNotFoundException($"Actor with ID {id} not found.");
            }

            ActorDTO actorDto = new ActorDTO
            {
                Id = actor.Id,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                MovieTitles = actor.Movies.Select(m => m.Title).ToList()
            };
            return actorDto;
        }

        public async Task AddActorAsync(CreateActorDTO createActorDto)
        {
            if (createActorDto == null)
            {
                throw new ArgumentNullException(nameof(createActorDto));
            }
            var actor = new Actor
            { 
                FirstName = createActorDto.FirstName,
                LastName = createActorDto.LastName
            };
            await _actorRepository.AddActorAsync(actor);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateActorAsync (int id, UpdateActorDTO updateActorDto)
        {
            if (updateActorDto == null)
            {
                throw new ArgumentNullException(nameof(updateActorDto));
            }
            var actor = new Actor
            {
                FirstName = updateActorDto.FirstName,
                LastName = updateActorDto.LastName
            };
            await _actorRepository.UpdateActorAsync(id, actor);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task DeleteActorAsync (int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be positive.");
            }
            await _actorRepository.DeleteActorAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateActorMovieAsync(int actorId, UpdateActorMovieDTO updateActorMovieDto)
        {
            await _actorRepository.UpdateActorMovieAsync(actorId, updateActorMovieDto.MovieIds);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
