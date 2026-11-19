
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
        public async ActionResult<List<ActorResponseDTO>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async ActionResult<ActorResponseDTO> GetByID (int id)
        {
            ActorResponseDTO? actor = await _services.GetByIdAsync(id);
            if (actor is null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpPost("AddActor")]
        public async ActionResult<ActorResponseDTO> Create (int id, [FromBody] CreateActorDTO dto)
        {
            ActorResponseDTO actor = await _services.CreateAsync(dto);

            return CreatedAtAction (nameof (GetByID), new {id = actor.Id}, actor);
        }

       [HttpPut("Update/{id}")]
       public async ActionResult<ActorResponseDTO> Update (int id, [FromBody] UpdateActorDTO dto)
        {
            ActorResponseDTO? actor = await _services.UpdateAsync(id,dto);

            if(actor is null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        [HttpDelete("Delete/{id}")]

        public async IActionResult Delete (int id)
        {
            bool isDeleted = await _services.DeleteAsync(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}