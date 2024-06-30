using Microsoft.AspNetCore.Mvc;
using IngressoService.Core.Entities;
using IngressoService.Core.ValueObjects;

namespace IngressoService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private static readonly List<Carrinho> Carrinhos = new List<Carrinho>();

        [HttpPost]
        public IActionResult CreateCarrinho(Guid clienteId)
        {
            var carrinho = new Carrinho(clienteId);
            Carrinhos.Add(carrinho);
            return Ok(carrinho);
        }

        [HttpPost("{idCarrinho}/itens")]
        public IActionResult AddItem(Guid idCarrinho, [FromBody] ItemCarrinhoDto itemDto)
        {
            var carrinho = Carrinhos.FirstOrDefault(c => c.IdCarrinho == idCarrinho);
            if (carrinho == null)
                return NotFound();

            var produto = new Produto(itemDto.Nome, itemDto.Descricao, itemDto.TipoProduto, itemDto.Preco);
            var item = new ItemCarrinho(carrinho.IdCarrinho, produto, itemDto.Quantidade);
            carrinho.AdicionarItem(item);

            return Ok(carrinho);
        }

        [HttpGet("{idCarrinho}/total")]
        public IActionResult GetTotal(Guid idCarrinho)
        {
            var carrinho = Carrinhos.FirstOrDefault(c => c.IdCarrinho == idCarrinho);
            if (carrinho == null)
                return NotFound();

            var total = carrinho.ObterTotal();
            return Ok(total);
        }
    }

    public class ItemCarrinhoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
