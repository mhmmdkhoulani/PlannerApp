using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlannerApp
{
    public class AuthoraizationMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _storage;

        public AuthoraizationMessageHandler(ILocalStorageService storage)
        {
            _storage = storage;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           if(await _storage.ContainKeyAsync("access_token"))
            {
                var token = await _storage.GetItemAsStringAsync("access_token");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            System.Console.WriteLine("Authoraization message handler called");
            return await base.SendAsync(request, cancellationToken);
        }

    }
}
