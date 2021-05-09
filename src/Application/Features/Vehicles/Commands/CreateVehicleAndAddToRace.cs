using Application.Features.Races.Commands;
using Application.Features.Vehicles.Interfaces;
using Application.Features.Vehicles.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands
{
    public static class CreateVehicleAndAddToRace 
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly IVehicleRepository _repository;
            private readonly IMediator _mediator;

            public Handler(IVehicleRepository repository, IMediator mediator)
            {
                _repository = repository;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var id = await _repository.CreateVehicleAsync(command.Vehicle);
                await _mediator.Send(new AddVehicleToRace.Command(id));
                return Unit.Value;
            }
        }

        public class Command : IRequest
        {
            public VehicleModel Vehicle { get; }

            public Command(VehicleModel vehicle)
            {
                Vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
            }
        }
    }
}
