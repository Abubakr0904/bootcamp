using System.Reflection.PortableExecutable;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace movies.Entities
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        [Range(0, 10)]
        public double Rating { get; set; }

        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Actor> Actors { get; set; }
        
        [Obsolete]
        public Movie() {  }

        public Movie(string title, string description, double rating, DateTimeOffset releaseDate, List<Actor> actors, List<Genre> genres)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Rating = rating;
            ReleaseDate = releaseDate;
            Actors = actors;
            Genres = genres;
        }
    }
}
