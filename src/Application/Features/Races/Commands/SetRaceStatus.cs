using Application.Features.Leaderboards.Commands;
using Application.Features.Races.Interfaces;
using Application.Features.Races.Models;
using Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Races.Commands
{
    public static class SetRaceStatus
    {
        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly IRaceRepository _repository;
            private readonly IMediator _mediator;

            public Handler(IRaceRepository repository, IMediator mediator)
            {
                _repository = repository;
                _mediator = mediator;
            }

            public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
            {
                var race = await _repository.SetRaceStatusAsync(command.Id, RaceStatus.running);
                return new Result(race);
            }
        }

        public class Command : IRequest<Result>
        {
            public int Id { get; }

            public RaceStatus RaceStatus { get;}

            public Command(int id, RaceStatus raceStatus)
            {
                Id = id;
                RaceStatus = raceStatus;
            }
        }

        public class Result
        {
            public Result(RaceModel race)
            {
                Race = race;
            }

            public RaceModel Race { get; }
        }
    }
}
