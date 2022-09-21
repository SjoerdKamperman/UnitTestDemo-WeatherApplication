using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Business;

namespace WeatherApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new RetrieveWeatherForecastCommand());

            if (result.Success)
                return Ok(result.WeatherForecasts);

            return BadRequest();
        }
    }
}