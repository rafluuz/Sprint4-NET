using SustenAI.Models;

namespace SustenAI.Repository
{
    public interface IPrevisaoRepository
    {
        Task<List<Previsao>> BuscarTodasPrevisoes();
        Task<Previsao> BuscarPorId(int id);
        Task<Previsao> Adicionar(Previsao previsao);
        Task<Previsao> Atualizar(Previsao previsao, int id);
        Task<bool> Apagar(int id);
    }
}
