namespace ServicoColeta.Services;

public interface IServiceBus
{
    public Task Publish<T>(T @event, CancellationToken cancellationToken = default) where T : class;
}