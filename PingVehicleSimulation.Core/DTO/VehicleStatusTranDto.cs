using System;

#nullable disable

namespace PingVehicleSimulation.Core.DTO
{
    public class VehicleStatusTranDto
    {
        public DateTime? PingTime { get; set; }
        public string Status { get; set; }
        public int? VehicleId { get; set; }
    }
}
