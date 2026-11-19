//This services is a list of jobs that our Services must implement
//Our Services speak in DTO, so the Controller never touches the entity
using api.DTOs;
using api.Models;

namespace api.Services
{
    public interface IMovieServices
    {
        List<MovieResponseDTO> GetAll();
        MovieResponseDTO? GetByID(int id);
        MovieResponseDTO Create (CreateMovieDTO dto);
        MovieResponseDTO? Update (int id, UpdateMovieDTO dto);
        bool Delete(int id);

    }
}