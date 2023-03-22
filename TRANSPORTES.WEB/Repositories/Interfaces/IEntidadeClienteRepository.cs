using TRANSPORTES.REPOSITORY.Models.Entidades;

namespace TRANSPORTES.WEB.Repositories.Interfaces;

public interface IEntidadeClienteRepository
{

    IEnumerable<EntidadeCliente> GetAllEntidadeClientes();

    EntidadeCliente GetEntidadeCLienteById(decimal clienteId);

    bool AddEntidadeCliente(EntidadeCliente entidadeCliente);

    bool UpdateEntidadeCliente(EntidadeCliente entidadeCliente);

    bool DeleteEntidadeCliente(decimal clienteId);
    }
