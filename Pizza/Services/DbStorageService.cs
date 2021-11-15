using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pizza.Data;

namespace Pizza.Services
{
    public class DbStorageService : IStorageService
    {
        private readonly ILogger<DbStorageService> _logger;
        private readonly PizzaDbContext _context;

        public DbStorageService(ILogger<DbStorageService> logger, PizzaDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<(bool IsSuccess, Exception exception)> DeleteAsync(Guid id)
        {
            try
            {
                var pizza = _context.Pizzas.FirstOrDefault(p => p.Id == id);
                if(pizza is not default(Entities.Pizza))
                {
                    _context.Remove(pizza);
                    await _context.SaveChangesAsync();
                    
                    _logger.LogInformation($"Pizza entity with id {id} is removed successfully");
                    return (true, null);
                }          
                else
                {
                    _logger.LogInformation($"No entity with provided id {id} is found");
                    return (false, new Exception($"No entity with provided id {id} is found"));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error with database while deleting entity.");
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, Exception exception)> DeleteAsync(string shortName)
        {
            try
            {
                var pizza = _context.Pizzas.FirstOrDefault(p => p.ShortName == shortName);
                
                if(pizza is not default(Entities.Pizza))
                {
                    _context.Remove(pizza);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Pizza entity with short name {shortName} is removed successfully");
                    return (true, null);
                }          
                else
                {
                    _logger.LogInformation($"No entity with provided short name {shortName} is found.");
                    return (false, new Exception($"No entity with provided short name {shortName} is found."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error with database while deleting entity. Error: {e}");
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, List<Entities.Pizza>, Exception exception)> GetAllAsync()
        {
            try
            {
                var pizzas = await _context.Pizzas.AsNoTracking().ToListAsync();
                if(pizzas != null)
                    _logger.LogInformation("All existing entities in database are returned successfully");
                else
                    _logger.LogInformation($"No entities exist in database yet.");
                return (true, pizzas, null);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error with database while getting the existing entities. Error: {e}");
                return (false, null, e);
            }
        }

        public async Task<(bool IsSuccess, Entities.Pizza, Exception exception)> GetByIdAsync(Guid id)
        {
            try
            {
                var pizza = _context.Pizzas.AsNoTracking().FirstOrDefault(p => p.Id == id);
                if(pizza != default(Entities.Pizza))
                    _logger.LogInformation($"Entity with provided id {id} is returned successfully.");
                else
                    _logger.LogInformation($"No entity in the database with a provided id {id}");
                return (true, pizza, null);
            }
            catch (Exception e)
            {
                _logger.LogError("Error with database while getting the entity by id");
                return (false, null, e);
            }
        }

        public async Task<(bool IsSuccess, Exception exception)> InsertAsync(Entities.Pizza pizza)
        {
            if(!_context.Pizzas.Any(p => p.ShortName == pizza.ShortName))
            {
                try
                {
                        await _context.Pizzas.AddAsync(pizza);
                        await _context.SaveChangesAsync();
                        _logger.LogInformation("New entity is added successfully.");
                        return (true, null);
                }
                catch (InvalidOperationException e)
                {
                    _logger.LogInformation("Error with database while inserting a new entity");
                    return (false, e);
                }
            }
            else
            {
                return (false, new Exception("The entity with the same unique property already exists"));
            }
        }

        public async Task<(bool IsSuccess, Exception exception)> UpdateAsync(Entities.Pizza pizza)
        {
            try
            {
                if(_context.Pizzas.Any(p => p.Id == pizza.Id))
                {
                    _context.Pizzas.Update(pizza);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Entity is updated successfully.");
                    return (true, null);
                }
                else
                {
                    _logger.LogInformation($"No matching entity with the provided id {pizza.Id}");
                    return (false, new Exception($"No matching entity with the provided id {pizza.Id}"));
                }

                return(false, new Exception("Unexpected error while updating the entity."));
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error with database while updating the entity");
                return (false, e);
            }
        }
    }
}