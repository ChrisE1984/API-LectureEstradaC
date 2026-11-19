using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
      private readonly IActorServices _services;

      public ActorController (IActorServices services)
        {
            _services = services;
        } 

        [HttpGet]
        public ActionResult<List<ActorResponseDTO>> GetAll()
        {
            return Ok(_services.GetAll());
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<ActorResponseDTO> GetByID (int id)
        {
            ActorResponseDTO? actor = _services.GetById(id);
            if (actor is null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpPost("AddActor")]
        public ActionResult<ActorResponseDTO> Create (int id, [FromBody] CreateActorDTO dto)
        {
            ActorResponseDTO actor = _services.Create(dto);

            return CreatedAtAction (nameof (GetByID), new {id = actor.Id}, actor);
        }

       [HttpPut("Update/{id}")]
       public ActionResult<ActorResponseDTO> Update (int id, [FromBody] UpdateActorDTO dto)
        {
            ActorResponseDTO? actor = _services.Update(id,dto);

            if(actor is null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        [HttpDelete("Delete/{id}")]

        public IActionResult Delete (int id)
        {
            bool isDeleted = _services.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}