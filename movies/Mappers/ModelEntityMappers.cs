using System;
using System.Collections.Generic;
using System.Linq;
using movies.Entities;

namespace movies.Mappers
{
    public static class ModelEntityMappers
    {
        public static Entities.Genre ToEntity(this Models.NewGenre genre)
            => new Entities.Genre(genre.Name);

        public static Entities.Actor ToEntity(this Models.NewActor actor, List<Movie> movies)
            => new Entities.Actor(actor.FullName, actor.Birthdate);

        public static Entities.Movie ToEntity(this Models.NewMovie movie, IEnumerable<Entities.Actor> actors, IEnumerable<Entities.Genre> genres)
            => new Entities.Movie(
                title: movie.Title,
                description: movie.Description,
                rating: movie.Rating,
                releaseDate: movie.ReleaseDate,
                actors: actors.ToList(),
                genres: genres.ToList()
            );
        
        public static Entities.Actor ToEntity(this Models.UpdatedActor  actor, Guid id, List<Movie> movies)
            => new Entities.Actor(actor.FullName, actor.Birthdate) {Id = id};
        
        
    }
}