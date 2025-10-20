using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace Shop.Services
{
    public class ApiService
    {
        private HttpClient client;
        private readonly AccessTokenService tokenService;
        private readonly AuthService authService;
        private readonly NavigationManager nav;
        public ApiService(
            IHttpClientFactory httpFactory,
            AccessTokenService tokenService,
            AuthService authService,
            NavigationManager nav
            )
        {
            client = httpFactory.CreateClient("ApiClient");
            this.tokenService = tokenService;
            this.authService = authService;
            this.nav = nav;
        }


        public async Task<HttpResponseMessage>GetAsync(string endpoint)
        {
            var token = await tokenService.GetToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage=await client.GetAsync(endpoint);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //var refreshTokenResult=await authService.RefreshTokenAsync();
                //if (!refreshTokenResult)
                await authService.Logout();

                var newToken =await tokenService.GetToken();
                client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", newToken);

                var newResponse=await client.GetAsync(endpoint);
                return newResponse;
            }
            return responseMessage;

        }

        public async Task<HttpResponseMessage> PostDataAsync(string endpoint,object obj)
        {
            var token = await tokenService.GetToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.PostAsJsonAsync(endpoint,obj);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //var refreshTokenResult = await authService.RefreshTokenAsync();
                //if (!refreshTokenResult)

                await authService.Logout();
                var newToken = await tokenService.GetToken();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken);

                var newResponse = await client.PostAsJsonAsync(endpoint,obj);
                return newResponse;
            }
            return responseMessage;
        }
    }
}
