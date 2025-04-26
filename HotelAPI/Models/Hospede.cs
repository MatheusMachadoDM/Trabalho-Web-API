using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

public class Hospede{
    [Key] // primary key
    public int HospedeId { get; set; }
    public string Nome { get; set; }

    //[MaxLength(11)]
    public long CPF { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    [System.Text.Json.Serialization.JsonIgnore] //ignorar propriedade no swagger
    public virtual List<Reserva>? Reservas { get; set; }
}