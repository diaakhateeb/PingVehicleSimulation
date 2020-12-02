using AutoMapper;
using PingVehicleSimulation.Core.DTO;
using PingVehicleSimulation.Core.Entities;

namespace PingVehicleSimulation.ApiGateway
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<VehicleStatusTran, VehicleStatusTranDto>();
        }
    }
}
