using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Shop.DTO;
using System.Text.Json.Serialization;

namespace Shop.Services
{
    public class AuthService
    {
        private readonly AccessTokenService accessTokenService;
        private readonly RefreshTokenService refreshTokenService;
        private readonly NavigationManager nav;
        private HttpClient client;

        public AuthService(
            AccessTokenService accessTokenService,
            RefreshTokenService refreshTokenService,
            NavigationManager nav,
            IHttpClientFactory httpClientFactory
            )
        {
            this.accessTokenService = accessTokenService;
            this.refreshTokenService = refreshTokenService;
            this.nav = nav;
            client=httpClientFactory.CreateClient("ApiClient");
        }


        public async Task<bool> Login(string username,string password)
        {
            var status = await client.PostAsJsonAsync("api/v1.0/Secutiry/GenerateToken", new { username });
            if (status.IsSuccessStatusCode) 
            { 
               var token=await status.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuthResponse>(token);
                await accessTokenService.RemoveToken();
                await accessTokenService.SetToken(result.token);
                //await refreshTokenService.Set(result.RefreshToken);
                return true;
            }
            else
            {
                return false;
            }

        }
        //public async Task<bool> Login(string email,string password)
        //{
        //    var status = await client.PostAsJsonAsync("auth", new { email, password });
        //    if (status.IsSuccessStatusCode) 
        //    { 
        //       var token=await status.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<AuthResponse>(token);
        //        await accessTokenService.RemoveToken();
        //        await accessTokenService.SetToken(result.AccessToken);
        //        await refreshTokenService.Set(result.RefreshToken);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
        //public async Task<bool> RefreshTokenAsync()
        //{
        //    var refreshToken = await refreshTokenService.Get();
        //    client.DefaultRequestHeaders.Add("Cookie", $"refreshToken={refreshToken}");

        //    var responseMessage = await client.PostAsync("auth/refresh", null);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //       var token=await responseMessage.Content.ReadAsStringAsync();
        //        if (!string.IsNullOrEmpty(token))
        //        {
        //            var result=JsonConvert.DeserializeObject<AuthResponse>(token);
        //            await accessTokenService.SetToken(result.AccessToken);
        //            await refreshTokenService.Set(result.RefreshToken);
        //            return true;
        //        }
                
        //    }
        //    return false;
        //}
        public async Task Logout()
        {
            //var refreshToken = await refreshTokenService.Get();
            //client.DefaultRequestHeaders.Add("Cookie", $"refreshToken={refreshToken}");

            //var responseMessage = await client.PostAsync("auth/logout", null);
            //if (responseMessage.IsSuccessStatusCode)
            //{

            //}
            await accessTokenService.RemoveToken();
            await refreshTokenService.Remove();
            nav.NavigateTo("/login", forceLoad: true);
        }
    }
}
