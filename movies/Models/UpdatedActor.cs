using System;
using System.ComponentModel.DataAnnotations;

namespace movies.Models
{
    public class UpdatedActor
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        public DateTimeOffset Birthdate { get; set; }
    }
}