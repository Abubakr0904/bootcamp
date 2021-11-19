using System;
using System.Collections.Generic;
using movies.Entities;

namespace movies.Models
{
    public class ReturnedMovie
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Double Rating { get; set; }
        
        public DateTimeOffset ReleaseDate { get; set; }
        
        public ICollection<Genre> Genres { get; set; }

        public ICollection<Actor> Actors { get; set; }
    }
}