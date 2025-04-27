using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Models;

public class Reserva{
    [Key] // primary key
    public int ReservaId { get; set; }
    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    
    [ForeignKey("Hospede")]
    [System.Text.Json.Serialization.JsonIgnore] //ignorar propriedade no swagger
    public int HospedeId { get; set; }
    public virtual Hospede Hospede { get; set; }
    // virutal cria a foreign key
}