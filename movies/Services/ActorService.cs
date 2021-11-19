using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movies.Data;
using movies.Entities;

namespace movies.Services
{
    public class ActorService : IActorService
    {
        private readonly ILogger<ActorService> _logger;
        private readonly MoviesDbContext _ctx;

        public ActorService(ILogger<ActorService> logger, MoviesDbContext ctx)
        {
            _logger = logger;
            _ctx  = ctx;
        }
        public async Task<(bool IsSuccess, Exception Exception, Actor Actor)> CreateAsync(Actor actor)
        {
            try
            {
                await _ctx.AddAsync(actor);
                await _ctx.SaveChangesAsync();

                return (true, null, actor);
            }
            catch (Exception e)
            {
                return (false, new Exception($"Error with database while adding new actor. {e}"), null);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            var actor = await GetAsync(id);

            if(actor == default(Actor))
            {
                return (false, new Exception("No matching actor to delete with the given id."));
            }

            try
            {
                 _ctx.Actors.Remove(actor);
                 await _ctx.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, new Exception($"Error with database while deleting actor. {e}"));
            }
        }

        public Task<bool> ExistsAsync(Guid id)
            => _ctx.Actors.AnyAsync(a => a.Id == id);

        public Task<List<Actor>> GetAllAsync()
            => _ctx.Actors.ToListAsync();

        public Task<List<Actor>> GetAllAsync(string fullname)
            => _ctx.Actors
                .AsNoTracking()
                .Where(a => a.Fullname == fullname)
                .ToListAsync();

        public Task<Actor> GetAsync(Guid id)
            => _ctx.Actors.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<(bool IsSuccess, Exception Exception)> UpdateAsync(Actor actor)
        {
            if(!await ExistsAsync(actor.Id))
            {
                return(false, new Exception("No matching actor to update."));
            }
            try
            {
                _ctx.Actors.Update(actor);
                await _ctx.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return(false, new Exception($"Error with database while updating actor. {e}"));
            }
        }
    }
}