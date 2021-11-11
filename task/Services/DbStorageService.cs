using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using task.Data;
using task.Entities;

namespace task.Services
{
    public class DbStorageService : IStorageService
    {
        private readonly TaskDbContext _context;
        private readonly ILogger<DbStorageService> _logger;

        public DbStorageService(TaskDbContext context, ILogger<DbStorageService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<(bool IsSuccess, bool IsDeleted, Exception exception)> DeleteTaskAsync(Guid id)
        {
            try
            {
                 var taskToBeRemoved = _context.Tasks.FirstOrDefault(t => t.Id == id);
                 if(taskToBeRemoved != default(Entities.Task))
                 {
                    _context.Tasks.Remove(taskToBeRemoved);
                    await _context.SaveChangesAsync();
                    return (true, true, null);
                 }
                 else
                 {
                     return (true, false, null);
                 }
            }
            catch (Exception e)
            {
                return (false, false, e);
            }
        }

        public async Task<(bool IsSuccess, List<Entities.Task> tasks, Exception exception)> GetTasksAsync(
            Guid id = default(Guid), 
            string title = default(string), 
            string description = default(string),
            string tags = default(string), 
            ETaskPriority? priority = null, 
            ETaskRepeat? repeat = null, 
            ETaskStatus? status = null, 
            DateTimeOffset onADay = default(DateTimeOffset), 
            DateTimeOffset atATime = default(DateTimeOffset), 
            string location = default(string), 
            string url = default(string))
        {
            try
            {
                var task = _context.Tasks.AsNoTracking();   
      
                if(id != default(Guid))
                {
                    task = task.Where(t => t.Id == id);
                }
                if(title != default(string))
                {
                    task = task.Where(t => t.Title == title);
                }
                if(description != default(string))
                {
                    task = task.Where(t => t.Description == description);
                }
                if(tags != default(string))
                {
                    task = task.Where(t => t.Tags == tags);
                }
                if(priority.HasValue)
                {
                    task = task.Where(t => t.Priority == priority.Value);
                }
                if(status.HasValue)
                {
                    task = task.Where(t => t.Status == status.Value);
                }
                if(repeat.HasValue)
                {
                    task = task.Where(t => t.Repeat == repeat.Value);
                }
                if(onADay != default(DateTimeOffset))
                {
                    task = task.Where(t => t.OnADay == onADay);
                }
                if(atATime != default(DateTimeOffset))
                {
                    task = task.Where(t => t.AtATime == atATime);
                }
                if(location != default(string))
                {
                    task = task.Where(t => t.Location == location);
                }
                if(url != default(string))
                {
                    task = task.Where(t => t.Url == url);
                    
                }
                return (true, await task.ToListAsync(), null);
            }
            catch (Exception e)
            {
                return (false, null, e);
            }
        }

        

        public async Task<(bool IsSuccess, bool IsInserted, Exception exception)> InsertTaskAsync(Entities.Task task)
        {
            try
            {
                if(!_context.Tasks.Any(t => t.Id == task.Id))
                {
                    await _context.Tasks.AddAsync(task);
                    await _context.SaveChangesAsync();
                    return (true, true, null);
                }
                return (true, false, null);
            }
            catch (Exception e)
            {
                return(false,false,  e);
            }
        }

        public async Task<(bool IsSuccess, bool IsFound, Exception exception)> UpdateTaskAsync(Entities.Task task)
        {
            try
            {
                if(_context.Tasks.Any(t => t.Id == task.Id))
                {
                    var taskToBeRemoved = _context.Tasks.FirstOrDefault(t => t.Id == task.Id);
                    if(taskToBeRemoved != default(Entities.Task))
                    {
                        _context.Remove(taskToBeRemoved);
                        await _context.SaveChangesAsync();
                    }
                    await _context.AddAsync(task);
                    await _context.SaveChangesAsync();
                    
                    return (true, true, null);
                }
                else
                {
                    return (true, false, null);
                }
            }
            catch (Exception e)
            {
                return (false, false, e);
            }
        }
    }
}