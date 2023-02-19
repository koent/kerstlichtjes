using System;
using System.Net;
using nanoFramework.DependencyInjection;
using nanoFramework.WebServer;

namespace Kerstlichtjes
{
    internal class KerstlichtjesWebServer : WebServer
    {
        private readonly IServiceProvider _serviceProvider;

        public KerstlichtjesWebServer(int port, HttpProtocol httpProtocol, Type[] controllers, IServiceProvider serviceProvider)
        : base(port, httpProtocol, controllers)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void InvokeRoute(CallbackRoutes route, HttpListenerContext context)
        {
            Console.WriteLine($"{route.Method} {route.Route}");
            route.Callback.Invoke(ActivatorUtilities.CreateInstance(_serviceProvider, route.Callback.DeclaringType), new object[] { new WebServerEventArgs(context) });
        }
    }
}