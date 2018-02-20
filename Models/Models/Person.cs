using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public bool PreviouslyOrdered { get; set; }
        public virtual ICollection<Colour> Colours { get; set; }
    }
}
