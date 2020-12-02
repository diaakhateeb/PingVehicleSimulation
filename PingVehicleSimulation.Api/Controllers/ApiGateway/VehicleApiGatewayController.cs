using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PingVehicleSimulation.Core.DTO;
using PingVehicleSimulation.Core.Entities;
using PingVehicleSimulation.Core.Interfaces;

namespace PingVehicleSimulation.Api.Controllers.ApiGateway
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleApiGatewayController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Vehicle> _repo;
        public VehicleApiGatewayController(IMapper mapper, IRepository<Vehicle> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = await _repo.ListAsync();

            //var model = _mapper.Map<VehicleDto>(vehicles);

            return Ok(vehicles);
        }
    }
}
