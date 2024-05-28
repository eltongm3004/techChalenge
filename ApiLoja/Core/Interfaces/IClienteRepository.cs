using ApiLoja.Core.Entities;
using ApiLoja.Core.Responses;

namespace ApiLoja.Core.Interfaces
{
    public interface IClienteRepository
    {
        void AddCliente(CadastroClienteRequest cliente);
        GetClienteResponse GetClienteByCpf(string cpf);
    }
}