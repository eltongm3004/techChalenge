using ApiLoja.Adapters.Repositories;
using ApiLoja.Adapters.Validation;
using ApiLoja.Core.Interfaces;
using ApiLoja.Core.Services;
using FluentValidation.AspNetCore;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicione servi�os ao cont�iner.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IgnoreNullValues = true;
    // Ignore null values during serialization
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<Program>();
    x.DisableDataAnnotationsValidation = true;
});
builder.Services.AddSwaggerGen();

// Configura��o da conex�o com o banco de dados
builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetSection("DefaultConnection").Value));

// Registro de reposit�rios e servi�os
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<PedidoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapControllers();

app.Run();
