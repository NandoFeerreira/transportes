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

                var listaMovimentacoes = new List<MovimentacaoViewModel>();

                var conteiners = _entidadeClienteFactory.GetListConteiners();

                

                var movimentacoes = _movimentacaoRepository.GetAllMovimentacoes();

                foreach (var movimentacao in movimentacoes)
                {
                    var movimentacaoViewModel = ParseMovimentacaoViewModel(movimentacao);

                    listaMovimentacoes.Add(movimentacaoViewModel);

                }
                foreach (var conteiner in conteiners)
                {
                    conteiner.Movimentacoes = new List<MovimentacaoViewModel>();

                    conteiner.Movimentacoes.AddRange(listaMovimentacoes);

                    listaTransportes.Add(conteiner);
                }

                return listaTransportes;

            }
            catch (Exception)
            {
                throw;
            }
        }



        public bool UpdateMovimentacao(TransportesViewModel model)
        {
            try
            {

                var movimentacao = _movimentacaoRepository.GetMovimentacaoId(model.MovimentacaoTipo);

                model.Movimentacao.MovimentacaoId = movimentacao.MovimentacaoId;

                var movimentacaoInput = ParseMovimentacao(model);

                var result = _movimentacaoRepository.UpdateMovimentacao(movimentacaoInput);

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

        public bool DeleteMovimentacao(TransportesViewModel model)
        {
            try
            {
                var movimentacao = _movimentacaoRepository.GetMovimentacaoId(model.MovimentacaoTipo);

                var result = _movimentacaoRepository.DeleteMovimentacao(movimentacao.MovimentacaoId);

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


        private Movimentacao ParseMovimentacao(TransportesViewModel model)
        {
            var movimentacao = new Movimentacao();

            movimentacao.MovimentacaoId = model.Movimentacao.MovimentacaoId.HasValue ? model.Movimentacao.MovimentacaoId.Value : 0;
            movimentacao.DataCriacao = model.Movimentacao.MovimentacaoId.HasValue ? null : DateTime.Now;
            movimentacao.Ativo = model.Ativo.HasValue ? model.Ativo.Value : true;
            movimentacao.DataAtualizacao = model.Movimentacao.MovimentacaoId.HasValue ? DateTime.Now : null;
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
            movimentacaoViewModel.ConteinerIdMovimentacao = movimentacao.ConteinerId;

            return movimentacaoViewModel;

        }

    }
}
