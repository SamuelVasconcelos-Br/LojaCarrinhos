using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LojaCarrinhos.Models
{
    public class CheckoutViewModel
    {
        // Resumo do Carrinho (para exibir na página)
        public List<ItemCarrinho> ItensDoCarrinho { get; set; }
        public decimal TotalCarrinho { get; set; }

        // Informações de Entrega
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Complemento (Opcional)")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [Display(Name = "CEP")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "CEP inválido")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        // Informações de Pagamento (Simplificado)
        [Required(ErrorMessage = "O nome no cartão é obrigatório")]
        [Display(Name = "Nome no Cartão")]
        public string NomeNoCartao { get; set; }

        [Required(ErrorMessage = "O número do cartão é obrigatório")]
        [CreditCard(ErrorMessage = "Número de cartão de crédito inválido")]
        [Display(Name = "Número do Cartão")]
        public string NumeroDoCartao { get; set; }

        [Required(ErrorMessage = "A data de validade é obrigatória")]
        [Display(Name = "Validade (MM/AA)")]
        public string Validade { get; set; }

        [Required(ErrorMessage = "O CVV é obrigatório")]
        [Display(Name = "CVV")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "CVV inválido")]
        public string Cvv { get; set; }
    }
}