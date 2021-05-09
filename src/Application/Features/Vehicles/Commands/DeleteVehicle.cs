using Application.Features.Vehicles.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands
{
    public static class DeleteVehicle
    {
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IVehicleRepository _repository;

            public Handler(IVehicleRepository repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var id = await _repository.DeleteAsync(command.Id);
                return id;
            }
        }

        public class Command : IRequest<int>
        {
            public Command(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
