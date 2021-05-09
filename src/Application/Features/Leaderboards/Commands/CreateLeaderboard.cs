using Application.Features.Races.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leaderboards.Commands
{
    public static class CreateLeaderboard
    {
        public class Handler : IRequestHandler<Command, int>
        {
            public Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var leaderboard = RunRaceAndCreateLeaderbord(command.Race);
                throw new System.NotImplementedException();
            }

            private LeaderboardModel RunRaceAndCreateLeaderbord(RaceModel race)
            {

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
