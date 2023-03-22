using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRANSPORTES.WEB.Models.Entidades;

namespace TRANSPORTES.REPOSITORY.Models.Entidades
{
    public class EntidadeCliente
    {
        [Key]
        [Column(TypeName = "decimal(13,2)")]
        public decimal ClienteId { get; set; }

        [StringLength(256)]
        public string ClienteNome { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataAtualizacao { get; set; }  

        public ICollection<Conteiner> Conteiners { get; set; }

    }
}       
