using System;
using nanoFramework.WebServer;
using Kerstlichtjes.Configuration;

namespace Kerstlichtjes.Controllers
{
    public class IndexController
    {
        public IndexController()
        {
        }

        [Route("/")]
        [Method("GET")]
        public void GetIndex(WebServerEventArgs e)
        {
            e.Context.Response.ContentType = "text/html";
            WebServer.OutPutStream(e.Context.Response, Frontend.Value);
        }

        [Route("/time")]
        [Method("GET")]
        public void GetRoot(WebServerEventArgs e)
        {
            var content = DateTime.UtcNow.ToString("s");
            e.Context.Response.ContentType = "text/plain";
            WebServer.OutPutStream(e.Context.Response, content);
        }
    }
}