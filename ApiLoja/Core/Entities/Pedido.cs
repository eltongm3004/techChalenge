namespace ApiLoja.Core.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime Data { get; set; }
    }
}
