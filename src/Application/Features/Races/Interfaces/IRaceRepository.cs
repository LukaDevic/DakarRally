using Application.Features.Races.Models;
using Domain.Enums;
using System.Threading.Tasks;

namespace Application.Features.Races.Interfaces
{
    public interface IRaceRepository
    {
        Task<RaceModel> GetRaceAsync(int id);
        Task<int> CreateRaceAsync(RaceModel race);
        Task AddVehicleAsync(int id);
        Task<RaceModel> SetRaceStatusAsync(int id, RaceStatus raceStatus);
    }
}
