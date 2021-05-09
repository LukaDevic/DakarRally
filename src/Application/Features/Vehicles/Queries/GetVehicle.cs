using Application.Features.Vehicles.Interfaces;
using Application.Features.Vehicles.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Queries
{
    public static class GetVehicle
    {
        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly IVehicleRepository _repository;

            public Handler(IVehicleRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                var vehicle = await _repository.GetVehicleAsync(query.Id);
                return vehicle != null
                    ? new Result(vehicle)
                    : Result.Empty;
            }
        }

        public class Query : IRequest<Result> 
        {
            public Query(int id)
            {
                Id = id;
            }
            public int Id { get; }
        }

        public class Result
        {
            public VehicleModel Vehicle { get; }

            public bool IsEmpty { get; private set; }

            public static Result Empty = new Result { IsEmpty = true };

            private Result() { }
            public Result(VehicleModel vehicle)
            {
                Vehicle = vehicle;
            }
        }
    }
}
