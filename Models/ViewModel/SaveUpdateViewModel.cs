using System.Collections.Generic;

namespace Models.ViewModels
{
    public class SaveUpdateViewModel
    {
        public PersonViewModel Person { get; set; }
        public List<int> ColourIds { get; set; }
    }
}