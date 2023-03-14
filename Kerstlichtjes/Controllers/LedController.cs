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
        [Method("POST")]
        public void PostOn(WebServerEventArgs e)
        {
            _ledService.On();
            e.Context.Response.ContentType = "text/plain";
            WebServer.OutPutStream(e.Context.Response, "on");
        }

        [Route("/off")]
        [Method("POST")]
        public void PostOff(WebServerEventArgs e)
        {
            _ledService.Off();
            e.Context.Response.ContentType = "text/plain";
            WebServer.OutPutStream(e.Context.Response, "off");
        }
    }
}