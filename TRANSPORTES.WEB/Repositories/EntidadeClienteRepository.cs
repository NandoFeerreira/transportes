using TRANSPORTES.REPOSITORY.Models.Entidades;
using TRANSPORTES.WEB.Context;
using TRANSPORTES.WEB.Repositories.Interfaces;

namespace TRANSPORTES.WEB.Repositories;

public class EntidadeClienteRepository : IEntidadeClienteRepository
{
    private readonly AppDbContext _context;

    public EntidadeClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<EntidadeCliente> GetAllEntidadeClientes()
    {
        return _context.EntidadeClientes.ToList();
    }

    public EntidadeCliente GetEntidadeCLienteById(decimal clienteId)
    {
        return _context.EntidadeClientes.FirstOrDefault(Id => Id.ClienteId == clienteId);
    }

    public bool AddEntidadeCliente(EntidadeCliente entidadeCliente)
    {
        try
        {
            _context.EntidadeClientes.Add(entidadeCliente);
            _context.SaveChanges();

            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UpdateEntidadeCliente(EntidadeCliente entidadeCliente)
    {
        try
        {
            var clienteExistente = _context.EntidadeClientes.FirstOrDefault(c => c.ClienteId == entidadeCliente.ClienteId);

            if (clienteExistente != null)
            {
                clienteExistente.ClienteNome = entidadeCliente.ClienteNome;
                clienteExistente.DataCriacao = entidadeCliente.DataCriacao;
                clienteExistente.Ativo = entidadeCliente.Ativo;
                clienteExistente.DataAtualizacao = entidadeCliente.DataAtualizacao;


                _context.SaveChanges();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    public bool DeleteEntidadeCliente(decimal clienteId)
    {
        try
        {
            var entidadeCliente = _context.EntidadeClientes.FirstOrDefault(c => c.ClienteId == clienteId);

            if (entidadeCliente != null)
            {
                _context.EntidadeClientes.Remove(entidadeCliente);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
        catch (Exception ex )
        {

            throw ex;
        }



    }
}