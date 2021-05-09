using Application.Features.Vehicles.Interfaces;
using Application.Features.Vehicles.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands
{
    public static class EditVehicle
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
                await _repository.UpdateAsync(command.Vehicle);
                return Unit.Value;
            }
        }

        public class Command : IRequest
        {
            public Command(VehicleModel vehicle)
            {
                Vehicle = vehicle;
            }

            public VehicleModel Vehicle { get; }
        }
    }
}
