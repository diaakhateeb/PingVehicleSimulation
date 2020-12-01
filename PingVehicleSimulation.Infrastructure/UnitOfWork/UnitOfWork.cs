using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingVehicleSimulation.Core.Interfaces;

namespace PingVehicleSimulation.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public  UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> SaveChangesToDbAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
