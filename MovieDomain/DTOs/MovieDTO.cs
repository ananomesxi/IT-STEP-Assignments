using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieDomain.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string StudioName { get; set; } = string.Empty;

        public override string? ToString()
        {
            return $"Id = {Id}, Title = {Title}, ReleaseYear = {ReleaseYear}, StudioName = {StudioName}";
        } 
    }
}
