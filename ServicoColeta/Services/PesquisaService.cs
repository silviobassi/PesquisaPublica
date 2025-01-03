using Contracts;

namespace ServicoColeta.Services;

public class PesquisaService(IServiceBus serviceBus, ILogger<PesquisaService> logger)
{
    public async Task Publicar(PesquisaRespondidaEvent pesquisaRespondidaEvent,
        CancellationToken cancellationToken = default)
    {
        await serviceBus.Publish(pesquisaRespondidaEvent, cancellationToken);
    }
}