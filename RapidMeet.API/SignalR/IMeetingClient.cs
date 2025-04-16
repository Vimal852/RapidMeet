namespace RapidMeet.API.SignalR
{

        public interface IMeetingClient
        {
            Task UserJoined(string userId);
            Task UserLeft(string userId);
        }

    
}
