using System;
using nanoFramework.DependencyInjection;
using nanoFramework.Logging.Debug;
using Kerstlichtjes.Services;
using Microsoft.Extensions.Logging;

namespace Kerstlichtjes
{
    public class Program
    {
        public static void Main()
        {
            ServiceProvider services = ConfigureServices();
            var application = (Application)services.GetRequiredService(typeof(Application));

            application.Run();
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(typeof(ILoggerFactory), typeof(DebugLoggerFactory))
                .AddSingleton(typeof(IBlinkService), typeof(BlinkService))
                .AddSingleton(typeof(Application))
                .BuildServiceProvider();
        }
    }
}
