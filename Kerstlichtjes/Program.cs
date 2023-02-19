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

            Console.WriteLine($"Connected with ip address {GetIpAddress()}");

            ServiceProvider services = ConfigureServices();
            using (var webServer = new KerstlichtjesWebServer(80, HttpProtocol.Http, new Type[] { typeof(IndexController) }, services))
            {
                webServer.Start();
                Thread.Sleep(Timeout.Infinite);
            }
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(typeof(ILoggerFactory), typeof(DebugLoggerFactory))
                .AddSingleton(typeof(IBlinkService), typeof(BlinkService))
                .AddSingleton(typeof(Application))
                .BuildServiceProvider();
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
