using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieDomain.DTOs
{
    public class CreateMovieDTO
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int StudioId { get; set; }
    }
}
