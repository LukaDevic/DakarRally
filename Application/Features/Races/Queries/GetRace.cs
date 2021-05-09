using Application.Features.Races.Interfaces;
using Application.Features.Races.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Races.Queries
{
    public static class GetRace
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
                return race != null
                    ? new Result(race)
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
            public RaceModel Race { get; }

            public bool IsEmpty { get; set; }

            public static Result Empty = new Result { IsEmpty = true };

            private Result() { }

            public Result(RaceModel race)
            {
                Race = race;
            }
        }
    }
}
