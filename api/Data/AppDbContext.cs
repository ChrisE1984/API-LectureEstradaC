using api.Models;
using Microsoft.EntityFrameworkCore;
namespace api.Data
{
    //The DbContext is EFcore's connection to the database
    //Our repositories use it to read and save rows (Data to our Database)
public class AppDbContext : DbContext
{
        //the options (which database to use and it's connection string) come from
        //Program.cs dependency injection and we just hand them to the DbContext Base class
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    //each DbSet is one table. this one becomes the movies table.
    public DbSet<Movie> Movies {get; set;}
    public DbSet<Actor> Actors {get; set;}
}
}