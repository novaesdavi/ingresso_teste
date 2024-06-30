using IngressoService.Core.ValueObjects;
using System;

namespace IngressoService.Core.Entities
{
    public class ItemCarrinho
    {
        public Guid IdItemCarrinho { get; private set; }
        public Guid IdCarrinho { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public StatusItemCarrinho StatusItem { get; private set; }

        public ItemCarrinho(Guid idCarrinho, Produto produto, int quantidade)
        {
            IdItemCarrinho = Guid.NewGuid();
            IdCarrinho = idCarrinho;
            Produto = produto;
            Quantidade = quantidade;
            StatusItem = StatusItemCarrinho.Ativo;
        }

        public decimal ObterSubtotal()
        {
            return Produto.Preco * Quantidade;
        }
    }
}
