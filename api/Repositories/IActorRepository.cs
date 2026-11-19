
namespace api.Repositories
{
    public interface IActorRepository
    {
        Task <List<Actor>> GetAllAsync();
        Task <Actor?> GetByIdAsync(int id);
        // returns one movie or null if no movie has that id (why we use the "?")
        Task <Actor> AddAsync(Actor actor);

        Task UpdateAsync(Actor actor);

        Task DeleteAsync(Actor actor);
    }
}