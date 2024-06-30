using IngressoService.Core.Entities;
using System;
using System.Linq;

namespace IngressoService.Core.Services
{
    public class CalculoTotalCarrinhoService
    {
        public decimal CalcularTotal(Carrinho carrinho)
        {
            return carrinho.Itens.Sum(item => item.ObterSubtotal());
        }
    }
}
