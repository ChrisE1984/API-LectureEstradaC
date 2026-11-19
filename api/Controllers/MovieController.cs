
using api.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

//our Controllers take in HTTP requests and sends back HTTP responses
//it only talks to our services, never to our DB
//

namespace api.Controllers
{
    [ApiController]// This line turns on our API features like automatic 400 status code
    [Route("api/[controller]")]// makes every url endpoint start with api/movie
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _services;

        public MovieController(IMovieServices services)
        {
            _services = services;
        }

        //async Task<...>: the action awaits the service, so it returns a task
        //ASP.NET Core awaits the Task for us, then sends the response
        [HttpGet]
        public async Task<ActionResult<List<MovieResponseDTO>>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }
        //get api/movie/getbyid/(id) 
        //return 200 with the movie or 400 if there is no movie
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<MovieResponseDTO>> GetById(int id)
        {
            MovieResponseDTO? movie = await _services.GetByIDAsync(id);

            if(movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
        //pot is api/movie/addmovie
        //JSON body becomes our CreateMovieDTO
        //we want 201 Created with the new movie
        [HttpPost("AddMovie")]
        public async Task<ActionResult<MovieResponseDTO>> AddMovie([FromBody] CreateMovieDTO dto)
        {
            MovieResponseDTO movie = await _services.CreateAsync(dto);

            return CreatedAtAction (nameof (GetById), new {id = movie.Id}, movie);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<MovieResponseDTO>> Update(int id, [FromBody] UpdateMovieDTO dto)
        {
            MovieResponseDTO? movie = await _services.UpdateAsync(id,dto);

            if(movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete (int id)
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