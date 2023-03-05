using Challenge.ApplicationService.Maps;
using Challenge.ApplicationService.Messages.Response;
using Challenge.ApplicationService.Services.Contracts;
using Challenge.Domain.Repositories;

namespace Challenge.ApplicationService.Services
{
    public class MerchantApplicationService : IMerchantApplicationService
    {
        IMerchantRepository MerchantRepository { get; }

        public MerchantApplicationService(IMerchantRepository merchantRepository)
        {
            MerchantRepository = merchantRepository;
        }

        public async Task<IEnumerable<MerchantResponse>> GetAll()
        {
            var merchants = await MerchantRepository.GetAllAsync();
;           return merchants.MapToResponse();
        }
    }
}
