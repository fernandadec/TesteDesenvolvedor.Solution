using FluentValidation;
using TesteDesenvolvedor.Domain.Domain;

namespace TesteDesenvolvedor.Domain.Validations
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
            RuleFor(c => c.EmailCliente)
               .NotEmpty().WithMessage("Informe o e-mail.")
               .EmailAddress().WithMessage("E-mail invalido");
            RuleFor(c => c.DataPedido)
              .NotEmpty().WithMessage("Informe a data do pedido.");

        }

    }
}
