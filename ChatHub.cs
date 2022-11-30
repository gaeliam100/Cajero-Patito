using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace proyecto_aula
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string rol,string user, string message)
        {
           // await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
            await Clients.All.SendAsync("ReceiveMessage", rol ,user, message);

        }
        //public async Task AddToGroup(string room)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, room);
        //    await Clients.Group(room).SendAsync("ShowWho",
        //        $"Alguien se conecto{ Context.ConnectionId}");
        //}
    }
}
