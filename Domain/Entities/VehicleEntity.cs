using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class VehicleEntity
    {
        [Key]
        public int Id { get; set; }
        public int RaceId { get; set; }
        public string TeamName { get; set; }
        public VehicleType VehicleType { get; set; }
        public VehicleSubType VehicleSubType { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public int Speed { get; set; }
        public int RepairmentTime { get; set; }
        public double LightMalfunctionChance { get; set; }
        public double HeavyMalfunctionChance { get; set; }
    }
}
