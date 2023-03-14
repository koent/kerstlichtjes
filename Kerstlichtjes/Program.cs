using System;
using System.Net.NetworkInformation;
using System.Threading;
using Kerstlichtjes.Controllers;
using Kerstlichtjes.Services;
using Kerstlichtjes.Configuration;
using nanoFramework.DependencyInjection;
using nanoFramework.Logging.Debug;
using nanoFramework.Networking;
using nanoFramework.WebServer;
using Microsoft.Extensions.Logging;

namespace Kerstlichtjes
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine();
            Console.WriteLine($"Connecting to {SecretConstants.WiFiSsid}... ");
            var cs = new CancellationTokenSource(60_000);
            var succes = WifiNetworkHelper.ConnectDhcp(
                SecretConstants.WiFiSsid,
                SecretConstants.WiFiPassword,
                requiresDateTime: true,
                token: cs.Token);

            if (!succes)
            {
                Console.WriteLine($"Failed: {WifiNetworkHelper.Status}.");
                if (WifiNetworkHelper.HelperException != null)
                    Console.WriteLine($"Exception: {WifiNetworkHelper.HelperException}");
                return;
            }

            Console.WriteLine($"Connected");

            ServiceProvider services = ConfigureServices();
            int port = 80;
            using (var webServer = new KerstlichtjesWebServer(port, HttpProtocol.Http, new Type[] { typeof(IndexController), typeof(LedController) }, services))
            {
                ServicesConfigured(services);
                Console.WriteLine($"Listening on http://{GetIpAddress()}:{port}/");
                webServer.Start();
                Thread.Sleep(Timeout.Infinite);
            }
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(typeof(ILoggerFactory), typeof(DebugLoggerFactory))
                .AddSingleton(typeof(ILedService), typeof(LedService))
                .BuildServiceProvider();
        }

        private static void ServicesConfigured(ServiceProvider services)
        {
            var ledService = services.GetService(typeof(ILedService)) as ILedService;
            ledService.Flash();
        }

        private static string GetIpAddress()
        {
            var nis = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in nis)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    return ni.IPv4Address;
            }
            throw new Exception("No suitable network interface found");
        }
    }
}
