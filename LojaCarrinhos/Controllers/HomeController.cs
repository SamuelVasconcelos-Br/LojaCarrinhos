using LojaCarrinhos.Models;
using LojaCarrinhos.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaCarrinhos.Controllers
{
    // Controlador principal da aplica��o, respons�vel pela p�gina inicial e erros.
    public class HomeController : Controller
    {
        // Logger para registrar informa��es e erros.
        private readonly ILogger<HomeController> _logger;
        // Reposit�rio de produtos para acessar dados do banco.
        private readonly ProdutoRepository _produtoRepository;

        // Injeta depend�ncias via construtor.
        public HomeController(ILogger<HomeController> logger, ProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        // Exibe a p�gina inicial com a lista de produtos.
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.TodosProdutos();
            return View(produtos);
        }

        // Exibe a p�gina de erro padr�o.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
