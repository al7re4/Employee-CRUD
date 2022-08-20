using Employee_CRUD.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Employee_CRUD.Data
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendOffersToUser(Models.EmpModel.Messages messages)
        {
            await Clients.All.SendMessage(messages);
        }
    }
}
