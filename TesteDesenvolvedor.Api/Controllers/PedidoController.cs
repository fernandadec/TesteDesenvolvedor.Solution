using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvedor.Api.Models;
using TesteDesenvolvedor.Domain.Domain;
using TesteDesenvolvedor.Domain.Helpers;
using TesteDesenvolvedor.Domain.Validations;
using TesteDesenvolvedor.Services.Interfaces.InterfaceService;

namespace TesteDesenvolvedor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IServicePedido _IServicePedido;
        PedidoHelper pedidoHelper = new PedidoHelper();
        EmailHelper emailHelper=new EmailHelper();

        public PedidoController(IMapper IMapper, IServicePedido IServicePedido)
        {
            _IMapper = IMapper;
            _IServicePedido = IServicePedido;
        }

        [HttpPost("/api/AddPedido")]
        public async Task<IActionResult> AddPedidoAsync([FromBody] PedidoViewModel pedido)
        {
            try
            {
                string Erros="";
                var pedidoMap = _IMapper.Map<Pedido>(pedido);

                PedidoValidation validator = new PedidoValidation();

                     

                ValidationResult results = validator.Validate(pedidoMap);
                if (!results.IsValid)
                {
                    foreach (var errors in results.Errors)
                    {
                        Erros = errors.ErrorMessage + " ";
                    }
                    return StatusCode(500, $"Campos não preenchidos corretamente: {Erros}");
                }

                await _IServicePedido.Adicionar(SomaValores(pedidoMap));

                //disparar e-mail com os dados
                SendEmail(pedidoMap);


                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar o pedido: {ex.Message}");
            }

        }

        private Pedido SomaValores(Pedido pedido)
        {
            pedido.ValorTotal=pedidoHelper.SomaValoreTotal(pedido);
            foreach (var item in pedido.Itens)
            {
                item.ValorTotal=pedidoHelper.SomaValoreItem(item);
            }
            return pedido;
        }

        private bool SendEmail(Pedido pedido)
        {
            var ret= emailHelper.SendEmailAsync(pedido);
            if (ret.Result ==true)
                return true;
            else
                return false;
            
        }
    }
}
