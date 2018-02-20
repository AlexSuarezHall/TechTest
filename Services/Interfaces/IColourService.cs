using Models.ViewModels;
using System.Collections.Generic;

namespace Services.cs.Interfaces
{
    public interface IColourService
    {
        IEnumerable<ColourViewModel> GetColours();
    }
}
