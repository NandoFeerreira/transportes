using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRANSPORTES.WEB.Models.Entidades
{
    public class Movimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int MovimentacaoId { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public DateTime DataHoraFim { get; set; }
        
        public int ConteinerId { get; set; }

        
    }
}
