using Microsoft.EntityFrameworkCore;
using SustenAI.Models;
using SustenAI.Models.Mappings;

namespace SustenAI.DataBase
{
    public class SustenAIDBContext : DbContext
    {

        public SustenAIDBContext(DbContextOptions<SustenAIDBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Previsao> Previsoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new PrevisaoMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}

