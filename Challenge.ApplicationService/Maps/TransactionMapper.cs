using Challenge.ApplicationService.Messages.Response;
using Challenge.Domain.Enums;
using Challenge.Domain.Models;

namespace Challenge.ApplicationService.Maps
{
    public static class TransactionMapper
    {
        public static TransactionResponse MapToResponse(this Transaction entity) => new TransactionResponse
        {
            Id = entity.Id,
            Type = Enum.GetName(typeof(TransactionTypeEnum), entity.Type) ?? " - ",
            Date = entity.Date,
            Amount = entity.Amount,
            Document = entity.Document,
            Card = entity.Card
        };

        public static IEnumerable<TransactionResponse> MapToResponse(this IEnumerable<Transaction> entities) => entities.Select(e => e.MapToResponse());
    }
}
