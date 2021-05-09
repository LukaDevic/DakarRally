using Domain.Enums;

namespace WebUI.Features.Vehicles.Models
{
    public class VehicleStatisticModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }       
        public VehicleType VehicleType { get; set; }
        public VehicleSubType VehicleSubType { get; set; }
        public int LightMalfunctionsTimesOccured { get; set; }
        public bool HeavyMalfunctionOccured { get; set; }
        public bool FinishedRace { get; set; }
        public int FinishedRaceInHours { get; set; }
        public int DistanceCoverdInKm { get; set; }
    }
}
