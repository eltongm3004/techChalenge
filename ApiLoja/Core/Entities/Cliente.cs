namespace ApiLoja.Core.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Endereco Endereco { get; set; }

    }
}
