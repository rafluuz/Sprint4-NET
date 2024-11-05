using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SustenAI.Models.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("sustenAI_usuarios");

            builder.HasKey(u => u.IdUser);

            builder.Property(u => u.IdUser)
                .HasColumnName("id_user")
                .IsRequired();

            builder.Property(u => u.NomeEmp)
                .HasColumnName("nome_emp")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("senha")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Cnpj)
                .HasColumnName("cnpj")
                .HasMaxLength(14)
                .IsRequired();

        }
    }
}