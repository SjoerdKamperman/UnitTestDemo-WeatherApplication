using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.Data.Intf.Services
{
    public interface ITemperatureService
    {
        Task<int> GetTemperatureAsync();
    }
}
