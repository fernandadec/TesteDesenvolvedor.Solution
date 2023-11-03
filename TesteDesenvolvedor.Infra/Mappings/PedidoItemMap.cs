using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain.Domain;

namespace TesteDesenvolvedor.Infra.Mappings
{
    public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.Property(c => c.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd(); ;

            builder.Property(c => c.CodigoProduto)
            .HasColumnName("CodigoProduto");

            builder.Property(c => c.Quantidade)
            .HasColumnName("Quantidade");

            builder.Property(c => c.ValorUnitario)
             .HasColumnName("ValorUnitario");


        }
    }
}
