using System.Device.Gpio;
using System;
using System.Threading;

namespace Kerstlichtjes
{
    public class Program
    {
        private static GpioController s_GpioController;

        public static void Main()
        {
            s_GpioController = new GpioController();

            GpioPin led = s_GpioController.OpenPin(5, PinMode.Output);

            led.Write(PinValue.Low);

            while (true)
            {
                led.Toggle();
                Thread.Sleep(100);
                led.Toggle();
                Thread.Sleep(3900);
            }
        }
    }
}
