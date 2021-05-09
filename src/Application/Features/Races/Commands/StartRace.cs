using Application.Features.Leaderboards.Commands;
using Application.Features.Races.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Races.Commands
{
    public static class StartRace
    {
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IRaceRepository _repository;
            private readonly IMediator _mediator;

            public Handler(IRaceRepository repository, IMediator mediator)
            {
                _repository = repository;
                _mediator = mediator;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var race = await _repository.StartRaceAsync(command.Id);
                return await _mediator.Send(new CreateLeaderboard.Command(race));
            }
        }

        public class Command : IRequest<int>
        {
            public int Id { get; }

            public Command(int id)
            {
                Id = id;
            }
        }
    }
}
