using ClienteEndereco.Data;
using ClienteEndereco.Models;
using ClienteEndereco.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClienteEndereco.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly PbsTesteContext _context;

        public ClienteRepositorio(PbsTesteContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> Apagar(int id)
        {
            Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
            {
                throw new Exception($"O Cliente com o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cliente>> Atualizar(List<Cliente> clientes)
        {
            _context.Clientes.UpdateRange(clientes);
            await _context.SaveChangesAsync();
            return clientes;
        }

        public async Task<List<Cliente>> BuscarTodos()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
