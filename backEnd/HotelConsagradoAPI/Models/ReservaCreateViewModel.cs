// Esta classe é especificamente projetada para coletar os dados necessários para criar uma nova reserva. Ela representa os campos que um usuário precisa fornecer ao solicitar a criação de uma nova reserva
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelConsagradoAPI.Models
{
    public class ReservaCreateViewModel
    {
        [Required]
        public DateTime DataCheckIn { get; set; }
        [Required]
        public DateTime DataCheckOut { get; set; }
        [Required]
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public int QuantidadeQuartos { get; set; }
        [Required]
        [MaxLength(100)]
        public string NomeResponsavel { get; set; }
        [Required]
        [EmailAddress]
        public string EmailResponsavel { get; set; }
        [Required]
        [Phone]
        public string TelefoneResponsavel { get; set; }
    }
}