using System;
using Kerstlichtjes.Services;

namespace Kerstlichtjes
{
    internal class Application
    {
        private readonly IBlinkService _blinkService;
        private readonly IServiceProvider _serviceProvider;

        public Application(IServiceProvider serviceProvider, IBlinkService blinkService)
        {
            _serviceProvider = serviceProvider;
            _blinkService = blinkService;
        }

        public void Run()
        {
            var pinNumber = 5;

            _blinkService.StartBlinking(pinNumber);
        }
    }
}