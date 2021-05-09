using Application.Features.Races.Models;
using Application.Features.Vehicles.Models;
using System.Threading.Tasks;

namespace Application.Features.Races.Interfaces
{
    public interface IRaceRepository
    {
        Task<RaceModel> GetRaceAsync();
        Task<int> CreateRaceAsync(RaceModel race);
        Task AddVehicleAsync(int id);
    }
}
