using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace task.Services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, bool IsInserted, Exception exception)> InsertTaskAsync(Entities.Task task);
        Task<(bool IsSuccess, List<Entities.Task> tasks, Exception exception)> GetTasksAsync(
            Guid id = default(Guid),
            string title = default(string),
            string description = default(string),
            string tags = default(string),
            Entities.ETaskPriority? priority = null,
            Entities.ETaskRepeat? repeat= null,
            Entities.ETaskStatus? status = null,
            DateTimeOffset onADay = default(DateTimeOffset),
            DateTimeOffset atATime = default(DateTimeOffset),
            string location = default(string),
            string url = default(string)
        );
        Task<(bool IsSuccess,bool IsFound, Exception exception)> UpdateTaskAsync(Entities.Task task);
        Task<(bool IsSuccess, bool IsDeleted, Exception exception)> DeleteTaskAsync(Guid id);


    }    
}