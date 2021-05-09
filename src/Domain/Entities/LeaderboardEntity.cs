using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class LeaderboardEntity
    {
        [Key]
        public int Id { get; set; }
        public IList<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();
    }
}
