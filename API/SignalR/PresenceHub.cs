using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class PresenceHub : Hub
    {
        public override async Task OnConnectedAsync(){
            await Clients.Others.SendAsync("UsuarioOn", Context.User?.GetUsername());
        }

        public override async Task OnDisconnectedAsync(Exception? exception){
            await Clients.Others.SendAsync("UsuarioOff", Context.User?.GetUsername());

            await base.OnDisconnectedAsync(exception);
        }
    }
}