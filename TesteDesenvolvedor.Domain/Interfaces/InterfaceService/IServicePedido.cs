using TesteDesenvolvedor.Domain.Domain;

namespace TesteDesenvolvedor.Services.Interfaces.InterfaceService
{
    public interface IServicePedido
    {
        Task Adicionar(Pedido pedido);
        Task Atualizar(Pedido Objeto);
        Task<Pedido> GetByiDAsync(int id);

    }
}
