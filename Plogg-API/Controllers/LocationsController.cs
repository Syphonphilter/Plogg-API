using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Plogg_API.Hubs;
using Plogg_API.Models;

namespace Plogg_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IHubContext<LocationHub> _hubContext;

        public LocationController(IHubContext<LocationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        private Timer _timer;
        [HttpPost]
        public async Task<IActionResult> Post(LocationModel location)
        {
            LocationHub.LatestLocation = location;

            if (_timer == null)
            {
                _timer = new Timer(async (state) =>
                {
                    await _hubContext.Clients.All.SendAsync("ReceiveLocation", LocationHub.LatestLocation);
                }, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(LocationHub.LatestLocation);
        }
    }
}

