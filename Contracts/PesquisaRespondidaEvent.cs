namespace Contracts;

public record PesquisaRespondidaEvent
{
    public DateTime OccurredOn { get; init; }
    public long PesquisaId { get; init; }
    public string NomeRespondente { get; init; }
    public string EmailRespondente { get; init; }
    public int IdadeRespondente { get; init; }
    public HashSet<long> RespostasIds { get; init; }
}