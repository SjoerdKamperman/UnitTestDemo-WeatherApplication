using Moq;
using System;
using TechTalk.SpecFlow;
using WeatherApplication.Business;
using WeatherApplication.Data.Intf.Repository;
using WeatherApplication.Data.Intf.Services;

namespace WeatherApplication.Specs.StepDefinitions
{
    [Binding]
    public class WeatherForecastStepDefinitions
    {
        private readonly Mock<ITemperatureService> _temperatureService;
        private readonly Mock<ISummaryRepository> _summaryRepository;
        private readonly RetrieveWeatherForecastHandler _sut;

        private RetrieveWeatherForecastResponse _result;

        public WeatherForecastStepDefinitions()
        {
            _temperatureService = new Mock<ITemperatureService>(MockBehavior.Strict);
            _summaryRepository = new Mock<ISummaryRepository>(MockBehavior.Strict);
            _summaryRepository.Setup(x => x.GetSummary()).Returns("Cold");

            _sut = new RetrieveWeatherForecastHandler(_temperatureService.Object, _summaryRepository.Object);
        }

        [Given(@"the temperature in Celcius is (.*)")]
        public void GivenTheTemperatureInCelciusIs(int temperatureC)
        {
            _temperatureService.Setup(x => x.GetTemperatureAsync()).ReturnsAsync(temperatureC);
        }

        [When(@"the weatherforecast is retrieved")]
        public async void WhenTheWeatherforecastIsRetrieved()
        {
            _result = await _sut.Handle(new RetrieveWeatherForecastCommand(), new CancellationToken());
        }

        [Then(@"the weatherforecast should not be empty")]
        public void ThenTheWeatherforecastShouldNotBeEmpty()
        {
            _result.WeatherForecasts.Should().NotBeEmpty();            
        }


        [Then(@"the result should be (.*) Fahrenheit")]
        public void ThenTheResultShouldBeFahrenheit(int temperatureF)
        {
            _result.WeatherForecasts.First().TemperatureF.Should().Be(temperatureF);
        }
    }
}
