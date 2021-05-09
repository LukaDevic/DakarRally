using Application.Features.Leaderboards.Interfaces;
using Application.Features.Leaderboards.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leaderboards.Queries
{
    public static class GetLeaderboard
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
                var leaderboard = await _repository.GetLeaderboardAsync(query.Id);
                return leaderboard != null
                    ? new Result(leaderboard)
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
