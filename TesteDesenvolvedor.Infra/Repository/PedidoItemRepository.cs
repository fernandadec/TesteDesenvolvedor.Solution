using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TesteDesenvolvedor.Domain.Domain;
using TesteDesenvolvedor.Infra.Context;
using TesteDesenvolvedor.Infra.Repository.Generics;
using TesteDesenvolvedor.Services.Interfaces;

namespace TesteDesenvolvedor.Infra.Repository
{
    public class PedidoItemRepository : RepositoryGenerics<PedidoItem>, IPedidoItem
    {

        private readonly DbContextOptions<TextSqlContext> _OptionsBuilder;

        public PedidoItemRepository()
        {
            _OptionsBuilder = new DbContextOptions<TextSqlContext>();
        }

        public async Task<List<PedidoItem>> ListarMessage(Expression<Func<PedidoItem, bool>> exMessage)
        {
            using (var banco = new TextSqlContext(_OptionsBuilder))
            {
                return await banco.PedidoItem.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
