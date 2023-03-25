using TRANSPORTES.WEB.ViewModels;

namespace TRANSPORTES.WEB.Factories.Interfaces
{
    public interface IMovimentacaoFactory
    {

        bool AddMovimentacao(TransportesViewModel model);

        List<TransportesViewModel> GetAllMovimentacoes();

        bool UpdateMovimentacao(TransportesViewModel model);

        bool DeleteMovimentacao(TransportesViewModel model);

    }
}
