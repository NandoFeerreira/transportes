using TRANSPORTES.REPOSITORY.Models.Entidades;
using TRANSPORTES.REPOSITORY.Repositories.Interfaces;

namespace TRANSPORTES.REPOSITORY.Repositorys;

public class EntidadeClienteReposiroty : IEntidadeClienteRepository
{
    private readonly DataContext _dataContext;

    public EntidadeClienteReposiroty(DataContext context)
    {
        _dataContext = context;
    }

    public async Task Adicionar (EntidadeCliente entidadeCliente)
    {
        await  _dataContext.EntidadeClientes.AddAsync(entidadeCliente);
    }

}
