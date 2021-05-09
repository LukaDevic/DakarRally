using Domain.Enums;
using System;

namespace Application.Features.Vehicles.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public string TeamName { get; set; }
        public VehicleType VehicleType { get; set; }
        public VehicleSubType VehicleSubType { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public int Speed { get; set; }
        public int RepairmentTime { get; set; }
        public double LightMalfunctionChance { get; set; }
        public int LightMalfunctionsTimesOccured { get; set; }
        public double HeavyMalfunctionChance { get; set; }
        public bool HeavyMalfunctionOccured { get; set; }
        public int FinishedRaceInHours { get; set; }
        public int DistanceCoverdInKm { get; set; }
    }
}
