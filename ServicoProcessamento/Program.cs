using MassTransit;
using ServicoProcessamento;
using ServicoProcessamento.Infrastructure.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddConsumer<PesquisaRespondidaEventConsumer>();
    
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

app.UseHttpsRedirection();

app.Run();

