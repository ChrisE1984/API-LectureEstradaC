using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    //the repository is the only layer that talks to the database
    // it uses AppDbContext (EF Core) to read and save movie entities
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        //DI: we never write a "new AppDbContext()" ourselves
        //ASP.NET Core sees this constructor, asks for one and passes it for us
        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public List<Movie> GetAll()
        {
            // we are going into our DB and returning all movies
            return _db.Movies.ToList();
        }

        public Movie? GetById(int id)
        {
            //Find looks up a row by it's primary id key
            return _db.Movies.Find(id);
        }

        public Movie Add(Movie movie)
        {
            //add only marks the movie as new, doesn't add to the db
            _db.Movies.Add(movie);
            //SaveChanges() sends INSERT to the database. after this the movie row is filled in.
            _db.SaveChanges();

            return movie;
        }

        public void Update(Movie movie)
        {
            // we mark the movie as changed and save those changes to the DB
            _db.Movies.Update(movie);

            _db.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            //we mark teh movie for removal and then save the changes
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
    }
}