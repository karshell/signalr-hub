using Microsoft.AspNetCore.SignalR;

namespace SignalRHub
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
        public void JoinGroup(string groupName)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
