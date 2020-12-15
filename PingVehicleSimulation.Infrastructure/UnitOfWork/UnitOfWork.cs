using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingVehicleSimulation.Core.Interfaces;
using PingVehicleSimulation.Infrastructure.DataContext;
using PingVehicleSimulation.Infrastructure.Repositories;

namespace PingVehicleSimulation.Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
	    private readonly DbContext _dbContext;
	    private readonly IRepository<T> _repo;

        public  UnitOfWork(IRepository<T> repo, DbContext dbContext)
        {
	        _repo = repo;
	        _dbContext = dbContext;
        }

        public IRepository<T> RepositoryObject => _repo ?? new Repository<T>((ALTENStockholmChallengeContext) _dbContext);

        public async Task<int> SaveChangesToDbAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
