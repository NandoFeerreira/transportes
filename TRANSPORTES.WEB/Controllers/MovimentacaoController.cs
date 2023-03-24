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


            return View();
        }



        [HttpPost]
        [Route("movimentacao")]
        public IActionResult Index(TransportesViewModel model)
        {
            try
            {
                var result = _movimentacaoFactory.AddMovimentacao(model);

                if (result)
                {
                    ViewBag.Message = "Movimentação adicionada com sucesso!";
                    return RedirectToAction("Index", "Movimentacao");
                }
                else
                {
                    ViewBag.Message = "Não foi possível adicionar a movimentação.";
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Ocorreu um erro ao adicionar a movimentação.";
            }

            return View();
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

    }
}
