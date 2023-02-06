using ClienteEndereco.Models;
using Microsoft.AspNetCore.Mvc;
using ClienteEndereco.Data;
using ClienteEndereco.Repositorios.Interfaces;

namespace ClienteEndereco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {       
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            List<Cliente> clientes = await _clienteRepositorio.BuscarTodos();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Cadastrar([FromBody] Cliente novoCliente)
        {
            Cliente cliente = await _clienteRepositorio.Adicionar(novoCliente);
            return Ok(cliente);
        }

        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> Atualizar([FromBody] List<Cliente> novosClientes)
        {
            List<Cliente> clientes = await _clienteRepositorio.Atualizar(novosClientes);
            return Ok(clientes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Apagar(int id)
        {
            Boolean apagado = await _clienteRepositorio.Apagar(id);
            return Ok(apagado);     
        }
    }
}