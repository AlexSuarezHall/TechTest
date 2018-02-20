namespace TechTest.Migrations
{
    using global::Models.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.TechTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.TechTestContext context)
        {
            var red = new Colour { Name = "Red", isEnabled = true };
            var green = new Colour { Name = "Green", isEnabled = true };
            var blue = new Colour { Name = "Blue", isEnabled = true };

            context.Colour.AddOrUpdate(x => x.Name, red, green, blue);

            context.People.AddOrUpdate(x => x.LastName,
              new Person { FirstName = "Joe", LastName = "Bloggs", DOB = new DateTime(1992, 2, 05), Gender = "Male", PreviouslyOrdered = true, Colours = new List<Colour>() { red, green, blue } },
              new Person { FirstName = "Hello", LastName = "World", DOB = new DateTime(1968, 7, 26), Gender = "Female", PreviouslyOrdered = false, Colours = new List<Colour>() { red, blue } },
              new Person { FirstName = "Alex", LastName = "Suarez-Hall", DOB = new DateTime(1966, 8, 31), Gender = "Male", PreviouslyOrdered = true, Colours = new List<Colour>() {  green } }
            );

        }
    }
}
