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
        
        public async Task<List<Movie>> GetAllAsync()
        {
            // we are going into our DB and returning all movies
            return await _db.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            //Find looks up a row by it's primary id key
            return await _db.Movies.FindAsync(id);
        }

        public async Task <Movie> AddAsync(Movie movie)
        {
            //add only marks the movie as new, doesn't add to the db
            _db.Movies.Add(movie);
            //SaveChanges() sends INSERT to the database. after this the movie row is filled in.
            await _db.SaveChangesAsync();

            return movie;
        }

        public async Task UpdateAsync(Movie movie)
        {
            // we mark the movie as changed and save those changes to the DB
            _db.Movies.Update(movie);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            //we mark teh movie for removal and then save the changes
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
        }
    }
}