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

        public MovieResponseDTO Create(CreateMovieDTO dto)
        {
            Movie movie = new Movie();
            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Rating = dto.Rating;
            movie.ReleaseYear = dto.ReleaseYear;

            Movie saved = _repository.Add(movie);
            //Sending back the same movie with an ID
            return ToDto(saved);
        }

        public List<MovieResponseDTO> GetAll()
        {
            List<Movie> movies = _repository.GetAll();

            //Turning every element in this list into a dto
            return movies.Select(ToDto).ToList();
        }

        public MovieResponseDTO? GetByID(int id)
        {
           Movie? movie = _repository.GetById(id);
            //if there is no movie, pass null up to the controller.
           if(movie is null)
            {
                return null;
            } 

            return ToDto(movie);
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

        public MovieResponseDTO? Update(int id, UpdateMovieDTO dto)
        {
            //we must first load the movie from the database
            Movie? movie = _repository.GetById(id);

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

            _repository.Update(movie);
            return ToDto(movie);

        }

        public bool Delete(int id)
        {
            Movie? movie = _repository.GetById(id);
            if(movie is null)
            {
                return false;
            }

            _repository.Delete(movie);
            return true;


        }
    }
}