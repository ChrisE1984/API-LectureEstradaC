using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories
{
    public interface IActorRepository
    {
        List<Actor> GetAll();
        Actor? GetById(int id);
        // returns one movie or null if no movie has that id (why we use the "?")
        Actor Add(Actor actor);

        void Update(Actor actor);

        void Delete(Actor actor);
    }
}