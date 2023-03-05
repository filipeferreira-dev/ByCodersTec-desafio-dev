using Challenge.ApplicationService.Messages.Response;

namespace Challenge.ApplicationService.Services.Contracts
{
    public interface IMerchantApplicationService
    {
        Task<IEnumerable<MerchantResponse>> GetAll();
    }
}
