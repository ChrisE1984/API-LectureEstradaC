
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
        public Actor Add(Actor actor)
        {
            _db.Actors.Add(actor);
            //SaveChanges() sends INSERT to the database. after this the movie row is filled in.
            _db.SaveChanges();

            return actor;
        }

        public void Delete(Actor actor)
        {
            _db.Actors.Remove(actor);
            _db.SaveChanges();
        }

        public List<Actor> GetAll()
        {
            return _db.Actors.ToList();
        }

        public Actor? GetById(int id)
        {
            return _db.Actors.Find(id);
        }

        public void Update(Actor actor)
        {
            _db.Actors.Update(actor);
            _db.SaveChanges();
        }
    }
}