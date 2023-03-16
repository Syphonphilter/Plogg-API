using Microsoft.AspNetCore.SignalR;
using Plogg_API.Models;
using System.Threading.Tasks;
namespace Plogg_API.Hubs
{
    public class LocationHub : Hub
    {
        public static LocationModel LatestLocation { get; set; }

        public override Task OnConnectedAsync()
        {
            return Clients.Caller.SendAsync("ReceiveLocation", LatestLocation);
        }

        public void UpdateLocation(LocationModel location)
        {
            LatestLocation = location;
        }
    }
}
