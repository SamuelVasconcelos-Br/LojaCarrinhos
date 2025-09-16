using Microsoft.AspNetCore.Mvc;

namespace LojaCarrinhos.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
