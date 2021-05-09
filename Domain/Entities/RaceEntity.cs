using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class RaceEntity
    {
        [Key]
        public int Id { get; set; }
        public int Distance { get; protected set; } = 10000;
        public IList<VehicleEntity> Vehicles { get; set; } =  new List<VehicleEntity>();
        public int Year { get; set; }
        public bool Started { get; set; }
    }
}
