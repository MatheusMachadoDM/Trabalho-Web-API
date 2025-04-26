/*using HotelAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

public class ReservController : ControllerBase {
    private readonly AppDataContext context;
    public ReservController() {
        context = new AppDataContext();
    }

    [HttpPost]
    public async Task<IActionResult> PostReserva(DateOnly CheckIn, DateOnly Checkout, long CPF, string Nome, string Email, string Telefone){

        Reserva reserva = new Reserva();
        Hospede? hospede = context.Hospedes.FirstOrDefault(h => h.CPF == CPF); // procurando o hospede por cpf, a funcao retorna o primeiro registro que der match ou retorna null caso nao encontre

        if(hospede == null){
            hospede = new Hospede();
            hospede.CPF = CPF;
            hospede.Nome = Nome;
            hospede.Email = Email; 
            hospede.Telefone = Telefone;
            context.Hospedes.Add(hospede);// inserindo o registro hospede na tabela
        }

        reserva.CheckIn = CheckIn;
        reserva.CheckOut = Checkout;
        reserva.Hospede = hospede;
        context.Reservas.Add(reserva); // inserindo o registro  reserva na tabela

        int qtdeRegistros = await context.SaveChangesAsync();

        if(qtdeRegistros > 0){
            return Ok();
        }else{
            return BadRequest("Erro ao tentar incluir reserva");
        }
    }

}*/