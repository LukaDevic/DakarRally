using Domain.Enums;
using System;

namespace WebUI.Features.Vehicles.Models
{
    public class ListParameters
    {
        public string TeamName { get; set; }
        public VehicleType? VehicleType { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public bool? HeavyMalfunctionOccured { get; set; }
        public int? DistanceCoverdInKm { get; set; }
    }
}
