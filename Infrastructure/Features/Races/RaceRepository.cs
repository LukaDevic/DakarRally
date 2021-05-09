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

        public async Task<RaceModel> GetRaceAsync()
        {
            var entity = await GetRace();
            return ConvertToModel(entity);
        }

        public async Task<int> CreateRaceAsync(RaceModel race)
        {
            var entity = CreateDbEntity(race);
            await _context.Races.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task AddVehicleAsync(int id)
        {
            var race = await GetRace();
            var vehicleEntity = await _context.Vehicles.SingleOrDefaultAsync(x => x.Id == id);
            race.Vehicles.Add(vehicleEntity);
            await _context.SaveChangesAsync();
        }

        private async Task<RaceEntity> GetRace()
        {
            return await _context.Races.Include(x => x.Vehicles).FirstOrDefaultAsync();
        }

        private RaceModel ConvertToModel(RaceEntity entity)
        {
            if(entity == null) return new RaceModel();

            return new RaceModel
            {
                Id = entity.Id,
                Distance = entity.Distance,
                Vehicles = entity.Vehicles
            };
        }

        private RaceEntity CreateDbEntity(RaceModel race)
        {
            return new RaceEntity
            {
                Vehicles = new List<VehicleEntity>()
            };
        }
    }
}
