using Microsoft.EntityFrameworkCore;
using TRANSPORTES.REPOSITORY.Models.Entidades;
using TRANSPORTES.WEB.Models.Entidades;

namespace TRANSPORTES.WEB.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<EntidadeCliente> EntidadeClientes { get; set; }
    public DbSet<Conteiner> Conteiners { get; set; }
    public DbSet<Movimentacao> Movimentacoes { get; set; }

}
