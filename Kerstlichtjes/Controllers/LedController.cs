using System;
using nanoFramework.WebServer;
using Kerstlichtjes.Services;

namespace Kerstlichtjes.Controllers
{
    public class LedController
    {

        private readonly ILedService _ledService;

        public LedController(ILedService ledService)
        {
            _ledService = ledService;
        }

        [Route("/on")]
        [Method("GET")]
        public void PostOn(WebServerEventArgs e)
        {
            _ledService.On();
        }

        [Route("/off")]
        [Method("GET")]
        public void PostOff(WebServerEventArgs e)
        {
            _ledService.Off();
        }
    }
}