using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PingVehicleSimulation.Core.DTO;
using PingVehicleSimulation.Core.Entities;

namespace PingVehicleSimulation.Api
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
