using DataAccess.cs;
using Models.Models;
using System.Data.Entity;

namespace TechTest.Models
{
    public class TechTestContext : DbContext, ITechTestContext
    {    
        public TechTestContext() : base("name=TechTestContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Colour> Colour { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(t => t.Colours)
                .WithMany(t => t.Person)
                .Map(m =>
                {
                    m.ToTable("FavouriteColours");
                    m.MapLeftKey("PersonId");
                    m.MapRightKey("ColourId");
                });     

            base.OnModelCreating(modelBuilder);
        }
    }
}
