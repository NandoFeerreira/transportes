using Microsoft.EntityFrameworkCore;
using TRANSPORTES.REPOSITORY.Models.Entidades;

namespace TRANSPORTES.WEB.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<EntidadeCliente> EntidadeClientes { get; set; }

}
