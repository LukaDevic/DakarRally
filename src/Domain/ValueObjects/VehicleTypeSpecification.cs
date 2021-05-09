namespace Domain.ValueObjects
{
    public class VehicleTypeSpecification
    {
        private VehicleTypeSpecification() { }
        public static VehicleTypeSpecification SportCar => new VehicleTypeSpecification { Speed = 140, LightMalfunctionChance = 0.12, HeavyMalfunctionChance = 0.02 };
        public static VehicleTypeSpecification TerrainCar => new VehicleTypeSpecification { Speed = 100, LightMalfunctionChance = 0.03, HeavyMalfunctionChance = 0.01 };
        public static VehicleTypeSpecification Truck => new VehicleTypeSpecification { Speed = 80, LightMalfunctionChance = 0.06, HeavyMalfunctionChance = 0.04 };
        public static VehicleTypeSpecification SportMotorbike => new VehicleTypeSpecification { Speed = 130, LightMalfunctionChance = 0.18, HeavyMalfunctionChance = 0.10 };
        public static VehicleTypeSpecification CrossMotorbike => new VehicleTypeSpecification { Speed = 85, LightMalfunctionChance = 0.03, HeavyMalfunctionChance = 0.02 };

        public int Speed { get; private set; }
        public double LightMalfunctionChance { get; private set; }
        public double HeavyMalfunctionChance { get; private set; }
    }
}
