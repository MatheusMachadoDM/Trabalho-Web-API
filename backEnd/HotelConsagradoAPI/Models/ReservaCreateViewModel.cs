// ReservaCreateViewModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelConsagradoAPI.Models
{
    public class ReservaCreateViewModel
    {
        [Required(ErrorMessage = "A Data de Check-in é obrigatória.")]
        public DateOnly DataCheckIn { get; set; }

        [Required(ErrorMessage = "A Data de Check-out é obrigatória.")]
        public DateOnly DataCheckOut { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade de Adultos deve ser maior que zero.")]
        public int QuantidadeAdultos { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A Quantidade de Crianças não pode ser negativa.")]
        public int QuantidadeCriancas { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade de Quartos deve ser maior que zero.")]
        public int QuantidadeQuartos { get; set; }

        [Required(ErrorMessage = "O Nome do Responsável é obrigatório.")]
        [MaxLength(75, ErrorMessage = "O Nome do Responsável não pode exceder 75 caracteres.")]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "O Email do Responsável é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de Email inválido.")]
        [MaxLength(50, ErrorMessage = "O Email do Responsável não pode exceder 50 caracteres.")]
        public string EmailResponsavel { get; set; }

        [Required(ErrorMessage = "O Telefone do Responsável é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O Telefone do Responsável não pode exceder 20 caracteres.")]
        public string TelefoneResponsavel { get; set; }

        // Nova propriedade para incluir os hóspedes na criação da reserva
        public List<HospedeCreateViewModel>? Hospedes { get; set; }
    }

    // Novo ViewModel para criar hóspedes dentro da reserva
    public class HospedeCreateViewModel
    {
        [Required(ErrorMessage = "O Nome do Hóspede é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O Nome do Hóspede não pode exceder 20 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sobrenome do Hóspede é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Sobrenome do Hóspede não pode exceder 50 caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento do Hóspede é obrigatória.")]
        public DateOnly DataNascimento { get; set; }
    }
}