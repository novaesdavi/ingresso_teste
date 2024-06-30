using IngressoService.Core.Services;
using IngressoService.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IngressoService.Core.Entities
{
    public class Carrinho
    {
        public Guid IdCarrinho { get; private set; }
        public Guid IdCliente { get; private set; }
        public StatusCarrinho StatusCarrinho { get; private set; }
        private List<ItemCarrinho> itens;

        public Carrinho(Guid idCliente)
        {
            IdCarrinho = Guid.NewGuid();
            IdCliente = idCliente;
            StatusCarrinho = StatusCarrinho.Aberto;
            itens = new List<ItemCarrinho>();
        }

        public void AdicionarItem(ItemCarrinho item)
        {
            itens.Add(item);
        }

        public void RemoverItem(ItemCarrinho item)
        {
            itens.Remove(item);
        }

        public decimal ObterTotal()
        {
            var calculoService = new CalculoTotalCarrinhoService();
            return calculoService.CalcularTotal(this);
        }

        public IReadOnlyCollection<ItemCarrinho> Itens => itens.AsReadOnly();
    }
}
