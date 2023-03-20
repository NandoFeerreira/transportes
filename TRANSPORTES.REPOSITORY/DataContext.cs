using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRANSPORTES.REPOSITORY.Models.Entidades;

namespace TRANSPORTES.REPOSITORY
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EntidadeCliente> EntidadeClientes { get; set; }

    }
}
