using Microsoft.AspNetCore.Mvc;

namespace LojaCarrinhos.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
