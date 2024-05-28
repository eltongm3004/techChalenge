using ApiLoja.Core.Entities;
using ApiLoja.Core.Enums;
using ApiLoja.Core.Interfaces;
using ApiLoja.Core.Requests;
using ApiLoja.Core.Responses;

namespace ApiLoja.Core.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void FazerPedido(FazerPedidoRequest pedido, int idClienteLogado, StatusPedido status)
        {
            _pedidoRepository.AddPedido(pedido, idClienteLogado, status);
        }
        public void FakeCheckOut(int idPedido)
        {
            _pedidoRepository.FakeCheckOut(idPedido);
        }
        public IEnumerable<GetAllPedidosResponse> ListarPedidos()
        {
            return _pedidoRepository.GetAllPedidos();
        }
    }
}
