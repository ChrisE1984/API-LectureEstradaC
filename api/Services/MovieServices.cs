//Our Services Layer is the middleman between our Controller and our Repository
// It Maps out DTOs to Entities and vise versa. This is where our rules live.
using System.Diagnostics;
using api.DTOs;
using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _repository;
        //DI: In our Program.cs says IMovieRepository means MovieRepository    
        public MovieServices (IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieResponseDTO> CreateAsync(CreateMovieDTO dto)
        {
            Movie movie = new Movie();
            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Rating = dto.Rating;
            movie.ReleaseYear = dto.ReleaseYear;

            Movie saved = await _repository.AddAsync(movie);
            //Sending back the same movie with an ID
            return ToDto(saved);
        }

        public async Task<List<MovieResponseDTO>> GetAllAsync()
        {
            List<Movie> movies = await _repository.GetAllAsync();

            //Turning every element in this list into a dto
            return movies.Select(ToDto).ToList();
        }

        public async Task<MovieResponseDTO?> GetByIDAsync(int id)
        {
           Movie? movie = await _repository.GetByIdAsync(id);
            //if there is no movie, pass null up to the controller.
           if(movie is null)
            {
                return null;
            } 

            return ToDto(movie);
        }


        public async Task<MovieResponseDTO?> UpdateAsync(int id, UpdateMovieDTO dto)
        {
            //we must first load the movie from the database
            Movie? movie = await _repository.GetByIdAsync(id);

            if(movie is null)
            {
                return null;
            }

            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Rating = dto.Rating;
            movie.ReleaseYear = dto.ReleaseYear;
            // records when this move was last changed
            movie.UpdatedAt= DateTime.UtcNow;

            await _repository.UpdateAsync(movie);
            return ToDto(movie);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            Movie? movie = await _repository.GetByIdAsync(id);
            if(movie is null)
            {
                return false;
            }

            await _repository.DeleteAsync(movie);
            return true;


        }
        // We will create a helper function that maps our DTOs
        // private because it doesn't need to be accessed outside of our class
        //static because it doesn't have access to instance data
         private static MovieResponseDTO ToDto(Movie movie)
        {
            return new MovieResponseDTO
            {
                Id= movie.Id,
                Title= movie.Title,
                Director=movie.Director,
                Rating=movie.Rating,
                ReleaseYear=movie.ReleaseYear
            };
        }
    }
}