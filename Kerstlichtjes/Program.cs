using System;
using nanoFramework.DependencyInjection;
using Kerstlichtjes.Services;

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
            .AddSingleton(typeof(Application))
            .AddSingleton(typeof(IBlinkService), typeof(BlinkService))
            .BuildServiceProvider();
        }
    }
}
