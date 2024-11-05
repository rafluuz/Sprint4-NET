using Microsoft.EntityFrameworkCore;
using SustenAI.DataBase;
using SustenAI.Models;

namespace SustenAI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SustenAIDBContext _dbContext;

        public ProdutoRepository(SustenAIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.IdProd == id);
        }

        public async Task<Produto> Adicionar(Produto produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Atualizar(Produto produto, int id)
        {
            Produto produtoExistente = await BuscarPorId(id);

            if (produtoExistente == null)
            {
                throw new Exception($"Produto com ID {id} não encontrado.");
            }

            produtoExistente.NomeProd = produto.NomeProd;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.Origem = produto.Origem;
            produtoExistente.Avaliacao = produto.Avaliacao;
            produtoExistente.DataAtual = produto.DataAtual;
            produtoExistente.DataCriacao = produto.DataCriacao;
            produtoExistente.UltimaAtt = produto.UltimaAtt;

            _dbContext.Produtos.Update(produtoExistente);
            await _dbContext.SaveChangesAsync();

            return produtoExistente;
        }

        public async Task<bool> Apagar(int id)
        {
            Produto produtoExistente = await BuscarPorId(id);

            if (produtoExistente == null)
            {
                throw new Exception($"Produto com ID {id} não encontrado.");
            }

            _dbContext.Produtos.Remove(produtoExistente);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}