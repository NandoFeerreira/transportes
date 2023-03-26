using TRANSPORTES.REPOSITORY.Models.Entidades;
using TRANSPORTES.WEB.Factorys.Interfaces;
using TRANSPORTES.WEB.Models.Entidades;
using TRANSPORTES.WEB.Repositories.Interfaces;
using TRANSPORTES.WEB.ViewModels;

namespace TRANSPORTES.WEB.Factorys
{
    public class EntidadeClienteFactory : IEntidadeClienteFactory
    {
        private readonly IEntidadeClienteRepository _entidadeClienteRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IConteinerRepository _conteinerRepository;

        public EntidadeClienteFactory
            (
            IEntidadeClienteRepository entidadeClienteRepository,
            IMovimentacaoRepository movimentacaoRepository,
            IConteinerRepository conteinerRepository
            )
        {
            _entidadeClienteRepository = entidadeClienteRepository;
            _movimentacaoRepository = movimentacaoRepository;
            _conteinerRepository = conteinerRepository;
        }

        public bool AddConteiner(TransportesViewModel model)
        {
            try
            {
                var cliente = ParseEntidadeCliente(model);

                model.ClienteId = _entidadeClienteRepository.AddEntidadeCliente(cliente);

                if (model.ClienteId == 0)
                {
                    return false;
                }

                var conteiner = ParseConteiner(model);

                var result = _conteinerRepository.AddConteiner(conteiner);

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


        public List<TransportesViewModel> GetListConteiners
            (
            int? conteinerId = null
            )
        {
            try
            {
                if (conteinerId.HasValue)
                {

                }

                var listaConteiner = _conteinerRepository.GetAllConteiners();

                if (listaConteiner.Count() == 0)
                {

                }

                var listaModel = ParseTransportesConteinerViewModel(listaConteiner);

                return listaModel;


            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool UpdateConteiner(TransportesViewModel model)
        {
            try
            {

                model.ClienteNome = model.NomeClienteAtualiado;


                var cliente = ParseEntidadeCliente(model);
                var conteiner = ParseConteiner(model);

                var result = _entidadeClienteRepository.UpdateEntidadeCliente(cliente);

                if (result == false)
                {
                    return false;
                }

                result = _conteinerRepository.UpdateConteiner(conteiner);

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

        public bool DeleteConteiner(TransportesViewModel model)
        {
            try
            {
                var result = _conteinerRepository.DeleteConteiner(Convert.ToInt32(model.ConteinerId));

                if (result == false)
                {
                    return false;
                }


                result = _entidadeClienteRepository.DeleteEntidadeCliente(Convert.ToInt32(model.ClienteId));

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
      


        private List<TransportesViewModel> ParseTransportesConteinerViewModel(IEnumerable<Conteiner> conteiners)
        {

            var listaModel = new List<TransportesViewModel>();

          

            var clientes = _entidadeClienteRepository.GetAllEntidadeClientes();

            foreach (var conteiner in conteiners)
            {

                var model = new TransportesViewModel();

                model.ConteinerId = conteiner.ConteinerId;
                model.ClienteId = conteiner.ClienteId;
                model.Categoria = conteiner.Categoria;
                model.NumeroConteiner = conteiner.Numero;
                model.Status = conteiner.Status;
                model.Ativo = conteiner.Ativo;
                model.Tipo = conteiner.Tipo;

                model.ClienteNome = clientes
                        .Where(cliente => cliente.ClienteId == conteiner.ClienteId)
                        .Select(cliente => cliente.ClienteNome).FirstOrDefault();

                listaModel.Add(model);

            }

            return listaModel;
        }


        private EntidadeCliente ParseEntidadeCliente(TransportesViewModel model)
        {
            var cliente = new EntidadeCliente();

            cliente.ClienteId = Convert.ToInt32(model.ClienteId.HasValue ? model.ClienteId.Value : 0);
            cliente.ClienteNome = model.ClienteNome;
            cliente.Ativo = true;
            cliente.DataCriacao = model.ClienteId.HasValue ? null : DateTime.Now;
            cliente.DataAtualizacao = model.ClienteId.HasValue ? DateTime.Now : null;


            return cliente;

        }

        private Conteiner ParseConteiner(TransportesViewModel model)
        {
            var conteiner = new Conteiner();

            conteiner.ConteinerId = Convert.ToInt32(model.ConteinerId.HasValue ? model.ConteinerId.Value : 0);
            conteiner.Numero = model.NumeroConteiner;
            conteiner.Tipo = Convert.ToInt32(model.Tipo);
            conteiner.Status = model.Status;
            conteiner.Categoria = model.Categoria;
            conteiner.ClienteId = Convert.ToInt32(model.ClienteId.Value);
            conteiner.DataCriacao = model.ConteinerId.HasValue ? null : DateTime.Now;
            conteiner.DataAtualizacao = model.ConteinerId.HasValue ? DateTime.Now : null;

            return conteiner;
        }

    }
}
