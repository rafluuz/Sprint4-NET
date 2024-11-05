using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SustenAI.Models.Mappings
{
    public class PrevisaoMapping : IEntityTypeConfiguration<Previsao>
    {
        public void Configure(EntityTypeBuilder<Previsao> builder)
        {
            builder.ToTable("sustenAI_previsoes");

            builder.HasKey(p => p.IdPrev);

            builder.Property(p => p.IdPrev)
                .HasColumnName("id_prev")
                .IsRequired();

            builder.Property(p => p.IdProd)
                .HasColumnName("id_prod")
                .IsRequired();

            builder.Property(p => p.PrecisaoPrev)
                .HasColumnName("precisao_prev");

            builder.Property(p => p.DataHoraPrev)
                .HasColumnName("data_hora_prev");

            builder.Property(p => p.UltimaAtt)
                .HasColumnName("ultima_att");

        }
    }
}
