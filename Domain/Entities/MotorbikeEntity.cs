using Domain.Constants;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class MotorbikeEntity : VehicleEntity
    {
        public MotorbikeEntity() : base()
        {
            var vehicleSpecification = VehicleSubType == VehicleSubType.Sport ? VehicleTypeSpecification.SportMotorbike : VehicleTypeSpecification.CrossMotorbike;
            VehicleType = VehicleType.Motorbike;
            Speed = vehicleSpecification.Speed;
            RepairmentTime = RepairmentTimeConstants.MotorbikeRepairmentTime;
            LightMalfunctionChance = vehicleSpecification.LightMalfunctionChance;
            HeavyMalfunctionChance = vehicleSpecification.HeavyMalfunctionChance;
        }
    }
}
