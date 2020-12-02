using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PingVehicleSimulation.Core.Entities;
using PingVehicleSimulation.Core.Interfaces;
using PingVehicleSimulation.SharedLib;

namespace PingVehicleSimulation.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleApiGatewayController : ControllerBase
    {
        private readonly IMapper _mapper;
        public VehicleApiGatewayController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //RestHttpClient.GetHttpClientInstance.GetStringAsync()
            return Ok();
        }
    }
}
