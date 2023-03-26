using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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
            try
            {
                var model = new TransportesViewModel();

                model.Mensagem = null;

                return View(model);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("clientes")]
        public IActionResult Index(TransportesViewModel model)
        {
            try
            {
                var result = _entidadeClienteFactory.AddConteiner(model);

                if (result)
                {
                    model.Mensagem = "Contêiner adicionado com sucesso.";
                }
                else
                {
                    model.Mensagem = "Erro ao adicionar contêiner.";
                }


                return View(model);
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
                var listmodel = _entidadeClienteFactory.GetListConteiners();

                var result = _entidadeClienteFactory.UpdateConteiner(model);

                if (result == true)
                {
                    var modelToUpdate = listmodel.FirstOrDefault(m => m.ConteinerId == model.ConteinerId);
                    if (modelToUpdate != null)
                    {
                        modelToUpdate.Mensagem = "Edições realizadas com sucesso";
                    }
                }
                else
                {
                    var modelToUpdate = listmodel.FirstOrDefault(m => m.ConteinerId == model.ConteinerId);
                    if (modelToUpdate != null)
                    {
                        modelToUpdate.Mensagem = "Não foi possível realizar a edição verifique os dados colocados ";
                    }
                }

                return View(listmodel);
            }
            catch (Exception)
            {
                
                return RedirectToAction("Index");
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
                    return RedirectToAction("Editar");
                }
               

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }


        }
    }

}
