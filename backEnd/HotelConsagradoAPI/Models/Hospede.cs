// Hospede.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelConsagradoAPI.Models
{
    public class Hospede
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do Hóspede é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O Nome do Hóspede não pode exceder 20 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sobrenome do Hóspede é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Sobrenome do Hóspede não pode exceder 50 caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento do Hóspede é obrigatória.")]
        public DateOnly DataNascimento { get; set; }

        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }
        public Reserva? Reserva { get; set; }
    }
}