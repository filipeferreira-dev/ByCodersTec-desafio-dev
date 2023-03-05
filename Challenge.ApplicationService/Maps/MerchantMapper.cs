using Challenge.ApplicationService.Messages.Response;
using Challenge.Domain.Models;

namespace Challenge.ApplicationService.Maps
{
    public static class MerchantMapper
    {
        public static MerchantResponse MapToResponse(this Merchant entity)
        =>  new MerchantResponse 
            { 
                Id = entity.Id,
                Balance = entity.Balance,
                Name = entity.Name,
                Owner = entity.Owner,
                Transactions = entity.Transactions.MapToResponse(),
            };

        public static IEnumerable<MerchantResponse> MapToResponse(this IEnumerable<Merchant> entities) => entities.Select(e => e.MapToResponse());

    }
}
