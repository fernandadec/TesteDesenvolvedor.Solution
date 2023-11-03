using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain.Domain;
using TesteDesenvolvedor.Infra.Mappings;

namespace TesteDesenvolvedor.Infra.Context
{
    public class TextSqlContext : DbContext
    {
        public TextSqlContext() { }
        public TextSqlContext(DbContextOptions<TextSqlContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PedidoItem>(new Mappings.PedidoItemMap().Configure);
            modelBuilder.Entity<Pedido>(new PedidoMap().Configure);
        }

        public string ObterStringConexao()
        {
            return "Data Source=USU-BCK1EGQQNPU;Initial Catalog=TesteDesenvolvedor;Integrated Security=False;User ID=teste;Password=123456;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }

    }
}
