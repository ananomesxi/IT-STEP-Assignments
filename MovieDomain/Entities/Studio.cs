using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieDomain.Entities
{
    public class Studio
    {  
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country Country { get; set; } = new Country();
        public StudioDetails StudioDetails { get; set; } = new StudioDetails();
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
