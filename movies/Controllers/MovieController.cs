using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies.Mappers;
using movies.Models;
using movies.Services;
using Newtonsoft.Json;

namespace movies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;

        public MovieController(IMovieService movieService, IActorService actorService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _actorService = actorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]NewMovie movie)
        {
            if(movie.ActorIds.Count() < 1 || movie.GenreIds.Count() < 1)
            {
                return BadRequest("Actors and Genres are required.");
            }

            if(!movie.GenreIds.All(id => _genreService.ExistsAsync(id).Result))
            {
                return BadRequest("Genre does not exist");
            }

            if(!movie.ActorIds.All(id => _actorService.ExistsAsync(id).Result))
            {
                return BadRequest("Actor does not exist");
            }

            var genres = movie.GenreIds.Select(id => _genreService.GetAsync(id).Result);
            var actors = movie.ActorIds.Select(id => _actorService.GetAsync(id).Result);

            var result = await _movieService.CreateAsync(movie.ToEntity(actors, genres));

            if(result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(result.Exception.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = new List<ReturnedMovie>();
            var movies = await _movieService.GetAllAsync();
            foreach (var movie in movies)
            {
                result.Add(movie.ToReturnedModel());
            }
            var json = JsonConvert.SerializeObject(
                result, 
                Formatting.Indented,
                new JsonSerializerSettings 
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
        }
    }
}