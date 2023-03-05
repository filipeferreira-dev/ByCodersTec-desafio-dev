using Challenge.ApplicationService.Messages.Response;

namespace Challenge.ClientConnector.Contracts
{
    public interface IChallengeServiceConnector
    {
        Task ImportAsync(Stream file);


        Task<IEnumerable<MerchantResponse>> GetAllMerchants();
    }
}
