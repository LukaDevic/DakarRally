using Application.Features.Races.Interfaces;
using Application.Features.Races.Models;
using Domain.Entities;
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

        public async Task StartRaceAsync(int id)
        {
            var race = await GetRace(id);
            race.Started = true;
            await _context.SaveChangesAsync();
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
                Started = entity.Started,
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
