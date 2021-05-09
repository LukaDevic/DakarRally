using Domain.Enums;
using System;

namespace Application.Features.Vehicles.Models
{
    public class VehicleDto
    {
        public string TeamName { get; set; }
        public VehicleType VehicleType { get; set; }
        public VehicleSubType VehicleSubType { get; set; }
    }
}
