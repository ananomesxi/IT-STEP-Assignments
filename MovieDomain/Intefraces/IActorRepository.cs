using MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Intefraces
{
    public interface IActorRepository
    {
        Task AddActorAsync(Actor actor);
        Task<ICollection<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
        Task UpdateActorAsync(int id, Actor actor);
        Task DeleteActorAsync(int id);
        Task UpdateActorMovieAsync(int actorId, ICollection<int> movieIds);

    }
}
