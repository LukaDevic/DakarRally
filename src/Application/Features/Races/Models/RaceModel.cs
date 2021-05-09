using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;

namespace Application.Features.Races.Models
{
    public class RaceModel
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public IEnumerable<VehicleEntity> Vehicles { get; set; }
        public int Year { get; set; }
        public RaceStatus RaceStatus { get; set; }
    }
}
