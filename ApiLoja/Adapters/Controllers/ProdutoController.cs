using ApiLoja.Core.Entities;
using ApiLoja.Core.Requests;
using ApiLoja.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiLoja.Adapters.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public IActionResult CriarProduto([FromBody] CriarProdutoRequest produto)
        {
            _produtoService.CriarProduto(produto);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarProduto([FromBody] UpdateProdutoRequest produto)
        {
            _produtoService.EditarProduto(produto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverProduto(int id)
        {
            _produtoService.RemoverProduto(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            var produtos = _produtoService.GetAllProdutos();
            return Ok(produtos);
        }

        [HttpGet("categoria/{categoria}")]
        public IActionResult BuscarProdutosPorCategoria(string categoria)
        {
            var produtos = _produtoService.BuscarProdutosPorCategoria(categoria);
            return Ok(produtos);
        }
    }
}
