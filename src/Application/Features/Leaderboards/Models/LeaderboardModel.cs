using Domain.Entities;
using System.Collections.Generic;

namespace Application.Features.Leaderboards.Models
{
    public class LeaderboardModel
    {
        public int Id { get; set; }
        public IList<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();
    } 
}
