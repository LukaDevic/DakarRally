using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Features.Vehicles.Models;
using WebUI.Features.Vehicles.Models;
using Application.Features.Vehicles.Commands;
using Application.Features.Races.Queries;
using Application.Features.Vehicles.Queries;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ApiControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddVehicle(CreateVehicleModel createModel)
        {
            await Mediator.Send(new CreateVehicleAndAddToRace.Command(MapCreateModel(createModel))); ;
            var race = await Mediator.Send(new GetRace.Query(createModel.RaceId));
            return Ok(race);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVehicle(UpdateVehicleModel updateModel)
        {
            var result = await Mediator.Send(new GetVehicle.Query(updateModel.Id));
            if (result.IsEmpty)
            {
                return NotFound();
            }

            await Mediator.Send(new EditVehicle.Command(MapUpdateModel(updateModel, result.Vehicle)));
            var race = await Mediator.Send(new GetRace.Query(result.Vehicle.RaceId));
            return Ok(race);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var raceId = await Mediator.Send(new DeleteVehicle.Command(id));
            var race = await Mediator.Send(new GetRace.Query(raceId));
            return Ok(race);
        }

        private VehicleModel MapCreateModel(CreateVehicleModel createModel)
        {
            var model = new VehicleModel
            {
                RaceId = createModel.RaceId,
                TeamName = createModel.TeamName,
                VehicleType = createModel.VehicleType,
                VehicleSubType = createModel.VehicleSubType
            };
            return model;
        }

        private VehicleModel MapUpdateModel(UpdateVehicleModel updateModel, VehicleModel model)
        {
            model.TeamName = updateModel.TeamName;
            model.VehicleType = updateModel.VehicleType;
            model.VehicleSubType = updateModel.VehicleSubType;
            return model;
        }
    }
}
