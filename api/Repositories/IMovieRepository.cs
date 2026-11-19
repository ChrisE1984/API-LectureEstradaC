using api.Models;

namespace api.Repositories
{
    //the repository interface: the list of database jobs for movies.
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        // returns one movie or null if no movie has that id (why we use the "?")
        Movie Add(Movie movie);

        void Update(Movie movie);

        void Delete(Movie movie);
    }
}