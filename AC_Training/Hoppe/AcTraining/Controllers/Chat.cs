using Microsoft.AspNet.SignalR;

namespace AcTraining.Controllers
{
    public class Chat : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}