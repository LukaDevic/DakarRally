using Application.Features.Races.Models;
using System.Threading.Tasks;

namespace Application.Features.Races.Interfaces
{
    public interface IRaceRepository
    {
        Task<RaceModel> GetRaceAsync(int id);
        Task<int> CreateRaceAsync(RaceModel race);
        Task AddVehicleAsync(int id);
        Task<RaceModel> StartRaceAsync(int id);
    }
}
