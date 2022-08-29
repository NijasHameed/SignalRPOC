using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRPOC.Hubs;
using SignalRPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPOC.Controllers
{
    public class ServerController : Controller
    {
        private readonly IHubContext<NotificationHub> _notificationHub;
        public ServerController(IHubContext<NotificationHub> notificationHub)
        {
            _notificationHub = notificationHub;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Notification model)
        {
            await _notificationHub.Clients.All.SendAsync("RecieveMsg", model.Message);
            return View();
        }

    }
}
