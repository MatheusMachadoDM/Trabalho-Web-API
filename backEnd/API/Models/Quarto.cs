namespace API.Models;

public class Quarto{
    public int Id { get; set;}
    public int Capacidade { get; set;}

    public List<Reserva>? Reservas { get; set;} //Um quarto pode ter várias reservas ao longo do tempo
}

