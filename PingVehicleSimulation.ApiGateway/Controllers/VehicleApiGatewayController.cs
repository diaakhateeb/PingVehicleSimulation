using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        private readonly string dataDomainRestBaseUri;

        public VehicleApiGatewayController(IMapper mapper, IConfiguration config)
        {
	        _mapper = mapper;
	        _config = config;
            dataDomainRestBaseUri = _config.GetValue<string>("DataDomainRestBaseUri");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
	        using var httpClient = RestHttpClient.GetHttpClientInstance(dataDomainRestBaseUri);

	        var vehicles = await httpClient.GetStringAsync("api/Vehicle");

	        return Ok(vehicles);
        }
    }
}
