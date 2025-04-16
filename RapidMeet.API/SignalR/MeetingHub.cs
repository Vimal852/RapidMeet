using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace RapidMeet.API.SignalR
{
    public class MeetingHub : Hub<IMeetingClient>
    {
        public async Task JoinMeeting(string meetingId, string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, meetingId);
            await Clients.Group(meetingId).UserJoined(userId);
        }

        public async Task LeaveMeeting(string meetingId, string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, meetingId);
            await Clients.Group(meetingId).UserLeft(userId);
        }
    }

}
