
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDesenvolvedor.Domain.Domain
{
    public class PedidoItem:BaseEntity
    {

        public Pedido Pedido { get; set; }

        [StringLength(15)]
        public string CodigoProduto { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(10,2)")]

        public decimal ValorUnitario { get; set; }

        [Column(TypeName = "decimal(10,2)")]

        public decimal ValorTotal { get; set; }
    }
}
