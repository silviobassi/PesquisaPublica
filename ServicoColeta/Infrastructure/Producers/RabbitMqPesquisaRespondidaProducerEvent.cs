using MassTransit;
using ServicoColeta.Services;

namespace ServicoColeta.Infrastructure.Producers;

public class RabbitMqPesquisaRespondidaProducerEvent(
    IPublishEndpoint publishEndpoint,
    ILogger<RabbitMqPesquisaRespondidaProducerEvent> logger) : IServiceBusEvent
{
    public async Task Publish<T>(T @event, CancellationToken cancellationToken = default) where T : class
    {
        await publishEndpoint.Publish(@event, cancellationToken);
        logger.LogInformation("Pesquisa respondida publicada com sucesso: {Event}", @event);
    }
}