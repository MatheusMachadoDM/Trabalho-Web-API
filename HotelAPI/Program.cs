using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
 // Add services to the container.
 // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();
 
 var app = builder.Build();
 
 // Configure the HTTP request pipeline.
 if (app.Environment.IsDevelopment())
 {
     app.UseSwagger();
     app.UseSwaggerUI();
 }
 
 app.UseHttpsRedirection();
 
 var summaries = new[]
 {
     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
 };
 
 app.MapGet("/weatherforecast", () =>
 {
     var forecast =  Enumerable.Range(1, 5).Select(index =>
         new WeatherForecast
         (
             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
             Random.Shared.Next(-20, 55),
             summaries[Random.Shared.Next(summaries.Length)]
         ))
         .ToArray();
     return forecast;
 })
 .WithName("GetWeatherForecast")
 .WithOpenApi();
 
app.MapPost("/HotelAPI/reserva", ([FromBody] Reserva reserva, [FromServices] AppDataContext context) => {
    
    Hospede? hospede = context.Hospedes.FirstOrDefault(h => h.CPF == reserva.Hospede.CPF); // procurando o hospede por cpf, a funcao retorna o primeiro registro que der match ou retorna null caso nao encontre

        if(hospede == null){
            context.Hospedes.Add(reserva.Hospede);// inserindo o registro hospede na tabela
        }

        context.Reservas.Add(reserva); // inserindo o registro  reserva na tabela

        context.SaveChanges();
        return Results.Created("", reserva);
});

 app.Run();
 
 record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
 {
     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
 }
/*using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();*/

