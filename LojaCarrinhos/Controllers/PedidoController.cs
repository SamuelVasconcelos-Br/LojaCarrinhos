using Microsoft.AspNetCore.Mvc;

namespace LojaCarrinhos.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
