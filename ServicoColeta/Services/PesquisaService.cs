using Contracts;

namespace ServicoColeta.Services;

public class PesquisaService(IServiceBusEvent serviceBusEvent, ILogger<PesquisaService> logger)
{
    public async Task Publicar(PesquisaRespondidaEvent pesquisaRespondidaEvent,
        CancellationToken cancellationToken = default)
    {
        await serviceBusEvent.Publish(pesquisaRespondidaEvent, cancellationToken);
    }
}