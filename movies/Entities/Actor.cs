using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movies.Entities
{
    public class Actor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }

        [Required]
        public DateTimeOffset Birthdate { get; set; }

        public ICollection<Movie> Movies { get; set; }
        
        public Actor(string fullname, DateTimeOffset birthdate)
        {
            this.Id = Guid.NewGuid();
            this.Fullname = fullname;
            this.Birthdate = birthdate;
        }
    }

}

