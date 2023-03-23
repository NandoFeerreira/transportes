using TRANSPORTES.WEB.Context;
using TRANSPORTES.WEB.Models.Entidades;
using TRANSPORTES.WEB.Repositories.Interfaces;

namespace TRANSPORTES.WEB.Repositories;

public class ConteinerRepository : IConteinerRepository
{
    private readonly AppDbContext _context;

    public ConteinerRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Conteiner> GetAllConteiners()
    {
        return _context.Conteiners.ToList();
    }

    public Conteiner GetConteinerId(decimal conteinerId)
    {
        return _context.Conteiners.FirstOrDefault(Id => Id.ConteinerId == conteinerId);
    }

    public bool AddConteiner(Conteiner conteiner)
    {
        try
        {
            _context.Conteiners.Add(conteiner);
            _context.SaveChanges();

            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UpdateConteiner(Conteiner conteiner)
    {
        try
        {
            var conteinerExistente = _context.Conteiners.FirstOrDefault(c => c.ConteinerId == conteiner.ConteinerId);

            if (conteinerExistente != null)
            {
                conteinerExistente.Numero = conteiner.Numero;
                conteinerExistente.DataAtualizacao = conteiner.DataAtualizacao;
                conteinerExistente.Ativo = conteiner.Ativo;
                conteinerExistente.Tipo = conteiner.Tipo;
                conteinerExistente.Status = conteiner.Status;
                conteinerExistente.Categoria = conteiner.Categoria;
                conteinerExistente.ClienteId = conteiner.ClienteId;



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


    public bool DeleteConteiner(int conteinerId)
    {
        try
        {
            var conteiner = _context.Conteiners.FirstOrDefault(c => c.ConteinerId == conteinerId);

            if (conteiner != null)
            {
                _context.Conteiners.Remove(conteiner);
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
}
