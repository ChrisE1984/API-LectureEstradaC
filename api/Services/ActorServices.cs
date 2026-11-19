
namespace api.Services
{
    public class ActorServices : IActorServices
    {
        private readonly IActorRepository _repository;
        public ActorServices (IActorRepository repository)
        {
            _repository = repository;
        }
        public ActorResponseDTO Create(CreateActorDTO dto)
        {
            Actor actor = new Actor();
            actor.Name = dto.Name;
            actor.BirthYear = dto.BirthYear;
            actor.Country = dto.Country;

            Actor saved = _repository.Add(actor);

            return ToDto(saved);
        }

        public async Task<bool> Delete(int id)
        {
            Actor? actor = await _repository.GetByIdAsync(id);
            if(actor is null)
            {
                return false;
            }
            _repository.Delete(actor);
            return true;
        }

        public async Task<List<ActorResponseDTO>> GetAll()
        {
            List<Actor> actors = await _repository.GetAll();
            return actors.Select(ToDto).ToList();
        }

        public async Task<ActorResponseDTO?> GetById(int id)
        {
            Actor? actor = await _repository.GetByIdAsync(id);
            if(actor is null)
            {
                return null;
            }

            return ToDto(actor);
        }

        public async Task<ActorResponseDTO?> Update(int id, UpdateActorDTO dto)
        {
            Actor? actor = await _repository.GetByIdAsync(id);
            if(actor is null)
            {
                return null;
            }

            actor.Name = dto.Name;
            actor.Country = dto.Country;
            actor.BirthYear = dto.BirthYear;
            actor.UpdatedAt = DateTime.UtcNow;

            _repository.Update(actor);
            return ToDto(actor);
        }
    
        private static ActorResponseDTO ToDto (Actor actor)
        {
            return new ActorResponseDTO
            {
                Id=actor.Id,
                Name=actor.Name,
                Country=actor.Country,
                BirthYear=actor.BirthYear
            };
        }
    
    }
    
}