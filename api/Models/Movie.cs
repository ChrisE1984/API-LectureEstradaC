//the Movie entity is going to be a row in our table, each object is a column
// adding ": BaseEntity" allows us to use the objects int the BaseEntity.cs
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;

namespace api.Models
{
    public class Movie : BaseEntity
    {
        public string Title {get;set;} = string.Empty;
        public string Director {get;set;} = string.Empty;
        public int ReleaseYear {get;set;} 
        public int Rating {get;set;}
    }
}