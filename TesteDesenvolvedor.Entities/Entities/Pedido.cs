using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDesenvolvedor.Domain.Domain
{
    public class Pedido : BaseEntity
    {

        [StringLength(50)]
        public string EmailCliente { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPedido { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }
}
