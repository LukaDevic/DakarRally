using Application.Features.Races.Interfaces;
using Application.Features.Vehicles.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Races.Commands
{
    public static class AddVehicleToRace
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly IRaceRepository _repository;

            public Handler(IRaceRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                await _repository.AddVehicleAsync(command.Id);
                return Unit.Value;
            }
        }

        public class Command : IRequest
        {
            public int Id { get;  }

            public Command(int id)
            {
                Id = id;
            }
        }
    }
}
