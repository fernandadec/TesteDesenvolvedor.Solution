using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain.Domain;

namespace TesteDesenvolvedor.Infra.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd(); ;


            builder.Property(c => c.EmailCliente)
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(c => c.DataPedido)
            .HasColumnName("DataPedido");

            builder.Property(c => c.ValorTotal)
             .HasColumnName("ValorTotal");

        }
    }
}