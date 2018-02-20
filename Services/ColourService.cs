using AutoMapper;
using DataAccess.cs;
using Models.Models;
using Models.ViewModels;
using Services.cs.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.cs
{
    public class ColourService : IColourService
    {
        public ITechTestContext Context { get; }

        public ColourService(ITechTestContext context)
        {
            Context = context;
        }

        public IEnumerable<ColourViewModel> GetColours()
        {
            return Context.Colour.Where(x => x.isEnabled).Select(Mapper.Map<Colour,ColourViewModel>).ToList();
        }
    }
}
