using Application.Features.Leaderboards.Interfaces;
using Application.Features.Leaderboards.Models;
using Application.Features.Races.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leaderboards.Commands
{
    public static class CreateLeaderboard
    {
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly ILeaderboardsRepository _repository;
            private readonly IMediator _mediator;

            public Handler(ILeaderboardsRepository repository, IMediator mediator)
            {
                _repository = repository;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var leaderboard = RunRaceAndCreateLeaderbord(command.Race);
                return await _repository.CreateLeaderboard(leaderboard);
            }

            private LeaderboardModel RunRaceAndCreateLeaderbord(RaceModel race)
            {
                var Racers = new List<VehicleEntity>();
                foreach (var vehicle in race.Vehicles)
                {
                    while(vehicle.DistanceCoverdInKm < race.Distance)
                    {
                        vehicle.FinishedRaceInHours++;
                        var rnd = new Random().Next(1, 101);
                        if (rnd <= vehicle.HeavyMalfunctionChance)
                        {
                            vehicle.HeavyMalfunctionOccured = true;
                            break;
                        }
                        if (rnd <= vehicle.LightMalfunctionChance)
                        {
                            vehicle.LightMalfunctionsTimesOccured++;
                            vehicle.FinishedRaceInHours += vehicle.RepairmentTime;
                        }
                        else
                        {
                            vehicle.DistanceCoverdInKm += vehicle.Speed;
                        }
                    }

                        Racers.Add(vehicle);
                }
                return new LeaderboardModel
                {
                    Vehicles = Racers.OrderBy(x => x.HeavyMalfunctionOccured)
                                     .ThenByDescending(x => x.DistanceCoverdInKm)
                                     .ThenByDescending(x => x.FinishedRaceInHours)
                                     .ToList()
                };
            }
        }

        public class Command : IRequest<int>
        {
            public Command(RaceModel race)
            {
                Race = race;
            }

            public RaceModel Race { get; }
        }

    }
}
