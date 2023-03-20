using TRANSPORTES.REPOSITORY.Models.Entidades;

namespace TRANSPORTES.REPOSITORY.Repositories.Interfaces;

public interface IEntidadeClienteRepository
{

    Task Adicionar(EntidadeCliente entidadeCliente);

}
