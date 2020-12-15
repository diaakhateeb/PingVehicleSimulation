using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PingVehicleSimulation.Core.Interfaces
{
    public interface IUnitOfWork<T>
    {
        IRepository<T> RepositoryObject {get;}
        Task<int> SaveChangesToDbAsync();
    }
}
