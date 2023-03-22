using Microsoft.AspNetCore.Mvc;
using TRANSPORTES.WEB.Factorys.Interfaces;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}
