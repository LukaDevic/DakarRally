using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Races.Any())
            {
                context.Races.Add(new RaceEntity
                {
                    Id = 1,
                    Year = 2021,
                    RaceStatus = RaceStatus.pending,
                    Vehicles = new List<VehicleEntity>
                    {
                        new CarEntity
                        {
                            Id = 1,
                            TeamName = "Team A",
                            VehicleType = VehicleType.Car,
                            VehicleSubType = VehicleSubType.Sport,
                            ManufacturingDate = DateTime.Now,
                            RaceId = 1
                        },
                        new CarEntity
                        {
                            Id = 2,
                            TeamName = "Team B",
                            VehicleType = VehicleType.Car,
                            VehicleSubType = VehicleSubType.Terrain,
                            ManufacturingDate = DateTime.Now,
                            RaceId = 1
                        },
                        new MotorbikeEntity
                        {
                            Id = 3,
                            TeamName = "Team A",
                            VehicleType = VehicleType.Motorbike,
                            VehicleSubType = VehicleSubType.Cross,
                            ManufacturingDate = DateTime.Now,
                            RaceId = 1
                        },
                        new MotorbikeEntity
                        {
                            Id = 4,
                            TeamName = "Team C",
                            VehicleType = VehicleType.Motorbike,
                            VehicleSubType = VehicleSubType.Sport,
                            ManufacturingDate = DateTime.Now,
                            RaceId = 1
                        },
                        new TruckEntity
                        {
                            Id = 5,
                            TeamName = "Team D",
                            VehicleType = VehicleType.Truck,
                            ManufacturingDate = DateTime.Now,
                            RaceId = 1
                        },
                        new TruckEntity
                        {
                            Id = 6,
                            TeamName = "Team A",
                            VehicleType = VehicleType.Truck,
                            ManufacturingDate = DateTime.Now,
                            RaceId = 1
                        },
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
