namespace Domain.ValueObjects
{
    public class VehicleTypeSpecification
    {
        private VehicleTypeSpecification() { }
        public static VehicleTypeSpecification SportCar => new VehicleTypeSpecification { Speed = 140, LightMalfunctionChance = 12, HeavyMalfunctionChance = 2 };
        public static VehicleTypeSpecification TerrainCar => new VehicleTypeSpecification { Speed = 100, LightMalfunctionChance = 3, HeavyMalfunctionChance = 1 };
        public static VehicleTypeSpecification Truck => new VehicleTypeSpecification { Speed = 80, LightMalfunctionChance = 6, HeavyMalfunctionChance = 4 };
        public static VehicleTypeSpecification SportMotorbike => new VehicleTypeSpecification { Speed = 130, LightMalfunctionChance = 18, HeavyMalfunctionChance = 10 };
        public static VehicleTypeSpecification CrossMotorbike => new VehicleTypeSpecification { Speed = 85, LightMalfunctionChance = 3, HeavyMalfunctionChance = 2 };

        public int Speed { get; private set; }
        public double LightMalfunctionChance { get; private set; }
        public double HeavyMalfunctionChance { get; private set; }
    }
}
