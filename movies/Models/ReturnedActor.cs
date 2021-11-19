using System;
using System.Collections.Generic;
using movies.Entities;

namespace movies.Models
{
    public class ReturnedActor
    {
        public string Fullname { get; set; }

        public DateTimeOffset Birthdate { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}