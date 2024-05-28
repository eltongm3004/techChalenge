using ApiLoja.Core.Entities;
using ApiLoja.Core.Interfaces;
using ApiLoja.Core.Responses;

namespace ApiLoja.Core.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void CadastroCliente(CadastroClienteRequest cliente)
        {
            _clienteRepository.AddCliente(cliente);
        }

        public GetClienteResponse IdentificarCliente(string cpf)
        {
            var cliente = _clienteRepository.GetClienteByCpf(cpf);
            if (cliente is null)
                return null;
            return new GetClienteResponse
            {
                Endereco = cliente.Endereco,
                Login = cliente.Login,
                Nome = cliente.Nome
            };
        }
    }
}
