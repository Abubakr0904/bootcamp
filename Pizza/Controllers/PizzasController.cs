using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizza.Services;
using Pizza.Models;
using Pizza.Mappers;
using System;
using System.Collections.Generic;

namespace Pizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        private readonly ILogger<PizzasController> _logger;
        private readonly IStorageService _storage;

        public PizzasController(ILogger<PizzasController> logger, IStorageService storage)
        {
            _logger = logger;
            _storage = storage;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ActionName(nameof(CreateAsync))]
        public async Task<IActionResult> CreateAsync([FromBody]Models.Pizza pizza)
        {
            var entity = pizza.FromPizzaModelToPizzaEntity();
            var result = await _storage.InsertAsync(entity);
            if(result.IsSuccess)
            {
                _logger.LogInformation("Successfully created in CreateAsync Controller");
                return CreatedAtAction(nameof(CreateAsync), new {id = entity.Id}, entity);
            }
            else
            {
                _logger.LogInformation("Error in controller while creating a pizza entity.");
                return BadRequest(new {id = entity.Id, ErrorMessage = result.exception.Message});
            }
        }


        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetEntities()
        {
            var entities = await _storage.GetAllAsync();
            var entityList = new List<ReturnedPizza> ();
            if(entities.IsSuccess)
            {
                foreach(var entity in entities.Item2)
                {
                    var model = entity.FromPizzaEntityToModel();
                    entityList.Add(model);
                }
                return Ok(entityList);
            }
            else
            {
                return BadRequest(new {ErrorMessage = entities.exception.Message});
            }
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var entity = await _storage.GetByIdAsync(id);
            if(entity.IsSuccess)
            {
                if(entity.Item2 != null)
                {
                    return Ok(entity.Item2.FromPizzaEntityToModel());
                }
                else
                {
                    return NotFound("No entity in the database matching the query.");
                }
            }
            else
            {
                return BadRequest("No entity in the database matching the query.");
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        // [Route("[[Id]]")]
        public async Task<IActionResult> UpdateByIdAsync([FromBody]Models.UpdatedPizza pizza)
        {
            var entity = await _storage.GetByIdAsync(pizza.Id);
            var tempEntity = pizza.FromUpdatedPizzaModelToPizzaEntity();
            if(_isValidEntity(entity.Item2, tempEntity))
            {
                var result = await _storage.UpdateAsync(tempEntity);
                if(result.IsSuccess)
                {
                    return Ok($"Entity with id {entity.Item2.Id} is successfully updated.");
                }

                return BadRequest(result.exception.Message);
            }
            else
            {
                return BadRequest("You should change at least one property of the entity.");
            }

        }


        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
        {
            var deleteStatus = await _storage.DeleteAsync(id);
            if(deleteStatus.IsSuccess)
            {
                _logger.LogInformation($"Pizza entity with id {id} is deleted successfully from database");
                return Ok($"Pizza entity with id {id} is deleted successfully from database");
            }
            return BadRequest($"Error while deleteing entity with id {id}");
        }

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("{shortName}")]
        public async Task<IActionResult> DeleteByShortNameAsync([FromRoute]string shortName)
        {
            var deleteStatus = await _storage.DeleteAsync(shortName);
            if(deleteStatus.IsSuccess)
            {
                _logger.LogInformation($"Pizza entity with short name {shortName} is deleted successfully from database");
                return Ok($"Pizza entity with short name {shortName} is deleted successfully from database");
            }
            return BadRequest($"Error while deleteing entity with id {shortName}");
        }

        private bool _isValidEntity(Entities.Pizza entity, Entities.Pizza tempEntity)
        {
            return !(
                entity.Id == tempEntity.Id && 
                entity.Title == tempEntity.Title && 
                entity.ShortName == tempEntity.ShortName && 
                entity.StockStatus == tempEntity.StockStatus && 
                entity.Ingredients == tempEntity.Ingredients &&
                entity.Price == tempEntity.Price
            );
        }
    }
}