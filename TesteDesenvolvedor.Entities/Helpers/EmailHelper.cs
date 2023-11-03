using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using SendGrid.Helpers.Mail;
using TesteDesenvolvedor.Domain.Domain;

namespace TesteDesenvolvedor.Domain.Helpers
{
    public class EmailHelper
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailHelper() { }
        public EmailHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> SendEmailAsync(Pedido pedido)
        {
            try
            {
                var client = _serviceProvider.GetRequiredService<ISendGridClient>();
                string body = $"Prezado Cliente sua compra foi realizada com sucesso";
                body +="Data do Pedido: "+ pedido.DataPedido.ToString();
                body +="Valor total do Pedido: "+ pedido.ValorTotal.ToString();
                body +="Itens: ";
                foreach (var item in pedido.Itens)
                {
                    body +="Codigo do Produto: "+ item.CodigoProduto;
                    body +="Valor Unitário: "+ item.ValorUnitario;
                    body +="Quantidade: "+ item.Quantidade;
                    body +="Valor Total Item: "+ item.ValorTotal;
                }
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(pedido.EmailCliente, "Cliente"),
                    Subject = "Compra Efetuada",
                    PlainTextContent = body
                };
                msg.AddTo(new EmailAddress(pedido.EmailCliente));
                var response = await client.SendEmailAsync(msg);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
