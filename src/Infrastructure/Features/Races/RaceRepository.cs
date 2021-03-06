using Application.Features.Races.Interfaces;
using Application.Features.Races.Models;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Features.Races
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RaceModel> GetRaceAsync(int id)
        {
            var entity = await GetRace(id);
            return ConvertToModel(entity);
        }

        public async Task<int> CreateRaceAsync(RaceModel race)
        {
            var entity = CreateDbEntity(race);
            await _context.Races.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<RaceModel> SetRaceStatusAsync(int id, RaceStatus raceStatus)
        {
            var race = await GetRace(id);
            if (race != null)
            {
                race.RaceStatus = raceStatus;
                await _context.SaveChangesAsync();
            }
            return ConvertToModel(race);
        }


        public async Task AddVehicleAsync(int id)
        {
            var vehicleEntity = await _context.Vehicles.SingleOrDefaultAsync(x => x.Id == id);
            var race = await GetRace(vehicleEntity.RaceId);
            if (race != null)
            {
                race.Vehicles.Add(vehicleEntity);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<RaceEntity> GetRace(int id)
        {
            return await _context.Races.Include(x => x.Vehicles).FirstOrDefaultAsync(x => x.Id == id);
        }

        private RaceModel ConvertToModel(RaceEntity entity)
        {
            if (entity == null) return new RaceModel();

            return new RaceModel
            {
                Id = entity.Id,
                Distance = entity.Distance,
                Vehicles = entity.Vehicles,
                Year = entity.Year,
                RaceStatus = entity.RaceStatus,
            };
        }

        private RaceEntity CreateDbEntity(RaceModel race)
        {
            return new RaceEntity
            {
                Year = race.Year,
                Vehicles = new List<VehicleEntity>()
            };
        }
    }
}
