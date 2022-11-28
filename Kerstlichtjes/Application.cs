using System;
using Kerstlichtjes.Services;
using Microsoft.Extensions.Logging;

namespace Kerstlichtjes
{
    internal class Application
    {
        private readonly ILogger _logger;
        private readonly IBlinkService _blinkService;

        public Application(IBlinkService blinkService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(Application));
            _blinkService = blinkService;

            _logger.LogInformation("\nInitializing services");
        }

        public void Run()
        {
            var pinNumber = 5;

            _logger.LogInformation($"Blink on LED {pinNumber}");
            _blinkService.StartBlinking(pinNumber);
        }
    }
}