using Contracts;
using MassTransit;

namespace ServicoProcessamento.Infrastructure.Consumers;

internal sealed class PesquisaRespondidaEventConsumer(ILogger<PesquisaRespondidaEventConsumer> logger) : IConsumer<PesquisaRespondidaEvent>
{
    public Task Consume(ConsumeContext<PesquisaRespondidaEvent> context)
    {
        logger.LogInformation("Pesquisa respondida recebida: {Event}", context.Message);
        return Task.CompletedTask;
    }
}