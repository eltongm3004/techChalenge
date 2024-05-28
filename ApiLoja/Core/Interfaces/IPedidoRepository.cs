using ApiLoja.Core.Entities;
using ApiLoja.Core.Enums;
using ApiLoja.Core.Requests;
using ApiLoja.Core.Responses;

namespace ApiLoja.Core.Interfaces
{
    public interface IPedidoRepository
    {
        void AddPedido(FazerPedidoRequest pedido, int idClienteLogado, StatusPedido status);
        IEnumerable<GetAllPedidosResponse> GetAllPedidos();
        void FakeCheckOut(int IdPedido);

    }
}
