using LojaCarrinhos.Models;
using Newtonsoft.Json;

namespace LojaCarrinhos.Repository
{
    // Repositório responsável por gerenciar o carrinho de compras na sessão do usuário.
    public class CarrinhoRepository
    {
        // Chave utilizada para armazenar o carrinho na sessão.
        private const string CartSessionKey = "Carrinho";

        // Recupera os itens do carrinho armazenados na sessão.
        public List<ItemCarrinho> CarrinhoItems(ISession session)
        {
            var cartJson = session.GetString(CartSessionKey);
            return cartJson == null ? new List<ItemCarrinho>() : JsonConvert.DeserializeObject<List<ItemCarrinho>>(cartJson);
        }

        // Adiciona um produto ao carrinho ou incrementa a quantidade se já existir.
        public void AdicionarCarrinho(ISession session, Produto produto, int quantidade)
        {
            var cart = CarrinhoItems(session);
            var existingItem = cart.FirstOrDefault(item => item.ProdutoId == produto.Id);

            if (existingItem != null)
            {
                existingItem.Quantidade += quantidade;
            }
            else
            {
                cart.Add(new ItemCarrinho
                {       
                    ProdutoId = produto.Id,
                    //Produto = produto,
                    Quantidade = quantidade,
                    Preco = produto.Preco
                });
            }
            SalvarCarrinho(session, cart);
        }

        // Altera a quantidade de um item no carrinho, removendo se a quantidade for zero ou negativa.
        public void AlterarQuantidadeItem(ISession session, int produtoId, int novaQuantidade)
        {
            var cart = CarrinhoItems(session);
            var itemAlterar = cart.FirstOrDefault(item => item.ProdutoId == produtoId);

            if (itemAlterar != null)
            {
                if (novaQuantidade <= 0)
                {
                    cart.Remove(itemAlterar);
                }
                else
                {
                    itemAlterar.Quantidade = novaQuantidade;
                }
                SalvarCarrinho(session, cart);
            }
        }

        // Remove um item específico do carrinho.
        public void RemoverItemCarrinho(ISession session, int produtoId)
        {
            var cart = CarrinhoItems(session);
            var itemRemover = cart.FirstOrDefault(item => item.ProdutoId == produtoId);
            if (itemRemover != null)
            {
                cart.Remove(itemRemover);
                SalvarCarrinho(session, cart);
            }
        }

        // Limpa todos os itens do carrinho na sessão.
        public void LimparCarrinho(ISession session)
        {
            session.Remove(CartSessionKey);
        }

        // Calcula o valor total do carrinho somando o total de cada item.
        public decimal TotalCarrinho(ISession session)
        {
            return CarrinhoItems(session).Sum(item => item.Total);
        }

        // Salva o estado atual do carrinho na sessão do usuário.
        private void SalvarCarrinho(ISession session, List<ItemCarrinho> cart)
        {
            session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
        }
    }
}
