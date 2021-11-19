using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movies.Mappers;
using movies.Models;
using movies.Services;
using System.Linq;
using Newtonsoft.Json;

namespace movies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ILogger<ActorController> _logger;
        private readonly IActorService _actorService;
        private readonly IMovieService _movieService;

        public ActorController(ILogger<ActorController> logger, IActorService actorService, IMovieService movieService)
        {
            _logger = logger;
            _actorService = actorService;
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]NewActor actor)
        {
            var movieList = await _movieService.GetAllAsync();
            var movies = new List<Entities.Movie>();
            foreach (var movie in movieList)
            {
                if(actor.MovieIds.Contains(movie.Id))
                {
                    movies.Add(movie);
                }
            }
            var result = await _actorService.CreateAsync(actor.ToEntity(movies));
            if(result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(result.Exception.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var actors = await _actorService.GetAllAsync();
            var returnedActors = new List<Models.ReturnedActor> ();
            foreach (var actor in actors)
            {
                returnedActors.Add(actor.ToReturnedModel());
            }
            var json = JsonConvert.SerializeObject(
                returnedActors, 
                Formatting.Indented,
                new JsonSerializerSettings 
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Ok(json);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute]Guid id)
        {
            if(!await _actorService.ExistsAsync(id))
            {
                return NotFound("Actor with given id is not found.");
            }
            var actor = await _actorService.GetAsync(id);
            var returnedActor = actor.ToReturnedModel();
            var json = JsonConvert.SerializeObject(
                        returnedActor, 
                        Formatting.Indented,
                        new JsonSerializerSettings 
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(returnedActor);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
        {
            if(!await _actorService.ExistsAsync(id))
            {
                return NotFound();
            }

            var result = await _actorService.DeleteAsync(id);
            if(result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(result.Exception.Message);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id, [FromBody]UpdatedActor actor)
        {
            var actorEntity = await _actorService.GetAsync(id);
            var movies = actorEntity.Movies.ToList();
            if(!await _actorService.ExistsAsync(id))
            {
                return NotFound("Actor with given id is not found.");
            }

            var result = await _actorService.UpdateAsync(actor.ToEntity(id, movies));

            if(result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Exception.Message);
            }
        }
    }
}