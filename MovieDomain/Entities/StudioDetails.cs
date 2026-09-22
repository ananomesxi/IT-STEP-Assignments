using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieDomain.Entities
{
    public class StudioDetails
    {
        public int Id { get; set; }
        [Required]
        public string LicenseNumber { get; set; } = string.Empty;
        public int StudioId { get; set; }
        public Studio Studio { get; set; }

    }
}
