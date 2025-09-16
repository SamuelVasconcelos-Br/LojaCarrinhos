using LojaCarrinhos.Models;
using LojaCarrinhos.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaCarrinhos.Controllers
{
    // Controlador principal da aplicação, responsável pela página inicial e erros.
    public class HomeController : Controller
    {
        // Logger para registrar informações e erros.
        private readonly ILogger<HomeController> _logger;
        // Repositório de produtos para acessar dados do banco.
        private readonly ProdutoRepository _produtoRepository;

        // Injeta dependências via construtor.
        public HomeController(ILogger<HomeController> logger, ProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        // Exibe a página inicial com a lista de produtos.
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.TodosProdutos();
            return View(produtos);
        }

        // Exibe a página de erro padrão.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
