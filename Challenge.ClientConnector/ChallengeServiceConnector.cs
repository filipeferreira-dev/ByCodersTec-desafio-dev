using Challenge.ApplicationService.Messages.Response;
using Challenge.ClientConnector.Contracts;
using Newtonsoft.Json;

namespace Challenge.ClientConnector
{
    public class ChallengeServiceConnector : IChallengeServiceConnector
    {
        HttpClient Client { get; }

        public ChallengeServiceConnector(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public async Task ImportAsync(Stream file)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/upload");

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(file), "file", "file.txtr");
            request.Content = content;

            using var response = await Client.SendAsync(request);
        }

        public async Task<IEnumerable<MerchantResponse>> GetAllMerchants()
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/merchants");
            using var response = await Client.SendAsync(request);
            return await DeserializeToModel<IEnumerable<MerchantResponse>>(response);
        }

        private async Task<T> DeserializeToModel<T>(HttpResponseMessage response)
        {
            var stream = await response.Content
                .ReadAsStreamAsync();

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();

                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
