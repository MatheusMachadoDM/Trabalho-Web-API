using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

public class Quarto {
    [Key] // primary key
    public int QuartoId { get; set;}
    public int Numero { get; set;}
    public int Capacidade  { get; set;}
    public float Preco { get; set;}

}