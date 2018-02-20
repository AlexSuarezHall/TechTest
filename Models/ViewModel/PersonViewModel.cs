using System;
using System.Collections.Generic;

namespace Models.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            this.Colours = new List<ColourViewModel>();
            this.ColourIds = new List<int>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public bool PreviouslyOrdered { get; set; }
        public List<int> ColourIds { get; set; }
        public virtual List<ColourViewModel> Colours { get; set; }
    }
}
