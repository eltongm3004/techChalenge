namespace ApiLoja.Core.Requests
{
    public class CriarProdutoRequest
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}
