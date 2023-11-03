using TesteDesenvolvedor.Domain.Domain;

namespace TesteDesenvolvedor.Domain.Helpers
{
    public class PedidoHelper
    {
        public decimal SomaValoreTotal(Pedido pedido)
        {
            decimal soma = 0;
            foreach (var itens in pedido.Itens)
            {
                soma=soma+(itens.ValorUnitario*itens.Quantidade);
            }
            return soma;
        }
        public decimal SomaValoreItem(PedidoItem pedidoItem)
        {
            return pedidoItem.ValorUnitario*pedidoItem.Quantidade;
        }
    }
}
