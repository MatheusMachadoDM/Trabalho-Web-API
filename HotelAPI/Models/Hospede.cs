using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models;

public class Hospede{
    public int HospedeId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Telefone { get; set; }
    public List<Reserva> Reservas { get; set; }
}