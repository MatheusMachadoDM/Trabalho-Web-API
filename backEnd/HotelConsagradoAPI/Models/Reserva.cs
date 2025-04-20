// Models/Reserva.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HotelConsagradoAPI.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        [AllowNull]
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

        public ICollection<Hospede> Hospedes { get; set; }
    }
}