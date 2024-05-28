using ApiLoja.Core.Entities;

namespace ApiLoja.Core.Responses
{
    public class GetClienteResponse
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public Endereco Endereco { get; set; }
    }
}
