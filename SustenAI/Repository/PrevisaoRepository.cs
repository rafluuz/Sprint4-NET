using Microsoft.EntityFrameworkCore;
using SustenAI.DataBase;
using SustenAI.Models;

namespace SustenAI.Repository
{
    public class PrevisaoRepository : IPrevisaoRepository
    {
        private readonly SustenAIDBContext _dbContext;

        public PrevisaoRepository(SustenAIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Previsao>> BuscarTodasPrevisoes()
        {
            return await _dbContext.Previsoes.ToListAsync();
        }

        public async Task<Previsao> BuscarPorId(int id)
        {
            return await _dbContext.Previsoes.FirstOrDefaultAsync(x => x.IdPrev == id);
        }

        public async Task<Previsao> Adicionar(Previsao previsao)
        {
            await _dbContext.Previsoes.AddAsync(previsao);
            await _dbContext.SaveChangesAsync();
            return previsao;
        }

        public async Task<Previsao> Atualizar(Previsao previsao, int id)
        {
            Previsao previsaoPorId = await BuscarPorId(id);

            if (previsaoPorId == null)
            {
                throw new Exception($"Previsão para o ID: {id} não foi encontrada no banco de dados.");
            }

            previsaoPorId.PrecisaoPrev = previsao.PrecisaoPrev;
            previsaoPorId.DataHoraPrev = previsao.DataHoraPrev;
            previsaoPorId.UltimaAtt = previsao.UltimaAtt;

            _dbContext.Previsoes.Update(previsaoPorId);
            await _dbContext.SaveChangesAsync();
            return previsaoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Previsao previsaoPorId = await BuscarPorId(id);

            if (previsaoPorId == null)
            {
                throw new Exception($"Previsão para o ID: {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Previsoes.Remove(previsaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}