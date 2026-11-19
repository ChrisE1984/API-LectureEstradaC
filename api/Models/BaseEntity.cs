//every table will have this base entity of columns
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace api.Models
{
    public class BaseEntity
    {
        //EF Core treats property named ID as primary key
        //The DB fills it in for us when a new row is saved/created
        public int Id {get; set; }
        //DateTime.UtcNow is the current in UTS, so every server aggress on the time
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get; set;} = DateTime.UtcNow;
    }
}