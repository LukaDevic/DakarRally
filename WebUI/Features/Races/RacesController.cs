using Application.Features.Races.Commands;
using Application.Features.Races.Models;
using Application.Features.Races.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Races.Models;

namespace WebUI.Controllers
{
    public class RacesController : ApiControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateRace(CreateRaceModel createModel)
        {
            //TODO: Restriction to disable multiple races creation
            var model = new RaceModel { Year = createModel.Year };
            var id = await Mediator.Send(new CreateRace.Command(model));
            var raceResult = await Mediator.Send(new GetRace.Query());
            return Ok(raceResult.Race);
        }
    }
}
