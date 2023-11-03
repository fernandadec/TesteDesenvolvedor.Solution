using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TesteDesenvolvedor.Domain.Domain;
using TesteDesenvolvedor.Infra.Context;
using TesteDesenvolvedor.Infra.Repository.Generics;
using TesteDesenvolvedor.Services.Interfaces;

namespace TesteDesenvolvedor.Infra.Repository
{
    public class PedidoRepository : RepositoryGenerics<Pedido>, IPedido
    {

        private readonly DbContextOptions<TextSqlContext> _OptionsBuilder;

        public PedidoRepository()
        {
            _OptionsBuilder = new DbContextOptions<TextSqlContext>();
        }

        public async Task<List<Pedido>> ListarMessage(Expression<Func<Pedido, bool>> exMessage)
        {
            using (var banco = new TextSqlContext(_OptionsBuilder))
            {
                return await banco.Pedidos.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
