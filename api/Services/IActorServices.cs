using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services
{
    public interface IActorServices
    {
        List<ActorResponseDTO> GetAll();
        ActorResponseDTO? GetById(int id);
        ActorResponseDTO Create (CreateActorDTO dto);
        ActorResponseDTO? Update (int id, UpdateActorDTO dto);
        bool Delete (int id);
    }
}