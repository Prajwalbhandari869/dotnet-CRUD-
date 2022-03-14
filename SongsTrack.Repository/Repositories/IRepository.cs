using SongsTrack.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Repository.Repositories
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetCurrentAsync();
        Task<T> GetAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> CheckAsync(string titleOrName);
        Task<bool> CheckAsync(int id,string titleOrName);
    }
}
