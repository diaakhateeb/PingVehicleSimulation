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
        private readonly IRepository<Vehicle> _repo;
        public VehicleController(IRepository<Vehicle> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = await _repo.ListAsync();

            return Ok(vehicles);
        }

        [HttpGet]
        [Route("api/controller/{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await _repo.FindByPredicateAsync(v => v.Id == id);

            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(Vehicle vehicle)
        {
            var newVehicle = await _repo.AddAsync(vehicle);

            return Ok(newVehicle);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVehicle(Vehicle vehicle)
        {
            await _repo.UpdateAsync(vehicle);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle(Vehicle vehicle)
        {
            await _repo.DeleteAsync(vehicle);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehicleById(int id)
        {
            var vehicle = await _repo.FindByPredicateAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }
            
            await _repo.DeleteAsync(vehicle);
            return Ok();

        }
    }
}
