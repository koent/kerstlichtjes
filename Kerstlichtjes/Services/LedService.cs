using System;
using System.Threading;
using System.Device.Gpio;

namespace Kerstlichtjes.Services
{
    public class LedService : ILedService
    {
        private readonly GpioController _gpioController;

        private const int pinNumber = 5;

        private readonly GpioPin _led;

        public LedService()
        {
            _gpioController = new GpioController();
            _led = _gpioController.OpenPin(pinNumber, PinMode.Output);
        }

        public void On()
        {
            _led.Write(PinValue.High);
        }

        public void Off()
        {
            _led.Write(PinValue.Low);
        }

        public void Flash(int durationInMs)
        {
            _led.Toggle();
            Thread.Sleep(durationInMs);
            _led.Toggle();
        }
    }
}