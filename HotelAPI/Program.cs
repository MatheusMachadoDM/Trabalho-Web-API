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

// Cadastro de Reserva já com o hospede junto 
app.MapPost("/HotelAPI/reserva", ([FromBody] Reserva reserva, [FromServices] AppDataContext context) => {
    
    Hospede? hospede = context.Hospedes.FirstOrDefault(h => h.CPF == reserva.Hospede.CPF); // procurando o hospede por cpf, a funcao retorna o primeiro registro que der match ou retorna null caso nao encontre

        if(hospede == null){
            context.Hospedes.Add(reserva.Hospede);// inserindo o registro hospede na tabela
        }

        context.Reservas.Add(reserva); // inserindo o registro  reserva na tabela

        context.SaveChanges();
        return Results.Created("", reserva);
});

// Lista todas as reservas
app.MapGet("/HotelAPI/reserva", ([FromServices] AppDataContext context) => {
    if(context.Reservas.Any()){            // Necessário o include, pois o campo Hospede, aparecia como null.
        return Results.Ok(context.Reservas.Include(r => r.Hospede).ToList()); //Isso ocorre, pois aparentemente o ef core não carrega dados relacionados automaticamente
    }

    return Results.NotFound();
});

/*// Buscar uma reserva específica por Id
app.MapGet("/HotelAPI/reserva{ReservaId}", ([FromRoute] int ReservaId, [FromServices] AppDataContext context) => {
    Reserva? reserva = context.Reservas.Include(r => r.Hospede).FirstOrDefault(r => r.ReservaId == ReservaId); // Precisei utilizar o FirstOrDefault, pois o Find aparentemente
                                                                                                               // não permite utilizar o Include      

    if(reserva != null){
        return Results.Ok(reserva);
    }

    return Results.NotFound();
});*/

// Lista todas as reservas atribuidas a um cpf específico
app.MapGet("/HotelAPI/reserva/hospede{CPF}", ([FromRoute] long CPF, [FromServices] AppDataContext context) => {
    var reservasHospede = context.Reservas.Include(r => r.Hospede).Where(r => r.Hospede.CPF == CPF).ToList();

    if(reservasHospede.Any()){
        return Results.Ok(reservasHospede);
    }

    return Results.NotFound();
});

// Lista todos os clientes 
app.MapGet("/HotelAPI/hospede", ([FromServices] AppDataContext context) => {
    if(context.Hospedes.Any()){
        return Results.Ok(context.Hospedes.ToList());
    }

    return Results.NotFound();
});

// Buscar um Hospede específico por CPF
app.MapGet("/HotelAPI/hospede{CPF}", ([FromRoute] long CPF, [FromServices] AppDataContext context) => {
    Hospede? hospede = context.Hospedes.FirstOrDefault(h => h.CPF == CPF);

    if(hospede != null){
        return Results.Ok(hospede);
    }

    return Results.NotFound();
});

 app.Run();