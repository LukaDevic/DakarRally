using Domain.Enums;

namespace Application.Features.Races.Models
{
    public class RaceStatusModel
    {
        public RaceStatus RaceStatus { get; set; }
        public int NumberOfVehiclesWhichFinishedTheRace { get; set; }
        public int NumberOfVehiclesWhichDidntFinishedTheRace { get; set; }
        public int NumberOfMotorbikes { get; set; }
        public int NumberOfCars { get; set; }
        public int NumberOfTrucks { get; set; }
    }
}
