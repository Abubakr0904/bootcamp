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
    public class MovieService : IMovieService
    {
        private readonly ILogger<MovieService> _logger;
        private readonly MoviesDbContext _ctx;

        public MovieService(ILogger<MovieService> logger, MoviesDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }
        public async Task<(bool IsSuccess, Exception Exception, Movie Movie)> CreateAsync(Movie movie)
        {
            try
            {
                await _ctx.Movies.AddAsync(movie);
                await _ctx.SaveChangesAsync();

                return (true, null, movie);
            }
            catch (Exception e)
            {
                return (false, new Exception($"Error with database while adding new movie. {e}"), null);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            var movie = await GetAsync(id);
            if(movie == default(Movie))
            {
                return (false, new Exception("No matching movie to delete with the given id."));
            }

            try
            {
                _ctx.Movies.Remove(movie);
                await _ctx.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, new Exception($"Error with database while deleting movie. {e}"));
            }
        }

        public Task<bool> ExistsAsync(Guid id)
            => _ctx.Movies.AnyAsync(m => m.Id == id);

        public Task<List<Movie>> GetAllAsync()
            => _ctx.Movies
                .AsNoTracking()
                .Include(m => m.Actors)
                .Include(m => m.Genres)
                .ToListAsync();

        public Task<Movie> GetAsync(Guid id)
            => _ctx.Movies.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<(bool IsSuccess, Exception Exception)> UpdateAsync(Movie movie)
        {
            if(!await ExistsAsync(movie.Id))
            {
                return(false, new Exception("No matching movie to update."));
            }
            try
            {
                _ctx.Movies.Update(movie);
                await _ctx.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return(false, new Exception($"Error with database while updating movie. {e}"));
            }
        }

        public Task<List<Movie>> GetAllAsync(string title)
            => _ctx.Movies
                .AsNoTracking()
                .Where(m => m.Title == title)
                .Include(m => m.Actors)
                .Include(m => m.Genres)
                .ToListAsync();
    }
}