using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SustenAI.Models.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("susten_produtos");

            builder.HasKey(p => p.IdProd);

            builder.Property(p => p.IdProd)
                .HasColumnName("id_prod")
                .IsRequired();

            builder.Property(p => p.NomeProd)
                .HasColumnName("nome_prod")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("preco")
                .IsRequired();

            builder.Property(p => p.Origem)
                .HasColumnName("origem")
                .HasMaxLength(100);


            builder.Property(p => p.Avaliacao)
                .HasColumnName("avaliacao")
                .HasMaxLength(50);

            builder.Property(p => p.DataAtual)
                .HasColumnName("data_atual");

            builder.Property(p => p.DataCriacao)
                .HasColumnName("data_criacao");

            builder.Property(p => p.UltimaAtt)
                .HasColumnName("ultima_att");

           
        }
    }
}
