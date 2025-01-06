using Microsoft.AspNetCore.SignalR;

namespace ShopTARgv23.Hubs
{
    public class ChatHub : Hub
    {
        public static int TotalViews { get; set; } = 0;

        public async Task NewWindowLoaded()
        {
            TotalViews++;
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

/*
Package Manager Console:
    PM> npm init -y
        Wrote to C:\Users\darja\source\repos\Shop\ShopTARgv23\package.json:

        {
          "name": "shoptargv23",
          "version": "1.0.0",
          "main": "index.js",
          "scripts": {
            "test": "echo \"Error: no test specified\" && exit 1"
          },
          "keywords": [],
          "author": "",
          "license": "ISC",
          "description": ""
        }
    PM> npm install @microsoft/signalr

        added 18 packages, and audited 19 packages in 3s

        1 package is looking for funding
          run `npm fund` for details

        found 0 vulnerabilities
    PM> npm fund?????? 
*/