//This services is a list of jobs that our Services must implement
//Our Services speak in DTO, so the Controller never touches the entity
using api.DTOs;
using api.Models;

namespace api.Services
{
    public interface IMovieServices
    {
        Task<List<MovieResponseDTO>> GetAllAsync();
        Task<MovieResponseDTO?> GetByIDAsync(int id);
        Task<MovieResponseDTO> CreateAsync(CreateMovieDTO dto);
        Task<MovieResponseDTO?> UpdateAsync(int id, UpdateMovieDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}