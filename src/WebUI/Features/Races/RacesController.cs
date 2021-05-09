using Application.Features.Leaderboards.Commands;
using Application.Features.Leaderboards.Queries;
using Application.Features.Races.Commands;
using Application.Features.Races.Models;
using Application.Features.Races.Queries;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Races.Models;

namespace WebUI.Controllers
{
    public class RacesController : ApiControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRaceStatus(int id)
        {
            var result = await Mediator.Send(new GetRaceStatus.Query(id));
            if (result.IsEmpty)
            {
                return NotFound();
            }

            return Ok(result.RaceStatus);
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateRace(CreateRaceModel createModel)
        {
            var model = new RaceModel { Year = createModel.Year };
            var id = await Mediator.Send(new CreateRace.Command(model));
            var raceResult = await Mediator.Send(new GetRace.Query(id));
            return Ok(raceResult.Race);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> StartRace(int id)
        {
            var raceResult = await Mediator.Send(new SetRaceStatus.Command(id, RaceStatus.running));
            var leaderboardId = await Mediator.Send(new CreateLeaderboard.Command(raceResult.Race));
            var finishedRaceResult = await Mediator.Send(new SetRaceStatus.Command(id, RaceStatus.finished));
            var leaderboardResult = await Mediator.Send(new GetLeaderboard.Query(leaderboardId));
            return Ok(leaderboardResult.Leaderboard);
        }
    }
}
