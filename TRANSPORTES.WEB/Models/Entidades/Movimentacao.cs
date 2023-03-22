using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRANSPORTES.WEB.Models.Entidades
{
    public class Movimentacao
    {
        [Key]
        [Column(TypeName = "decimal(13,2)")]
        public decimal MovimentacaoId { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public DateTime DataHoraFim { get; set; }

        [Column(TypeName = "decimal(13,2)")]
        public decimal ConteinerId { get; set; }

        public Conteiner Conteiner { get; set; }
    }
}
