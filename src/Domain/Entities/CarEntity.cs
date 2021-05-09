using Domain.Constants;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class CarEntity : VehicleEntity
    {
        public CarEntity()
        {
            var vehicleSpecification = VehicleSubType == VehicleSubType.Sport ? VehicleTypeSpecification.SportCar : VehicleTypeSpecification.TerrainCar;
            VehicleType = VehicleType.Car;
            Speed = vehicleSpecification.Speed;
            RepairmentTime = RepairmentTimeConstants.CarRepairmentTime;
            LightMalfunctionChance = vehicleSpecification.LightMalfunctionChance;
            HeavyMalfunctionChance = vehicleSpecification.HeavyMalfunctionChance;
        }
    }
}
