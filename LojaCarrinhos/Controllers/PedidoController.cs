using LojaCarrinhos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq; // Adicionar para usar .Sum()
// Importe seus serviços de carrinho e pedido aqui

namespace LojaCarrinhos.Controllers
{
    public class PedidoController : Controller
    {
        // Supondo que você tenha um serviço para gerenciar o carrinho.
        // Injetar dependências aqui (serviço do carrinho, do pedido, banco de dados, etc.)
        // Ex: private readonly ICarrinhoService _carrinhoService;
        //     public PedidoController(ICarrinhoService carrinhoService) { ... }

        [HttpGet]
        public IActionResult Checkout()
        {
            // Lógica para buscar os itens do carrinho (ex: da sessão)
            var itensCarrinho = ObterItensDoCarrinho(); // Implemente este método
            if (itensCarrinho == null || !itensCarrinho.Any())
            {
                // Se o carrinho estiver vazio, redireciona para a home
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new CheckoutViewModel
            {
                ItensDoCarrinho = itensCarrinho,
                TotalCarrinho = itensCarrinho.Sum(item => item.Total)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutViewModel viewModel)
        {
            var itensCarrinho = ObterItensDoCarrinho();
            viewModel.ItensDoCarrinho = itensCarrinho;
            viewModel.TotalCarrinho = itensCarrinho.Sum(item => item.Total);

            if (!ModelState.IsValid)
            {
                // Se o formulário tiver erros de validação, retorna a mesma view
                // para que o usuário possa corrigir os dados.
                return View(viewModel);
            }

            // --- LÓGICA DE PROCESSAMENTO DO PEDIDO ---
            // 1. Salvar as informações do pedido no banco de dados.
            // 2. Processar o pagamento com um gateway seguro (Stripe, PagSeguro, etc).
            // 3. Limpar o carrinho de compras do usuário.
            // 4. Redirecionar para uma página de confirmação.

            // Por enquanto, vamos apenas redirecionar
            return RedirectToAction("ConfirmacaoPedido");
        }

        public IActionResult ConfirmacaoPedido()
        {
            return View();
        }

        // Método auxiliar para simular a obtenção do carrinho
        private List<ItemCarrinho> ObterItensDoCarrinho()
        {
            // Aqui você implementaria a lógica real para pegar o carrinho da sessão do usuário
            // ou do banco de dados.
            // Este é apenas um exemplo:
            return new List<ItemCarrinho>
            {
                new ItemCarrinho { Produto = new Produto { Nome = "Miniatura Porsche 911" }, Quantidade = 1, Preco = 150.00m },
                new ItemCarrinho { Produto = new Produto { Nome = "Miniatura Fusca 1967" }, Quantidade = 2, Preco = 80.00m }
            };
        }
    }
}