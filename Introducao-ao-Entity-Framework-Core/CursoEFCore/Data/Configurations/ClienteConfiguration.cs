using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations
{
    public class ClienteConfigurations : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Telefone).HasColumnType("CHAR(11)");
            builder.Property(P => P.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(P => P.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(P => P.Cidade).HasMaxLength(60).IsRequired();

            // No curso estava: 'HasName' e no Entity Framework Core é obsoleto, trocando por 'HasDatabaseName'
            builder.HasIndex(i => i.Telefone).HasDatabaseName("idx_cliente_telefone"); 
        }
    }
}