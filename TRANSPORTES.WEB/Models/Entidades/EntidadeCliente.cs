using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TRANSPORTES.REPOSITORY.Models.Entidades
{
    public class EntidadeCliente : EntidadeBase
    {       
        public string  ClienteNome { get; set; }

        public string NumeroContainer { get; set; }

        public decimal Tipo { get; set; }

        public string Status { get; set; }

        public string Categoria { get; set; }

    }
}       
