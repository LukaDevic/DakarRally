using Application.Features.Leaderboards.Queries;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class LeaderboardsController : ApiControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLeaderboardByType(VehicleType vehicleType)
        {
            var result = await Mediator.Send(new GetLeaderboardByType.Query(vehicleType));
            if (result.IsEmpty)
            {
                return NotFound();
            }

            return Ok(result.Leaderboard);
        }
    }
}
