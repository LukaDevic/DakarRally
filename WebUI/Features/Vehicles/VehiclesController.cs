using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Features.Vehicles.Models;
using WebUI.Features.Vehicles.Models;
using Application.Features.Vehicles.Commands;
using Application.Features.Races.Queries;

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
            var model = new VehicleModel 
            { 
                TeamName = createModel.TeamName,
                VehicleType = createModel.VehicleType,
                VehicleSubType = createModel.VehicleSubType
            };
            var id = await Mediator.Send(new CreateVehicleAndAddToRace.Command(model));
            var race = await Mediator.Send(new GetRace.Query());
            return Ok(race);
        }
    }
}
