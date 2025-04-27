using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelConsagradoAPI.Models
{
    public class Hospede
    {
        public int Id { get; set; } // Propriedade para o ID único do hóspede (chave primária)
        [Required]// Atributo que torna a propriedade Nome obrigatória
        [MaxLength(100)]// Atributo que define o tamanho máximo da string Nome para 100 caracteres
        // Propriedades para nome e idade
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }

        [ForeignKey("Reserva")] // Atributo que define ReservaId como chave estrangeira referenciando a Reserva.
        public int ReservaId { get; set; }
        public Reserva? Reserva { get; set; }
    }
}