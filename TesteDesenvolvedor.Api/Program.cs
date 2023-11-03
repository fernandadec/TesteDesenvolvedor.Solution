using AutoMapper;
using FluentValidation;
using System;
using TesteDesenvolvedor.Api.Models;
using TesteDesenvolvedor.Domain.Domain;
using TesteDesenvolvedor.Domain.Validations;
using TesteDesenvolvedor.Infra.Repository;
using TesteDesenvolvedor.Services.Interfaces;
using TesteDesenvolvedor.Services.Interfaces.InterfaceService;
using TesteDesenvolvedor.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<PedidoItemViewModel, PedidoItem>();
    cfg.CreateMap<PedidoViewModel, Pedido>();
});
IMapper mapper = config.CreateMapper();

// INTERFACE E REPOSITORIO
builder.Services.AddSingleton<IPedidoItem, PedidoItemRepository>();
builder.Services.AddSingleton<IPedido, PedidoRepository>();


// SERVIÇO DOMINIO
builder.Services.AddSingleton<IServicePedido, ServicePedido>();

//VALIDATION
builder.Services.AddScoped<IValidator<Pedido>, PedidoValidation>();


builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
