namespace movies.Mappers
{
    public static class EntityModelMapper
    {
        public static Models.ReturnedMovie ToReturnedModel(this Entities.Movie movie)
            => new Models.ReturnedMovie()
                {
                    Title = movie.Title,
                    Description = movie.Description,
                    Rating = movie.Rating,
                    ReleaseDate = movie.ReleaseDate,
                    Genres = movie.Genres,
                    Actors = movie.Actors
                };
        
        public static Models.ReturnedActor ToReturnedModel(this Entities.Actor actor)
            => new Models.ReturnedActor()
                {
                    Fullname = actor.Fullname,
                    Birthdate = actor.Birthdate,
                    Movies = actor.Movies
                };
        
    }
}