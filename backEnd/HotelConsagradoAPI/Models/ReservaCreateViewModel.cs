// Models/ReservaCreateViewModel.cs
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