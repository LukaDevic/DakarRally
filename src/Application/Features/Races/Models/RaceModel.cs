using Domain.Entities;
using System.Collections.Generic;

namespace Application.Features.Races.Models
{
    public class RaceModel
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public IEnumerable<VehicleEntity> Vehicles { get; set; }
        public int Year { get; set; }
        public bool Started { get; set; }
    }
}
