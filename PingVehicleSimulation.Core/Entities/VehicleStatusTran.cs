using System;

#nullable disable

namespace PingVehicleSimulation.Core.Entities
{
    public partial class VehicleStatusTran
    {
        public int Id { get; set; }
        public DateTime? PingTime { get; set; }
        public PingStatus Status { get; set; }
        public int? VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
