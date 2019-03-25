using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var protocolClient = new HttpClient();

            var disco = await protocolClient.GetDiscoveryDocumentAsync("http://localhost:50000");
            if (disco.IsError) throw new Exception(disco.Error);

            var tokenResponse = await protocolClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "fiver_auth_client",
                ClientSecret = "secret"
            });

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            Console.WriteLine(await apiClient.GetStringAsync("https://localhost:44308/api/values"));
            Console.ReadKey();
        }
    }
}
