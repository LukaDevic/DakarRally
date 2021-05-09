using Application.Features.Leaderboards.Interfaces;
using Application.Features.Leaderboards.Models;
using Domain.Enums;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leaderboards.Queries
{
    public static class GetLeaderboardByType
    {
        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly ILeaderboardsRepository _repository;

            public Handler(ILeaderboardsRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                var leaderboard = await _repository.GetLeaderboardAsync();
                if(leaderboard == null)
                {
                    return Result.Empty;
                }
                var vehicleByType = leaderboard.Vehicles
                                               .Where(x => x.VehicleType == query.VehicleType)
                                               .ToList();
                return new Result(new LeaderboardModel { Id = leaderboard.Id, Vehicles = vehicleByType });
            }
        }

        public class Query : IRequest<Result>
        {
            public Query(VehicleType vehicleType)
            {
                VehicleType = vehicleType;
            }

            public VehicleType VehicleType { get; }
        }

        public class Result
        {
            public LeaderboardModel Leaderboard { get; }

            public bool IsEmpty { get; private set; }

            public static Result Empty = new Result { IsEmpty = true };

            private Result() { }

            public Result(LeaderboardModel leaderboard)
            {
                Leaderboard = leaderboard;
            }
        }
    }
}
