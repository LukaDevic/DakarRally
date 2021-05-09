using Domain.Constants;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class TruckEntity : VehicleEntity
    {
        public TruckEntity()
        {
            var vehicleSpecification = VehicleTypeSpecification.Truck;
            Speed = vehicleSpecification.Speed;
            RepairmentTime = RepairmentTimeConstants.TruckRepairmentTime;
            LightMalfunctionChance = vehicleSpecification.LightMalfunctionChance;
            HeavyMalfunctionChance = vehicleSpecification.HeavyMalfunctionChance;
        }
    }
}
