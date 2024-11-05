using Microsoft.EntityFrameworkCore;
using SustenAI.DataBase;
using SustenAI.Models;
using SustenAI.Repository;

namespace SustenAI.Tests.Repository
{
    public class ProdutoRepositoryTests : IDisposable
    {
        private readonly ProdutoRepository _repository;
        private readonly SustenAIDBContext _context;

        public ProdutoRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<SustenAIDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new SustenAIDBContext(options);
            _context.Database.EnsureCreated();

            _repository = new ProdutoRepository(_context);
        }

        [Fact]
        public async Task Adicionar_Produto_Deve_Salvar_Produto()
        {
            
            var produto = new Produto
            {
                NomeProd = "Produto Teste",
                Preco = 10,
                Origem = "Nacional",
                Avaliacao = "massa"
            };

            var result = await _repository.Adicionar(produto);

            var savedProduto = await _context.Produtos.FirstOrDefaultAsync(p => p.IdProd == result.IdProd);
            Assert.NotNull(savedProduto);
            Assert.Equal("Produto Teste", savedProduto.NomeProd);
            Assert.Equal(10, savedProduto.Preco);
            Assert.Equal("Nacional", savedProduto.Origem);
            Assert.Equal("massa", savedProduto.Avaliacao);
        }

        [Fact]
        public async Task BuscarPorId_Deve_Retornar_Produto_Quando_Produto_Existe()
        {
            var produto = new Produto
            {
                NomeProd = "Produto Teste",
                Preco = 10,
                Origem = "Nacional",
                Avaliacao = "massa"
            };
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            var result = await _repository.BuscarPorId(produto.IdProd);

            Assert.NotNull(result);
            Assert.Equal(produto.NomeProd, result.NomeProd);
            Assert.Equal(produto.Preco, result.Preco);
            Assert.Equal(produto.Origem, result.Origem);
            Assert.Equal(produto.Avaliacao, result.Avaliacao);
        }

        [Fact]
        public async Task BuscarTodosProdutos_Deve_Retornar_Todos_Produtos()
        {
            var produtos = new List<Produto>
            {
                new Produto { NomeProd = "Produto 1", Preco = 10, Origem = "Nacional", Avaliacao = "top" },
                new Produto { NomeProd = "Produto 2", Preco = 20, Origem = "Importado", Avaliacao = "incrivel" }
            };
            await _context.Produtos.AddRangeAsync(produtos);
            await _context.SaveChangesAsync();

            var result = await _repository.BuscarTodosProdutos();

        }

        [Fact]
        public async Task Atualizar_Produto_Deve_Modificar_Produto_Quando_Produto_Existe()
        {
            var produto = new Produto
            {
                NomeProd = "Produto Teste",
                Preco = 10,
                Origem = "Nacional",
                Avaliacao = "massa"
            };
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            var produtoAtualizado = new Produto
            {
                NomeProd = "Produto Teste Atualizado",
                Preco = 12,
                Origem = "Internacional",
                Avaliacao = "incrivel"
            };

            var result = await _repository.Atualizar(produtoAtualizado, produto.IdProd);

            Assert.NotNull(result);
            Assert.Equal("Produto Teste Atualizado", result.NomeProd);
            Assert.Equal(12, result.Preco);
            Assert.Equal("incrivel", result.Avaliacao);
        }

        [Fact]
        public async Task Apagar_Produto_Deve_Remover_Produto_Quando_Produto_Existe()
        {
            var produto = new Produto
            {
                NomeProd = "Produto Teste",
                Preco = 10,
                Origem = "Nacional",
                Avaliacao = "massa"
            };
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            var result = await _repository.Apagar(produto.IdProd);

            Assert.True(result);
            var deletedProduto = await _repository.BuscarPorId(produto.IdProd);
            Assert.Null(deletedProduto);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
