using ApiLoja.Core.Entities;
using ApiLoja.Core.Responses;
using ApiLoja.Core.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ApiLoja.Adapters.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromBody] CadastroClienteRequest cliente)
        {
            cliente.Senha = BCrypt.Net.BCrypt.HashPassword(cliente.Senha);
            _clienteService.CadastroCliente(cliente);
            return Ok();
        }

        [HttpGet("{cpf}")]
        public IActionResult IdentificarCliente(string cpf)
        {
            string pattern = @"^\d{11}$";

            if (!Regex.IsMatch(cpf, pattern))
                return BadRequest("Cpf Inválido.");

            var cliente = _clienteService.IdentificarCliente(cpf);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }
    }
}
