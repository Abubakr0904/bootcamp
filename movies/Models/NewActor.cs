using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace movies.Models
{
    public class NewActor
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        public DateTimeOffset Birthdate { get; set; }

        public List<Guid> MovieIds { get; set; }
    }
}