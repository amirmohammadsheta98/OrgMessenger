﻿namespace Shop.Services
{
    public class AccessTokenService
    {
        private readonly CookieService cookieService;
        private readonly string tokenKey = "access_token";
        public AccessTokenService(CookieService cookieService)
        {
           this.cookieService = cookieService;
        }

        public async Task SetToken(string accessToken) 
        {
            await cookieService.Set(tokenKey, accessToken, 1);
        }
        public async Task<string> GetToken()
        {
            return await cookieService.Get(tokenKey);
        }
        
        public async Task RemoveToken()
        {
            await cookieService.Remove(tokenKey);
        }
    }
}
