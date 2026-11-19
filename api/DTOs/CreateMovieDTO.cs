// this is what the client sends to create a movie, no id needed

namespace api.DTOs
{
    public class CreateMovieDTO
    {
        public string Title {get;set;} = string.Empty;
        public string Director {get;set;} = string.Empty;
        public int ReleaseYear {get;set;}
        public int Rating {get;set;}
    }
}