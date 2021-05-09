using Application.Features.Vehicles.Models;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<VehicleEntity>> GetVehiclesAsync();
        Task<VehicleModel> GetVehicleAsync(int id);
        Task<int> CreateVehicleAsync(VehicleModel vehicle);
        Task UpdateAsync(VehicleModel vehicle);
        Task<int> DeleteAsync(int id);
    }
}
