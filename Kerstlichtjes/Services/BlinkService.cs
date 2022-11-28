using System;
using System.Threading;
using System.Device.Gpio;
using Microsoft.Extensions.Logging;

namespace Kerstlichtjes.Services
{
    public class BlinkService : IBlinkService
    {
        private ILogger _logger;
        private Thread _thread;
        private GpioController _gpioController;

        public BlinkService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(BlinkService));
            _gpioController = new GpioController();
        }

        public void StartBlinking(int pinNumber)
        {
            GpioPin led = _gpioController.OpenPin(pinNumber, PinMode.Output);

            led.Write(PinValue.Low);

            _logger.LogInformation($"Start blinking on LED {pinNumber}");
            _thread = new Thread(() =>
            {
                while (true)
                {
                    _logger.LogInformation($"LED {pinNumber} on");
                    led.Toggle();
                    Thread.Sleep(500);

                    _logger.LogInformation($"LED {pinNumber} off");
                    led.Toggle();
                    Thread.Sleep(1500);
                }
            });

            _thread.Start();
        }

        public void StopBlinking()
        {
            _logger.LogInformation("Stop blinking");
            _thread.Abort();
        }
    }
}