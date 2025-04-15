namespace API.Models;

public class Reserva{
    public int Id { get; set;}
    public string Cliente { get; set;}
    public string Email { get; set;}
    public int Fone { get; set;}
    public DateTime CriadoEm { get; set;}
    public DateOnly DataReserva { get; set;}

    public int QuartoId { get; set; }
    public Quarto Quarto { get; set; } //Cada Reserva possuí apenas um quarto por enquanto para simplificar, talvez alterar no futuro para que possam ter mais de 1 quarto por reserva
    public Reserva(){
        this.CriadoEm = DateTime.Now;
    }
}
