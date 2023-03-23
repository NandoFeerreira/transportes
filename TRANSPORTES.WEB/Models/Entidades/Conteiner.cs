using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRANSPORTES.REPOSITORY.Models.Entidades;

namespace TRANSPORTES.WEB.Models.Entidades
{
    public class Conteiner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int ConteinerId { get; set; }

        public DateTime? DataCriacao { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        [StringLength(100)]
        public string Numero { get; set; }
        
        public int Tipo { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Categoria { get; set; }

        public int ClienteId { get; set; }
        
    }
}
