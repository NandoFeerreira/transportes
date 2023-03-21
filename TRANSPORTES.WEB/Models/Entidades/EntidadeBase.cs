using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRANSPORTES.REPOSITORY.Models.Entidades
{
    public class EntidadeBase
    {
        public decimal Id { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? DataAtualizacao { get; set; } 

    }
}
