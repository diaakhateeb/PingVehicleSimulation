using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingVehicleSimulation.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesToDbAsync();
    }
}
