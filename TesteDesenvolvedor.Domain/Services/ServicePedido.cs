using TesteDesenvolvedor.Domain.Domain;
using TesteDesenvolvedor.Services.Interfaces;
using TesteDesenvolvedor.Services.Interfaces.InterfaceService;

namespace TesteDesenvolvedor.Services.Services
{
    public class ServicePedido : IServicePedido
    {
        private readonly IPedido _IPedido;

        public ServicePedido(IPedido IPedido)
        {
            _IPedido = IPedido;
        }

        public async Task Adicionar(Pedido pedido)
        {
            await _IPedido.Add(pedido);
        }

        public async Task<Pedido> GetByiDAsync(int id)
        {
            return await _IPedido.GetEntityById(id);

        }
        public Task Atualizar(Pedido Objeto)
        {
            throw new NotImplementedException();
        }
    }

}
