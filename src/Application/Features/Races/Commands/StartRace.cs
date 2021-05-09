using Application.Features.Races.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Races.Commands
{
    public static class StartRace
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly IRaceRepository _repository;
            private readonly IMediator _mediator;

            public Handler(IRaceRepository repository, IMediator mediator)
            {
                _repository = repository;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var race = await _repository.StartRaceAsync(command.Id);
                var int = await _mediator.Send(new CreateLeaderboard.Command(race));
                return Unit.Value;
            }
        }

        public class Command : IRequest
        {
            public int Id { get; }

            public Command(int id)
            {
                Id = id;
            }
        }
    }
}
