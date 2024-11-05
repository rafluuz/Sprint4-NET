using SustenAI.Models;

namespace SustenAI.Repository
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> BuscarTodosProdutos();
        Task<Produto> BuscarPorId(int id);
        Task<Produto> Adicionar(Produto produto);
        Task<Produto> Atualizar(Produto produto, int id);
        Task<bool> Apagar(int id);
    }
}
