using Microsoft.EntityFrameworkCore;
using SustenAI.DataBase;
using SustenAI.Models;
using SustenAI.Repository;

public class UserRepositoryTests : IDisposable
{
    private readonly UserRepository _repository;
    private readonly SustenAIDBContext _context;

    public UserRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<SustenAIDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new SustenAIDBContext(options);
        _context.Database.EnsureCreated();

        _repository = new UserRepository(_context);
    }

    [Fact]
    public async Task Adicionar_Usuario_Deve_Salvar_Usuario()
    {
        var usuario = new Usuario
        {
            NomeEmp = "Teste",
            Email = "teste@teste.com",
            Cnpj = "12345678000195",
            Senha = "senhaSegura123"
        };

        var result = await _repository.Adicionar(usuario);

        var savedUsuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUser == result.IdUser);
        Assert.NotNull(savedUsuario);
        Assert.Equal("Teste", savedUsuario.NomeEmp);
        Assert.Equal("teste@teste.com", savedUsuario.Email);
        Assert.Equal("12345678000195", savedUsuario.Cnpj);
        Assert.Equal("senhaSegura123", savedUsuario.Senha);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted(); 
        _context.Dispose();
    }
}
