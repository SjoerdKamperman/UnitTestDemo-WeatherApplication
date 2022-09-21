using WeatherApplication.Data.Intf.Services;

namespace WeatherApplication.Data.Impl.Services
{
    public class TemperatureService : ITemperatureService
    {
        public async Task<int> GetTemperatureAsync()
        {
            await Task.Delay(1000);
            return Random.Shared.Next(-20, 55);
        }
    }
}
