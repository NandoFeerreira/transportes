using TRANSPORTES.WEB.Factories.Interfaces;
using TRANSPORTES.WEB.Factorys.Interfaces;
using TRANSPORTES.WEB.Models.Entidades;
using TRANSPORTES.WEB.Repositories.Interfaces;
using TRANSPORTES.WEB.ViewModels;

namespace TRANSPORTES.WEB.Factories
{
    public class MovimentacaoFactory : IMovimentacaoFactory
    {

        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IEntidadeClienteFactory _entidadeClienteFactory;

        public MovimentacaoFactory
            (
            IMovimentacaoRepository movimentacaoRepository,
            IEntidadeClienteFactory entidadeClienteFactory
            )
        {
            _movimentacaoRepository = movimentacaoRepository;
            _entidadeClienteFactory = entidadeClienteFactory;
        }

        public bool AddMovimentacao(TransportesViewModel model) 
        {
            try
            {
                var movimentacao = ParseMovimentacao(model);

                var result = _movimentacaoRepository.AddMovimentacao(movimentacao);

                if (result == false)
                {
                    return false;
                }

                return true;

            }
            catch (Exception)
            {
                throw;
            }       
        
        }


        public List<TransportesViewModel> GetAllMovimentacoes()
        {
            try
            {
                var listaTransportes = new List<TransportesViewModel>();

                var conteiners = _entidadeClienteFactory.GetListConteiners();

                var movimentacoes = _movimentacaoRepository.GetAllMovimentacoes();

                foreach (var movimentacao in movimentacoes)
                {
                    var movimentacaoViewModel = ParseMovimentacaoViewModel(movimentacao);

                    foreach (var item in listaTransportes)
                    {
                        item.Movimentacao = movimentacaoViewModel;
                    }
                }

                return listaTransportes;

            }
            catch (Exception)
            {
                throw;
            }
        }


        private Movimentacao ParseMovimentacao(TransportesViewModel model)
        {
            var movimentacao = new Movimentacao();

            movimentacao.MovimentacaoId = model.MovimentacaoId.HasValue ? model.MovimentacaoId.Value : 0;
            movimentacao.DataCriacao = model.MovimentacaoId.HasValue ? null : DateTime.Now;
            movimentacao.Ativo = model.Ativo.HasValue ? model.Ativo.Value : true;
            movimentacao.DataAtualizacao = model.MovimentacaoId.HasValue ? DateTime.Now : null;
            movimentacao.Tipo = model.Movimentacao.TipoMovimentacao;
            movimentacao.DataHoraInicio = model.Movimentacao.DataHoraInicio.Value;
            movimentacao.DataHoraFim = model.Movimentacao.DataHoraFim.Value;
            movimentacao.ConteinerId = Convert.ToInt32(model.ConteinerId);

            return movimentacao;

        }

        private MovimentacaoViewModel ParseMovimentacaoViewModel(Movimentacao movimentacao)
        {
            var movimentacaoViewModel = new MovimentacaoViewModel();

            movimentacaoViewModel.MovimentacaoId = movimentacao.MovimentacaoId;
            movimentacaoViewModel.TipoMovimentacao = movimentacao.Tipo;
            movimentacaoViewModel.DataHoraFim = movimentacao.DataHoraFim;
            movimentacaoViewModel.DataHoraInicio = movimentacao.DataHoraInicio;

            return movimentacaoViewModel;

        }







    }
}
