using MovieDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Interfaces
{
    public interface IActorService
    {
        Task<ICollection<ActorDTO>> GetAllActorsAsync();
        Task<ActorDTO> GetActorByIdAsync(int id);
        Task AddActorAsync(CreateActorDTO createActorDto);
        Task UpdateActorAsync(int id, UpdateActorDTO updateActorDto);
        Task DeleteActorAsync(int id);
        Task UpdateActorMovieAsync(int actorId, UpdateActorMovieDTO updateActorMovieDto);

    }
}
