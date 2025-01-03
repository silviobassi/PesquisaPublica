using Contracts;
using Microsoft.AspNetCore.Mvc;
using ServicoColeta.Services;

namespace ServicoColeta.EndPoints;

public static class ApiEndpoints
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.MapPost("/pesquisas-publica/enviar_resposta",
            async ([FromServices] PesquisaService pesquisaService,
                [FromBody] PesquisaRespondidaEvent pesquisaRespondidaEvent) =>
            {
                await pesquisaService.Publicar(pesquisaRespondidaEvent);
                return Results.Ok();
            });
    }
}