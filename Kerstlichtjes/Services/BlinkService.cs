using System;
using System.Threading;
using System.Device.Gpio;

namespace Kerstlichtjes.Services
{
    public class BlinkService : IBlinkService
    {
        private Thread _thread;
        private GpioController _gpioController;

        public BlinkService()
        {
            _gpioController = new GpioController();
        }

        public void StartBlinking(int pinNumber)
        {
            GpioPin led = _gpioController.OpenPin(pinNumber, PinMode.Output);

            led.Write(PinValue.Low);

            _thread = new Thread(() =>
            {
                while (true)
                {
                    led.Toggle();
                    Thread.Sleep(500);
                    led.Toggle();
                    Thread.Sleep(1500);
                }
            });

            _thread.Start();
        }

        public void StopBlinking()
        {
            _thread.Abort();
        }
    }
}