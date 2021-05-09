using Application.Features.Vehicles.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Queries
{
    public static class GetVehicles
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
                var vehicles = await _repository.GetVehiclesAsync();
                if (query.TeamName != null && query.TeamName != string.Empty)
                {
                    vehicles = vehicles.Where(x => x.TeamName == query.TeamName);
                }
                if (query.VehicleType != null)
                {
                    vehicles = vehicles.Where(x => x.VehicleType == query.VehicleType);
                }
                if (query.ManufacturingDate != null)
                {
                    vehicles = vehicles.Where(x => x.ManufacturingDate == query.ManufacturingDate);
                }
                if (query.HeavyMalfunctionOccured != null)
                {
                    vehicles = vehicles.Where(x => x.HeavyMalfunctionOccured == query.HeavyMalfunctionOccured);
                }
                return new Result { Vehicles = vehicles };
            }
        }

        public class Query : IRequest<Result>
        {
            public string TeamName { get; set; }
            public VehicleType? VehicleType { get; set; }
            public DateTime? ManufacturingDate { get; set; }
            public bool? HeavyMalfunctionOccured { get; set; }
            public int? DistanceCoverdInKm { get; set; }
        }

        public class Result
        {
            public IEnumerable<VehicleEntity> Vehicles { get; set; }
        }
    }
}
