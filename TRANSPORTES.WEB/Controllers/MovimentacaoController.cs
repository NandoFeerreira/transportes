using Microsoft.AspNetCore.Mvc;
using TRANSPORTES.WEB.Factories.Interfaces;
using TRANSPORTES.WEB.Factorys.Interfaces;
using TRANSPORTES.WEB.ViewModels;

namespace TRANSPORTES.WEB.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoFactory _movimentacaoFactory;
        private readonly IEntidadeClienteFactory _entidadeClienteFactory;

        public MovimentacaoController
            (
            IMovimentacaoFactory movimentacaoFactory,
            IEntidadeClienteFactory entidadeClienteFactory
            )
        {
            _movimentacaoFactory = movimentacaoFactory;
            _entidadeClienteFactory = entidadeClienteFactory;
        }



        [HttpGet]
        [Route("movimentacao")]
        public IActionResult Index()
        {
            var listmodel = _entidadeClienteFactory.GetListConteiners();

            return View(listmodel);

        }



        [HttpPost]
        [Route("movimentacao")]
        public IActionResult Index(TransportesViewModel model)
        {
            try
            {
                var listmodel = _entidadeClienteFactory.GetListConteiners();

                var result = _movimentacaoFactory.AddMovimentacao(model);

                if (result == true)
                {
                    var modelToUpdate = listmodel.FirstOrDefault(m => m.ConteinerId == model.ConteinerId);
                    if (modelToUpdate != null)
                    {
                        modelToUpdate.Mensagem = "Movimentação adiconada com sucesso";
                    }
                }
                else
                {
                    var modelToUpdate = listmodel.FirstOrDefault(m => m.ConteinerId == model.ConteinerId);
                    if (modelToUpdate != null)
                    {
                        modelToUpdate.Mensagem = "Não foi possível realizar a adição da movimentação verifique os dados colocados ";
                    }
                }

                return View(listmodel);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("movimentacao/editar")]
        public IActionResult Editar()
        {
            try
            {
                var viewModel = _movimentacaoFactory.GetAllMovimentacoes();

                return View(viewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("movimentacao/editar")]
        public IActionResult Editar(TransportesViewModel model)
        {
            try
            {
                var viewModel = _movimentacaoFactory.GetAllMovimentacoes();

                var result = _movimentacaoFactory.UpdateMovimentacao(model);

                if (result == true)
                {
                    var modelToUpdate = viewModel.FirstOrDefault(m => m.ConteinerId == model.ConteinerId);
                    if (modelToUpdate != null)
                    {
                        modelToUpdate.Mensagem = "Edições realizadas com sucesso";
                    }
                }
                else
                {
                    var modelToUpdate = viewModel.FirstOrDefault(m => m.ConteinerId == model.ConteinerId);
                    if (modelToUpdate != null)
                    {
                        modelToUpdate.Mensagem = "Não foi possível realizar a edição verifique os dados colocados ";
                    }
                }

                return View(viewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("movimentacao/excluir")]
        public IActionResult Excluir(TransportesViewModel model)
        {
            try
            {
                var result = _movimentacaoFactory.DeleteMovimentacao(model);

                if(result == true) 
                {
                    return RedirectToAction("Editar", "Movimentacao");
                };

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("movimentacao/relatorio")]
        public IActionResult Relatorio()
        {
            try
            
            {
                var viewModel = _movimentacaoFactory.GetAllMovimentacoes();

                return View(viewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
