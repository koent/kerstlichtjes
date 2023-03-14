namespace Kerstlichtjes.Services
{
    public interface ILedService
    {
        public void On();

        public void Off();

        public void Flash(int durationInMs = 150);
    }
}