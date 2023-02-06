using ClienteEndereco.Models;

namespace ClienteEndereco.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {       
        Task<Cliente> Adicionar(Cliente cliente);
        Task<List<Cliente>> BuscarTodos();
        Task<List<Cliente>> Atualizar(List<Cliente> clientes);
        Task<bool> Apagar(int id);

    }
}
