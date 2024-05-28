using ApiLoja.Core.Entities;
using ApiLoja.Core.Enums;
using System.ComponentModel;

namespace ApiLoja.Core.Requests
{
    public class FazerPedidoRequest
    {
        public Dictionary<int,int> IdProdutoXQtde { get; set; }
        public DateTime Data { get; set; }
    }
}
