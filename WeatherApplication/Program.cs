using MediatR;
using System.Reflection;
using WeatherApplication.Business;
using WeatherApplication.Data.Impl.Repository;
using WeatherApplication.Data.Impl.Services;
using WeatherApplication.Data.Intf.Repository;
using WeatherApplication.Data.Intf.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITemperatureService, TemperatureService>();
builder.Services.AddScoped<ISummaryRepository, SummaryRepository>();

builder.Services.AddMediatR(typeof(RetrieveWeatherForecastHandler));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
