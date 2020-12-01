using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingVehicleSimulation.Core;
using PingVehicleSimulation.Core.Interfaces;

namespace PingVehicleSimulation.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ALTENStockholmChallengeContext _dbContext;

        public Repository(ALTENStockholmChallengeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);

            return entity;
        }

        public async Task<TEntity> FindAsync(TEntity entity)
        {
            return await _dbContext.Set<TEntity>().FindAsync(entity);
        }

        public async Task<TEntity> FindByPredicateAsync(Predicate<TEntity> entity)
        {
            return await _dbContext.Set<TEntity>().FindAsync(entity);
        }

        public async Task<List<TEntity>> ListAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            });
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbContext.Set<TEntity>().Remove(entity);
            });
        }
    }
}
