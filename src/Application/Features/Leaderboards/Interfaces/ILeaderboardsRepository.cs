using Application.Features.Leaderboards.Models;
using System.Threading.Tasks;

namespace Application.Features.Leaderboards.Interfaces
{
    public interface ILeaderboardsRepository
    {
        Task<LeaderboardModel> GetLeaderboardAsync();
        Task<LeaderboardModel> GetLeaderboardAsync(int id);
        Task<int> CreateLeaderboard(LeaderboardModel leaderboard);
    }
}
