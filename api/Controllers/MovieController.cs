
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

        [HttpGet]
        public ActionResult<List<MovieResponseDTO>> GetAll()
        {
            return Ok(_services.GetAll());
        }
        //get api/movie/getbyid/(id) 
        //return 200 with the movie or 400 if there is no movie
        [HttpGet("GetByID/{id}")]
        public ActionResult<MovieResponseDTO> GetById(int id)
        {
            MovieResponseDTO? movie = _services.GetByID(id);

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
        public ActionResult<MovieResponseDTO> AddMovie([FromBody] CreateMovieDTO dto)
        {
            MovieResponseDTO movie = _services.Create(dto);

            return CreatedAtAction (nameof (GetById), new {id = movie.Id}, movie);
        }

        [HttpPut("Update/{id}")]
        public ActionResult<MovieResponseDTO> Update(int id, [FromBody] UpdateMovieDTO dto)
        {
            MovieResponseDTO? movie = _services.Update(id,dto);

            if(movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
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