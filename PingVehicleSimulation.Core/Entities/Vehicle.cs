using System.Collections.Generic;

#nullable disable

namespace PingVehicleSimulation.Core.Entities
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            VehicleStatusTrans = new HashSet<VehicleStatusTran>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string RegNumber { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<VehicleStatusTran> VehicleStatusTrans { get; set; }
    }
}
