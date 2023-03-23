using Microsoft.AspNetCore.Mvc;
using TRANSPORTES.WEB.Factorys.Interfaces;
using TRANSPORTES.WEB.ViewModels;

namespace TRANSPORTES.WEB.Controllers
{
    public class EntidadeClienteController : Controller
    {
        private readonly IEntidadeClienteFactory _entidadeClienteFactory;

        public EntidadeClienteController
            (
            IEntidadeClienteFactory entidadeClienteFactory
            )
        {
            _entidadeClienteFactory = entidadeClienteFactory;
        }


        [HttpGet]
        [Route("clientes")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("clientes")]
        public IActionResult Index(TransportesViewModel model)
        {
            try
            {
                var result = _entidadeClienteFactory.AddConteiner(model);


                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("clientes/editar")]
        public IActionResult Editar()
        {
            try
            {
                var listmodel = _entidadeClienteFactory.GetListConteiners();

                ViewBag.Mensagem = "";

                return View(listmodel);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("clientes/editar")]
        public IActionResult Editar(TransportesViewModel model)
        {
            try
            {
                var result = _entidadeClienteFactory.UpdateConteiner(model);

                if (result == true)
                {
                    return RedirectToAction("Editar", new { mensagem = "Contêiner atualizado com sucesso!" });
                }
                else
                {
                    ViewBag.Mensagem = "Não foi possível atualizar o contêiner. ";
                }

                return RedirectToAction("Editar");
            }
            catch (Exception)
            {
                ViewBag.Mensagem = "Ocorreu um erro ao tentar atualizar o contêiner. Tente novamente mais tarde.";
                return RedirectToAction("Editar");
            }
        }

        [HttpPost]
        [Route("clientes/excluir")]
        public IActionResult Excluir(TransportesViewModel model)
        {
            try
            {
                var result = _entidadeClienteFactory.DeleteConteiner(model);

                if (result == true)
                {
                    return RedirectToAction("Editar", new { mensagem = "Contêiner Excluido Com Sucesso!" });
                }
                else
                {
                    ViewBag.Mensagem = "Não foi possível excluir o contêiner. ";
                }

                return RedirectToAction("Editar");
            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
    
}
