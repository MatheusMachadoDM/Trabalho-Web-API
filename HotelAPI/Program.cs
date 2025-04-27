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
app.MapPost("/HotelAPI/reserva", ([FromBody] Reserva reserva, [FromServices] AppDataContext context) => { //FromBody indica que o parâmetro será recebido do corpo da requisição (Dados no formato JSON)
    if(reserva == null || reserva.Hospede == null){
        return Results.BadRequest("Dados de reserva e hóspede são obrigatórios.");
    }

    Hospede? hospedeExistente = context.Hospedes.FirstOrDefault(h => h.CPF == reserva.Hospede.CPF);

    if(hospedeExistente == null){
        context.Hospedes.Add(reserva.Hospede);
        context.SaveChanges();
        reserva.HospedeId = reserva.Hospede.HospedeId;
    } else{
        reserva.HospedeId = hospedeExistente.HospedeId;
        reserva.Hospede = hospedeExistente;
    }

    context.Reservas.Add(reserva);
    context.SaveChanges();
    return Results.Created("", reserva);
});
   /* Hospede? hospede = context.Hospedes.FirstOrDefault(h => h.CPF == reserva.Hospede.CPF); // procurando o hospede por cpf, a funcao retorna o primeiro registro que der match ou retorna null caso nao encontre

        if(hospede == null){
            context.Hospedes.Add(reserva.Hospede);// inserindo o registro hospede na tabela
        }

        context.Reservas.Add(reserva); // inserindo o registro  reserva na tabela

        context.SaveChanges();
        return Results.Created("", reserva);
});
*/
// Lista todas as reservas
app.MapGet("/HotelAPI/reserva", ([FromServices] AppDataContext context) => {
    if(context.Reservas.Any()){            // Necessário o include, pois o campo Hospede, aparecia como null.
        return Results.Ok(context.Reservas.Include(r => r.Hospede).ToList()); //Isso ocorre, pois aparentemente o ef core não carrega dados relacionados automaticamente
    }

    return Results.NotFound();
});

// Buscar uma reserva específica por Id
app.MapGet("/HotelAPI/reserva{ReservaId}", ([FromRoute] int ReservaId, [FromServices] AppDataContext context) => {
    Reserva? reserva = context.Reservas.Include(r => r.Hospede).FirstOrDefault(r => r.ReservaId == ReservaId); // Precisei utilizar o FirstOrDefault, pois o Find aparentemente
                                                                                                               // não permite utilizar o Include      

    if(reserva != null){
        return Results.Ok(reserva);
    }

    return Results.NotFound();
});

// Lista todas as reservas atribuidas a um cpf específico
app.MapGet("/HotelAPI/reserva/hospede{CPF}", ([FromRoute] string CPF, [FromServices] AppDataContext context) => { //FromRoute significa que o parâmetro CPF será fornecido na URL da requisição
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
app.MapGet("/HotelAPI/hospede{CPF}", ([FromRoute] string CPF, [FromServices] AppDataContext context) => {
    Hospede? hospede = context.Hospedes.FirstOrDefault(h => h.CPF == CPF);

    if(hospede != null){
        return Results.Ok(hospede);
    }

    return Results.NotFound();
});

// Atualiza reserva por Id
app.MapPut("/HotelAPI/reserva{ReservaId}", ([FromRoute] int ReservaId, [FromBody] Reserva reserva, [FromServices] AppDataContext context) => {
    Reserva? res = context.Reservas.Include(r => r.Hospede).FirstOrDefault(r => r.ReservaId == ReservaId);

    if(res == null){
        return Results.NotFound();
    }

    
    res.CheckIn = reserva.CheckIn;
    res.CheckOut = reserva.CheckOut;

    if(reserva.Hospede != null && res.Hospede != null){
        if(!string.IsNullOrEmpty(reserva.Hospede.Nome)){ // Validação para garantir que a string não é nula nem vazia antes de alterar algo
            res.Hospede.Nome = reserva.Hospede.Nome;
        }
        if(!string.IsNullOrEmpty(reserva.Hospede.Email)){
            res.Hospede.Email = reserva.Hospede.Email;  
        }
        if(!string.IsNullOrEmpty(reserva.Hospede.Telefone)){
            res.Hospede.Telefone = reserva.Hospede.Telefone;
        }
    }

    context.SaveChanges();
    return Results.Ok(res);
});

// Atualiza Hospede por Id
app.MapPut("/HotelAPI/hospede{HospedeId}", ([FromRoute] int HospedeId, [FromBody] Hospede hospede, [FromServices] AppDataContext context) => {
    Hospede? hos = context.Hospedes.Find(HospedeId);

    if(hos != null){
        hos.CPF = hospede.CPF;
        if(!string.IsNullOrEmpty(hospede.Nome)){
            hos.Nome = hospede.Nome;
        }
        if(!string.IsNullOrEmpty(hospede.Email)){
            hos.Email = hospede.Email;
        }
        if(!string.IsNullOrEmpty(hospede.Telefone)){
            hos.Telefone = hospede.Telefone;
        }

        context.SaveChanges();
        return Results.Ok(hos);
    }

    return Results.NotFound();
});

// Deleta Reserva por Id
app.MapDelete("/HotelAPI/reserva{ReservaId}", ([FromRoute] int ReservaId, [FromServices] AppDataContext context) => {
    Reserva? reserva = context.Reservas.Find(ReservaId);

    if(reserva == null){
        return Results.NotFound();  
    }

    context.Reservas.Remove(reserva);
    context.SaveChanges();
    return Results.NoContent();
});

//Deleta Hospede por Id
app.MapDelete("/HotelAPI/hospede{HospedeId}", ([FromRoute] int HospedeId, [FromServices] AppDataContext context) => {
    Hospede? hospede = context.Hospedes.Find(HospedeId);

    if(hospede == null){
        return Results.NotFound();
    }

    context.Hospedes.Remove(hospede);
    context.SaveChanges();
    return Results.NoContent();
});

 app.Run();