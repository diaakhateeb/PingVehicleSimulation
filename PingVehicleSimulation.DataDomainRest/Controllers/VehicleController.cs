using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingVehicleSimulation.Core.Entities;
using PingVehicleSimulation.Core.Interfaces;

namespace PingVehicleSimulation.DataDomainRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork<Vehicle> _vehicleUnitOfWork;

        public VehicleController(IUnitOfWork<Vehicle> vehicleUnitOfWork)
        {
			_vehicleUnitOfWork = vehicleUnitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = await _vehicleUnitOfWork.RepositoryObject.ListAsync();

            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            
	        var vehicle = await _vehicleUnitOfWork.RepositoryObject.FindByIdAsync(id);

            return Ok(vehicle);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddVehicle(Vehicle vehicle)
        {
            var newVehicle = await _vehicleUnitOfWork.RepositoryObject.AddAsync(vehicle);
            await _vehicleUnitOfWork.SaveChangesToDbAsync();

            return Ok(newVehicle);
        }

        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateVehicle(Vehicle vehicle)
        {
            await _vehicleUnitOfWork.RepositoryObject.UpdateAsync(vehicle);
            await _vehicleUnitOfWork.SaveChangesToDbAsync();

            return Ok(vehicle);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteVehicle(Vehicle vehicle)
        {
            await _vehicleUnitOfWork.RepositoryObject.DeleteAsync(vehicle);
			await _vehicleUnitOfWork.SaveChangesToDbAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleById(int id)
        {
            var vehicle = await _vehicleUnitOfWork.RepositoryObject.FindByIdAsync(id);

            if (vehicle == null)
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }
            
            await _vehicleUnitOfWork.RepositoryObject.DeleteAsync(vehicle);
			await _vehicleUnitOfWork.SaveChangesToDbAsync();

            return Ok();

        }
    }
}
