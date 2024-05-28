using ApiLoja.Core.Entities;

namespace ApiLoja.Core.Responses
{
    public class GetAllPedidosResponse
    {
        public int PedidoId { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public int IdCliente { get; set; }
        public List<ProdutoDto> Produtos { get; set; } = new List<ProdutoDto>();
    }

    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
