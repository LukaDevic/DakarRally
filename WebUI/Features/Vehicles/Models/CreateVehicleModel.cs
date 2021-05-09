using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Features.Vehicles.Models
{
    public class CreateVehicleModel
    {
        [Required]
        public string TeamName { get; set; }
        [Required]
        public VehicleType VehicleType { get; set; }
        [Required]
        public VehicleSubType VehicleSubType { get; set; }
    }
}
