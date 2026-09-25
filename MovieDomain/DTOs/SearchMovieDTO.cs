using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieDomain.DTOs
{
    public class SearchMovieDTO
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string StudioName { get; set; } = string.Empty;
        public string CountryName { get; set; }
        public int ActorCount { get; set; }

        public override string? ToString()
        {
            return $"Title: {Title}, Release Year: {ReleaseYear}, Studio: {StudioName}, Country: {CountryName}, Actor Count: {ActorCount}";
        }
    }
}
