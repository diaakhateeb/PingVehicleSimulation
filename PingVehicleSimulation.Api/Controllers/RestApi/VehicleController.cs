using System.IO.Enumeration;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PingVehicleSimulation.Core.Entities;
using PingVehicleSimulation.Core.Interfaces;

namespace PingVehicleSimulation.Api.Controllers.RestApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Vehicle> _repo;
        public VehicleController(IMapper mapper, IRepository<Vehicle> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _repo.ListAsync();

            return Ok(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicle(int id)
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
