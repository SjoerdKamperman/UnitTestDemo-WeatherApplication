Feature: WeatherForecast

Scenario: Return temperature in Fahrenheit
	Given the temperature in Celcius is <TemperatureC>
	When the weatherforecast is retrieved
	Then the weatherforecast should not be empty
	And the result should be <TemperatureF> Fahrenheit

Examples:
	| TemperatureC | TemperatureF  |
	| -50          | -58           |
	| -5           | 23            |
	| 10           | 50            |
	| 19           | 66            |
	| 20           | 68            |