namespace TesteDesenvolvedor.Api.Models
{
    public class PedidoItemViewModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
