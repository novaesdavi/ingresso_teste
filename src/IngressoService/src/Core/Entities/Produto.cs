using IngressoService.Core.ValueObjects;
using System;

namespace IngressoService.Core.Entities
{
    public class Produto
    {
        public Guid IdProduto { get; private set; }
        public DateTime DataInclusaoProduto { get; private set; }
        public TipoProduto TipoProduto { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }

        public Produto(string nome, string descricao, TipoProduto tipoProduto, decimal preco)
        {
            IdProduto = Guid.NewGuid();
            DataInclusaoProduto = DateTime.UtcNow;
            Nome = nome;
            Descricao = descricao;
            TipoProduto = tipoProduto;
            Preco = preco;
        }
    }
}
