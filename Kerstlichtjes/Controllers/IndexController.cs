using System;
using nanoFramework.WebServer;

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
            var content = "Hello, World!";
            e.Context.Response.ContentType = "text/plain";
            WebServer.OutPutStream(e.Context.Response, content);
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