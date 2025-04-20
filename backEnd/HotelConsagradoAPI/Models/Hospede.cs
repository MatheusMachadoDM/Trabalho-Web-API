// Models/Hospede.cs
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelConsagradoAPI.Models
{
    public class Hospede
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }

        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }
        public Reserva? Reserva { get; set; }
    }
}