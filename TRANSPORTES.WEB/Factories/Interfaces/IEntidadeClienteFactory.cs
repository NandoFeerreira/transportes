using TRANSPORTES.WEB.ViewModels;

namespace TRANSPORTES.WEB.Factorys.Interfaces
{
    public interface IEntidadeClienteFactory
    {
        bool AddConteiner(TransportesViewModel model);

        List<TransportesViewModel> GetListConteiners
            (
            int? conteinerId = null
            );

        bool UpdateConteiner(TransportesViewModel model);

        bool DeleteConteiner(TransportesViewModel model);
    }
}
