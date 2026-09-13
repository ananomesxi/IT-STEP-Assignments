using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieDomain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int StudioId { get; set; }
        public Studio Studio { get; set; } = new Studio();
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
    }
}
