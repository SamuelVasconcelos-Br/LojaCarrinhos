using Microsoft.AspNetCore.Mvc;

namespace LojaCarrinhos.Controllers
{
    // Controlador responsável por ações relacionadas a produtos.
    public class ProdutoController : Controller
    {
        // Exibe a view principal de produtos.
        public IActionResult Index()
        {
            return View();
        }   
    }
}
