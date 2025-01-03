using MassTransit;
using ServicoColeta;
using ServicoColeta.EndPoints;
using ServicoColeta.Infrastructure;
using ServicoColeta.Infrastructure.Producers;
using ServicoColeta.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<PesquisaService>();
builder.Services.AddScoped<IServiceBus, RabbitMqPesquisaRespondidaProducerEvent>();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        var connection = builder.Configuration.GetValue<string>("ConnectionString:RabbitMQ");
        configurator.Host(connection);
        configurator.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.AddEndpoints();

app.UseHttpsRedirection();


app.Run();