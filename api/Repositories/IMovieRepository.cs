using api.Models;

namespace api.Repositories
{
    //the repository interface: the list of database jobs for movies.
    public interface IMovieRepository
    {
        //List<Movie> GetAll();
        //Task<T> means a "t" will be ready later once the DB answer
        //can add Async to the end but is not required or a function, just updating the name it does nothing
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        // returns one movie or null if no movie has that id (why we use the "?")
        Task<Movie> AddAsync(Movie movie);
        //can use Task with no <> is the same as void, no value comes back but still awaits
        Task UpdateAsync(Movie movie);

        Task DeleteAsync(Movie movie);
    }
}