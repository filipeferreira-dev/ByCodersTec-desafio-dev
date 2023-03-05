using Newtonsoft.Json;
using Challenge.ApplicationService.Employees.Messages;
using Challenge.ClientConnection.Contract;
using System.Text;

namespace Challenge.ClientConnection
{
    public class NutcacheServiceClient : IChallengeServiceClient
    {
        HttpClient Client { get; }
        public NutcacheServiceClient(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public async Task<EmployeeResponse> UpdateEmployeeAsync(EmployeeRequest employeeRequest)
        {
            using var request = CreateRequest(HttpMethod.Put, $"/api/employee", employeeRequest);
            using var response = await Client.SendAsync(request);
            return await DeserializeToModel<EmployeeResponse>(response);
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"/api/employee/{id}");
            using var response = await Client.SendAsync(request);
            await DeserializeToModel<EmployeeResponse>(response);
        }

        public async Task<EmployeeResponse> GetEmployeeByIdAsync(long id)
        {
            using var request = CreateRequest(HttpMethod.Get, $"/api/employee/{id}");
            using var response = await Client.SendAsync(request);
            return await DeserializeToModel<EmployeeResponse>(response);
        }

        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync()
        {
            using var request = CreateRequest(HttpMethod.Get, $"/api/employee");
            using var response = await Client.SendAsync(request);
            return await DeserializeToModel<IEnumerable<EmployeeResponse>>(response);
        }

        public async Task<EmployeeResponse> CreateEmployeeAsync(EmployeeRequest employeeRequest)
        {
            using var request = CreateRequest(HttpMethod.Post, $"/api/employee", employeeRequest);
            using var response = await Client.SendAsync(request);
            return await DeserializeToModel<EmployeeResponse>(response);
        }

        private HttpRequestMessage CreateRequest<T>(HttpMethod method, string uri, T model)
        {
            return new HttpRequestMessage(method, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
            };
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

        private HttpRequestMessage CreateRequest(HttpMethod method, string uri)
        {
            return new HttpRequestMessage(method, uri);
        }
    }
}
