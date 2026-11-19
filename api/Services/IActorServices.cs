using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services
{
    public interface IActorServices
    {
        Task<List<ActorResponseDTO>> GetAllAsync();
        Task<ActorResponseDTO?> GetByIdAsync(int id);
        Task<ActorResponseDTO> CreateAsync (CreateActorDTO dto);
        Task<ActorResponseDTO?> UpdateAsync (int id, UpdateActorDTO dto);
        Task<bool> DeleteAsync (int id);
    }
}