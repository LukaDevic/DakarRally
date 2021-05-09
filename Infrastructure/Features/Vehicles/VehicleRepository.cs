using Application.Features.Vehicles.Interfaces;
using Application.Features.Vehicles.Models;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Features.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleModel> GetVehicleAsync(int id)
        {
            var entity = await _context.Vehicles.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return ConvertToModel(entity);
        }

        public async Task<int> CreateVehicleAsync(VehicleModel vehicle)
        {
            var entity = CreateDbEntity(vehicle);
            await _context.Vehicles.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        private VehicleModel ConvertToModel(VehicleEntity entity)
        {
            if (entity == null) return new VehicleModel();

            return new VehicleModel
            {
                Id = entity.Id,
                TeamName = entity.TeamName,
                VehicleType = entity.VehicleType,
                VehicleSubType = entity.VehicleSubType,
                ManufacturingDate = entity.ManufacturingDate,
                Speed = entity.Speed,
                RepairmentTime = entity.RepairmentTime,
                LightMalfunctionChance = entity.LightMalfunctionChance,
                HeavyMalfunctionChance = entity.HeavyMalfunctionChance
            };
        }

        private VehicleEntity CreateDbEntity(VehicleModel vehicle)
        {

            switch (vehicle.VehicleType)
            {
                case VehicleType.Car:
                    return new CarEntity
                    {
                        TeamName = vehicle.TeamName,
                        VehicleType = vehicle.VehicleType,
                        VehicleSubType = vehicle.VehicleSubType,
                        ManufacturingDate = DateTime.Now
                    };
                case VehicleType.Motorbike:
                    return new MotorbikeEntity
                    {
                        TeamName = vehicle.TeamName,
                        VehicleType = vehicle.VehicleType,
                        VehicleSubType = vehicle.VehicleSubType,
                        ManufacturingDate = DateTime.Now
                    };
                default:
                    return new TruckEntity
                    {
                        TeamName = vehicle.TeamName,
                        VehicleType = vehicle.VehicleType,
                        VehicleSubType = vehicle.VehicleSubType,
                        ManufacturingDate = DateTime.Now
                    };
            }
        }
    }
}
