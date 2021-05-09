using Application.Features.Leaderboards.Interfaces;
using Application.Features.Leaderboards.Models;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Features.Leaderboards
{
    public class LeaderboardsRepository : ILeaderboardsRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaderboardsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LeaderboardModel> GetLeaderboardAsync()
        {
            var entity = await _context.Leaderboards
                                       .Include(x => x.Vehicles)
                                       .FirstOrDefaultAsync();
            return ConvertToModel(entity);
        }

        public async Task<LeaderboardModel> GetLeaderboardAsync(int id)
        {
            var entity = await _context.Leaderboards
                                       .Include(x => x.Vehicles)
                                       .FirstOrDefaultAsync(x => x.Id == id);
            return ConvertToModel(entity);
        }

        private LeaderboardModel ConvertToModel(LeaderboardEntity entity)
        {
            if (entity == null) return new LeaderboardModel();

            return new LeaderboardModel
            {
                Id = entity.Id,
                Vehicles = entity.Vehicles
            };
        }

        public async Task<int> CreateLeaderboard(LeaderboardModel leaderboard)
        {
            LeaderboardEntity entity = CreateDbEntity(leaderboard);
            await _context.Leaderboards.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        private LeaderboardEntity CreateDbEntity(LeaderboardModel leaderboard)
        {
            return new LeaderboardEntity
            {
                Vehicles = leaderboard.Vehicles.ToList()
            };
        }
    }
}
