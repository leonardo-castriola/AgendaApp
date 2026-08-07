namespace AgendaApp.Api.Dtos
{
    public record TarefaResponse(
            Guid id,
            string nome,
            DateTime dataHoraInicio,
            DateTime dataHoraFim,
            string prioridade,
            string categoria
        );
}
