using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OrgMessenger.DTO;
using Shop.DTO;
using Shop.Services;
using System.Net.Http.Headers;

namespace OrgMessenger.Services.ApiReq
{
    

    public class ChatApi
    {
        public readonly ApiService apiService;

        public ChatApi(ApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<bool> PrivateChatSocketIO(PrivateChatSocketIODto request)
        {
            var status = await apiService.PostDataAsync("api/v1.0/Chat/PrivateChatSocketIO", request);
            if (status.IsSuccessStatusCode)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<UserChatHistoryWeb> UserChatHistoryWeb()
        {
            var status = await apiService.PostDataAsync("api/v1.0/Chat/UserChatHistoryWeb",null);
            if (status.IsSuccessStatusCode)
            {
                var json = await status.Content.ReadAsStringAsync();

                // مپ کردن (دی‌سریالایز) محتوای JSON به DTO
                var res = JsonConvert.DeserializeObject<UserChatHistoryWeb>(json);
                return res;
            }
            else
            {
                return new UserChatHistoryWeb();
            }
        }
    }

}
