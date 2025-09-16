using Microsoft.AspNetCore.Mvc;

namespace LojaCarrinhos.Controllers
{
    // Controlador responsável por ações relacionadas a pedidos.
    public class PedidoController : Controller
    {
        // Exibe a view principal de pedidos.
        public IActionResult Index()
        {
            return View();
        }
    }
}
