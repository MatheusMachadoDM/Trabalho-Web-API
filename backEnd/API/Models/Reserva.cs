namespace API.Models;

public class Reserva{
    public int Id { get; set;}
    public string Cliente { get; set;}
    public string Email { get; set;}
    public int Fone { get; set;}
    public DateTime CriadoEm { get; set;}
    public DateOnly DataReserva { get; set;}

    public Reserva(){
        this.CriadoEm = DateTime.Now;
    }
}
