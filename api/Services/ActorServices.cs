
using api.DTOs;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class ActorServices : IActorServices
    {
        private readonly IActorRepository _repository;
        public ActorServices (IActorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ActorResponseDTO> CreateAsync(CreateActorDTO dto)
        {
            Actor actor = new Actor();
            actor.Name = dto.Name;
            actor.BirthYear = dto.BirthYear;
            actor.Country = dto.Country;

            Actor saved = await _repository.AddAsync(actor);

            return ToDto(saved);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Actor? actor = await _repository.GetByIdAsync(id);
            if(actor is null)
            {
                return false;
            }
            await _repository.DeleteAsync(actor);
            return true;
        }

        public async Task<List<ActorResponseDTO>> GetAllAsync()
        {
            List<Actor> actors = await _repository.GetAllAsync();
            return actors.Select(ToDto).ToList();
        }

        public async Task<ActorResponseDTO?> GetByIdAsync(int id)
        {
            Actor? actor = await _repository.GetByIdAsync(id);
            if(actor is null)
            {
                return null;
            }

            return ToDto(actor);
        }

        public async Task<ActorResponseDTO?> UpdateAsync(int id, UpdateActorDTO dto)
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

            await _repository.UpdateAsync(actor);
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