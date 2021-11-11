using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using task.Data;
using task.Services;

namespace task.Controllers
{
    [ApiController]
    [Route("[tasks]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStorageService _storage;

        public TaskController(ILogger logger, IStorageService storage)
        {
            _logger = logger;
            _storage = storage;
        }
        

    }
}