
namespace TesteDesenvolvedor.Api.Models
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public string EmailCliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public List<PedidoItemViewModel> Itens { get; set; }
    }
}
