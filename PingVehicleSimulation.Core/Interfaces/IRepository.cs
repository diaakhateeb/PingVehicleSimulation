using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingVehicleSimulation.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> FindAsync(TEntity entity);
        Task<TEntity> FindByIdAsync<T>(T id);
        Task<List<TEntity>> ListAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
