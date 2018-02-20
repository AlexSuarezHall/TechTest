using Models.Models;
using System.Data.Entity;

namespace DataAccess.cs
{
    public interface ITechTestContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Colour> Colour { get; set; }
        int SaveChanges();
    }
}
