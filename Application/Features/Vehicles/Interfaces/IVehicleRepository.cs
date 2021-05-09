using Application.Features.Vehicles.Models;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Interfaces
{
    public interface IVehicleRepository
    {
        Task<VehicleModel> GetVehicleAsync(int id);
        Task<int> CreateVehicleAsync(VehicleModel vehicle);
    }
}
