
using api.Data;
using api.Models;

namespace api.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _db;

        //DI: we never write a "new AppDbContext()" ourselves
        //ASP.NET Core sees this constructor, asks for one and passes it for us
        public ActorRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Actor Add(Actor actor)
        {
            _db.Actors.Add(actor);
            //SaveChanges() sends INSERT to the database. after this the movie row is filled in.
            await _db.SaveChangesAsync();

            return actor;
        }

        public async Task Delete(Actor actor)
        {
            _db.Actors.Remove(actor);
           await _db.SaveChangesAsync();
        }

        public async Task<List<Actor>> GetAll()
        {
            return await _db.Actors.ToListAsync();
        }

        public async Task<Actor?> GetById(int id)
        {
            return await _db.Actors.FindAsync(id);
        }

        public async Task Update(Actor actor)
        {
            _db.Actors.Update(actor);
            await _db.SaveChangesAsync();
        }
    }
}