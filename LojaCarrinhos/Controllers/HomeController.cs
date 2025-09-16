using LojaCarrinhos.Models;
using LojaCarrinhos.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaCarrinhos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProdutoRepository _produtoRepository;

        public HomeController(ILogger<HomeController> logger, ProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.TodosProdutos();
            return View(produtos);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
