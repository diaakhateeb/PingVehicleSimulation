using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PingVehicleSimulation.Core.Entities;
using PingVehicleSimulation.Core.Interfaces;

namespace PingVehicleSimulation.DataDomainRest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VehicleStatusTrans : ControllerBase
	{
		private readonly IUnitOfWork<VehicleStatusTran> _vehicleStatusTransUnitOfWork;

		public VehicleStatusTrans(IUnitOfWork<VehicleStatusTran> vehicleStatusTransUnitOfWork)
		{
			_vehicleStatusTransUnitOfWork = vehicleStatusTransUnitOfWork;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> SavePingTransaction(PingStatus pingStatus, int vehicleId)
		{
			var newVehicleTrans = new VehicleStatusTran
			{
				PingTime = DateTime.Now,
				Status = pingStatus,
				VehicleId = vehicleId

			};
			await _vehicleStatusTransUnitOfWork.RepositoryObject.AddAsync(newVehicleTrans);

			await _vehicleStatusTransUnitOfWork.SaveChangesToDbAsync();

			return Ok(newVehicleTrans);
		}
	}
}
