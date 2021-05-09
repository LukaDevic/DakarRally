using Application.Features.Races.Interfaces;
using Application.Features.Races.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Races.Commands
{
    public static class CreateRace
    {
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IRaceRepository _repository;

            public Handler(IRaceRepository repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                return await _repository.CreateRaceAsync(command.Race);
            }
        }

        public class Command : IRequest<int>
        {
            public Command(RaceModel race)
            {
                Race = race ?? throw new ArgumentNullException(nameof(race));
            }
            public RaceModel Race { get; }
        }
    }
}
