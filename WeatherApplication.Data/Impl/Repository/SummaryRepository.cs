using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Data.Intf.Repository;

namespace WeatherApplication.Data.Impl.Repository
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly string[] _summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public string GetSummary()
        {
            return _summaries[Random.Shared.Next(_summaries.Length)];
        }
    }
}
