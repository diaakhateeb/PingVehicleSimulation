using System;
using System.Collections.Generic;
using System.Text;

namespace PingVehicleSimulation.Core.DTO
{
    public class VehicleDto
    {
        public string Code { get; set; }
        public string RegNumber { get; set; }
        public int? CustomerId { get; set; }
    }
}