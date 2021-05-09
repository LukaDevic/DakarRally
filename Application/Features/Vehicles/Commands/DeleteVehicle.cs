using Application.Features.Vehicles.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands
{
    public static class DeleteVehicle
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly IVehicleRepository _repository;

            public Handler(IVehicleRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                await _repository.DeleteAsync(command.Id);
                return Unit.Value;
            }
        }

        public class Command : IRequest
        {
            public Command(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
