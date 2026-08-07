namespace AgendaApp.Api.Dtos
{
    public record TarefaRequest(
            string nome,
            DateTime dataHoraInicio,
            DateTime dataHoraFim,
            int prioridade,
            Guid categoriaId
        );
}
