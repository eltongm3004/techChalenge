using ApiLoja.Core.Entities;
using ApiLoja.Core.Enums;
using ApiLoja.Core.Requests;
using ApiLoja.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace ApiLoja.Adapters.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPut("checkout/{idPedido}")]
        public IActionResult FakeCheckout([FromRoute] int idPedido)
        {
            _pedidoService.FakeCheckOut(idPedido);
            return Ok();
        }

        [HttpPost]
        public IActionResult FazerPedido([FromBody] FazerPedidoRequest pedido)
        {
            var IdClienteLogado = 1; //Aqui seria uma chamada no token JWT para recuperar o cliente logado
            
            StatusPedido status = StatusPedido.Recebido;
            _pedidoService.FazerPedido(pedido, IdClienteLogado, status);
            return Ok();
        }

        [HttpGet]
        public IActionResult ListarPedidos()
        {
            var pedidos = _pedidoService.ListarPedidos();
            return Ok(pedidos);
        }
    }
}
