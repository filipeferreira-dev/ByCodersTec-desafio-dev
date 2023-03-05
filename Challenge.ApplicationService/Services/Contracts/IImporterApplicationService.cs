namespace Challenge.ApplicationService.Services.Contracts
{
    public interface IImporterApplicationService
    {
        Task ImportAsync(Stream file);
    }
}
