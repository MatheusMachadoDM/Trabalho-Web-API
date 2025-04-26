namespace HotelAPI.Models;

public class Reserva{
    public int ReservaId { get; set; }
    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    public int HospedeId { get; set; }
    public Hospede Hospede { get; set; }
    public int QuartoId { get; set; }
}