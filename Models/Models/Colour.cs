using System.Collections.Generic;

namespace Models.Models
{
    public class Colour
    {
        public int ColourId { get; set; }
        public string Name { get; set; }
        public bool isEnabled { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
