using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pizza.Entities;

namespace Pizza.Services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, List<Entities.Pizza>, Exception exception)> GetAllAsync();
        Task<(bool IsSuccess, Entities.Pizza, Exception exception)> GetByIdAsync(Guid id);
        Task<(bool IsSuccess, Exception exception)> InsertAsync(Entities.Pizza pizza);
        Task<(bool IsSuccess, Exception exception)> UpdateAsync(Entities.Pizza pizza);
        Task<(bool IsSuccess, Exception exception)> DeleteAsync(Guid id);
        Task<(bool IsSuccess, Exception exception)> DeleteAsync(string shortName);
    }
}