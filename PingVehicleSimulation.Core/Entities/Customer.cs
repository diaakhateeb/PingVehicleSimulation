using System.Collections.Generic;

#nullable disable

namespace PingVehicleSimulation.Core.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
