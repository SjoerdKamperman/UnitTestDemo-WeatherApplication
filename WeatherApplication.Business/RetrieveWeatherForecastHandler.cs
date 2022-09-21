using MediatR;
using Microsoft.Extensions.Logging;
using WeatherApplication.Business.Models;
using WeatherApplication.Data.Intf.Repository;
using WeatherApplication.Data.Intf.Services;

namespace WeatherApplication.Business
{
    public class RetrieveWeatherForecastCommand : IRequest<RetrieveWeatherForecastResponse>
    {
    }

    public class RetrieveWeatherForecastResponse
    {
        public bool Success { get; set; }
        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }

        public RetrieveWeatherForecastResponse(bool success, IEnumerable<WeatherForecast> weatherForecasts)
        {
            Success = success;
            WeatherForecasts = weatherForecasts;
        }
    }

    public class RetrieveWeatherForecastHandler : IRequestHandler<RetrieveWeatherForecastCommand, RetrieveWeatherForecastResponse>
    {
        private readonly ILogger<RetrieveWeatherForecastHandler> _logger;
        private readonly ITemperatureService _temperatureService;
        private readonly ISummaryRepository _summaryRepository;

        public RetrieveWeatherForecastHandler(ILogger<RetrieveWeatherForecastHandler> logger, ITemperatureService temperatureService, ISummaryRepository summaryRepository)
        {
            _logger = logger;
            _temperatureService = temperatureService;
            _summaryRepository = summaryRepository;
        }

        public async Task<RetrieveWeatherForecastResponse> Handle(RetrieveWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = (await Task.WhenAll(Enumerable.Range(1, 5).Select(async index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = await _temperatureService.GetTemperatureAsync(),
                    Summary = _summaryRepository.GetSummary(),
                }))).ToArray();

                return new RetrieveWeatherForecastResponse(true, result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve weatherforecast. Exception: {ex}");
                return new RetrieveWeatherForecastResponse(false, null);
            }
        }
    }
}
