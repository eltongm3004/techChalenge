using ApiLoja.Core.Entities;

namespace ApiLoja.Core.Responses
{
    public class CadastroClienteRequest
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Endereco Endereco { get; set; }
    }
}
