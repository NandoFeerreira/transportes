using TRANSPORTES.WEB.Models.Entidades;

namespace TRANSPORTES.WEB.Repositories.Interfaces
{
    public interface IConteinerRepository
    {
        IEnumerable<Conteiner> GetAllConteiners();

        Conteiner GetConteinerId(decimal conteinerId);

        bool AddConteiner(Conteiner conteiner);

        bool UpdateConteiner(Conteiner conteiner);

        bool DeleteConteiner(int conteinerId);

    }
}
