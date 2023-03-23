using TRANSPORTES.REPOSITORY.Models.Entidades;

namespace TRANSPORTES.WEB.Repositories.Interfaces;

public interface IEntidadeClienteRepository
{

    IEnumerable<EntidadeCliente> GetAllEntidadeClientes();

    EntidadeCliente GetEntidadeCLienteById(int clienteId);

    decimal AddEntidadeCliente(EntidadeCliente entidadeCliente);

    bool UpdateEntidadeCliente(EntidadeCliente entidadeCliente);

    bool DeleteEntidadeCliente(int clienteId);
    }
