// this is what the client sends to change a movie
namespace api.DTOs
{
    public class UpdateMovieDTO
    {
        public string Title {get;set;} = string.Empty;
        public string Director {get;set;} = string.Empty;
        public int ReleaseYear {get;set;}
        public int Rating {get;set;}
    }
}