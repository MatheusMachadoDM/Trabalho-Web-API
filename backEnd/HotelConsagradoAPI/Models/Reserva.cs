using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HotelConsagradoAPI.Models
{
    public class Reserva
    {
        // Propriedade que representa o identificador único da reserva
        // Geralmente, esta é a chave primária no banco de dados
        public int Id { get; set; }
        [AllowNull]// Atributo que permite que a propriedade DataCheckIn seja nula (embora DateTime seja um tipo de valor não nulo por padrão, a configuração do banco pode permitir nulos)

        // Propriedade que armazenam atributos na reserva
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

        // Propriedade que representa uma coleção de objetos do tipo Hospede associados a esta reserva
        // ICollection<T> é uma interface para coleções genéricas
        public ICollection<Hospede> Hospedes { get; set; }
    }
}