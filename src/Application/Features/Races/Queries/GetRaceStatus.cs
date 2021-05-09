using Application.Features.Races.Interfaces;
using Application.Features.Races.Models;
using Domain.Enums;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Races.Queries
{
    public static class GetRaceStatus
    {
        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly IRaceRepository _repository;

            public Handler(IRaceRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                var race = await _repository.GetRaceAsync(query.Id);
                if (race == null)
                {
                    return Result.Empty;
                }
                var status = CreateStatus(race);
                return new Result(status);
            }

            private RaceStatusModel CreateStatus(RaceModel race)
            {
                var vehicles = race.Vehicles;
                var finished = vehicles.Where(x => x.HeavyMalfunctionOccured == false).Count();
                var didntfinished = vehicles.Where(x => x.HeavyMalfunctionOccured == true).Count();
                var motorbikes = vehicles.Where(x => x.VehicleType == VehicleType.Motorbike).Count();
                var cars = vehicles.Where(x => x.VehicleType == VehicleType.Car).Count();
                var trucks = vehicles.Where(x => x.VehicleType == VehicleType.Truck).Count();

                return new RaceStatusModel
                {
                    RaceStatus = race.RaceStatus,
                    NumberOfVehiclesWhichFinishedTheRace = finished,
                    NumberOfVehiclesWhichDidntFinishedTheRace = didntfinished,
                    NumberOfMotorbikes = motorbikes,
                    NumberOfCars = cars,
                    NumberOfTrucks = trucks
                };
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
            public RaceStatusModel RaceStatus { get; }

            public bool IsEmpty { get; set; }

            public static Result Empty = new Result { IsEmpty = true };

            private Result() { }

            public Result(RaceStatusModel raceStatus)
            {
                RaceStatus = raceStatus;
            }
        }
    }
}
