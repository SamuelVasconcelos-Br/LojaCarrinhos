using LojaCarrinhos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrinhos.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CarrinhoRepository _carrinhoRepository;
        private readonly ProdutoRepository _produtoRepository;

        public CarrinhoController(CarrinhoRepository carrinhoRepository, ProdutoRepository produtoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
            _produtoRepository = produtoRepository;
        }
        public async Task<IActionResult> Index()
        {
            var cartItems = _carrinhoRepository.CarrinhoItems(HttpContext.Session);
            // Iterar sobre os itens do carrinho e buscar os detalhes do produto
            foreach (var item in cartItems)
            {
                // Certifique-se de que _productRepository está retornando um Product ou null
                item.Produto = await _produtoRepository.ProdutosPorId(item.ProdutoId);

                // Opcional: Lógica para lidar com produtos que não foram encontrados (removidos do DB, etc.)
                if (item.Produto == null)
                {
                    // Poderia remover o item do carrinho ou marcá-lo como indisponível
                    // Exemplo: item.Product = new Product { Name = "Produto Indisponível", Price = 0, ImageUrl = "/images/default_unavailable.jpg" };
                }
            }
            ViewBag.TotalCarrinho = _carrinhoRepository.TotalCarrinho(HttpContext.Session);
            return View(cartItems);
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarCarrinho(int produtoId, int quantidade = 1)
        {
            var produto = await _produtoRepository.ProdutosPorId(produtoId);
            if (produto == null)
            {
                TempData["Message"] = "Produto não encontrado."; // Use TempData para mensagens
                return RedirectToAction("Index", "Home");
            }

            _carrinhoRepository.AdicionarCarrinho(HttpContext.Session, produto, quantidade);
            return RedirectToAction("Index", "Carrinho");
        }

        [HttpPost]
        public IActionResult AlterarQuantidadeItem(int produtoId, int novaQuantidade)
        {
            _carrinhoRepository.AlterarQuantidadeItem(HttpContext.Session, produtoId, novaQuantidade);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int produtoId)
        {
            _carrinhoRepository.RemoverItemCarrinho(HttpContext.Session, produtoId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult LimparCarrinho()
        {
            _carrinhoRepository.LimparCarrinho(HttpContext.Session);
            return RedirectToAction("Index");
        }
    }
}
