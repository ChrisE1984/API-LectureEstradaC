//DTOs are JSON shapes that the client sees. The Movie entity stays inside the API

// no createdat or updatedat, the client only gets the fields we choose to share
namespace api.DTOs
{
    public class MovieResponseDTO
    {
        public int Id {get;set;}
        public string Title {get;set;} = string.Empty;
        public string Director {get;set;} = string.Empty;
        public int ReleaseYear {get;set;}
        public int Rating {get;set;}
    }
}