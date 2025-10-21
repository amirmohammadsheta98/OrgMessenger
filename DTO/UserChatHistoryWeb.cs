namespace OrgMessenger.DTO
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ChatHistory
    {
        [JsonProperty("fromUserName")]
        public string FromUserName { get; set; }

        [JsonProperty("toUserName")]
        public string ToUserName { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("chatStatus1")]
        public string ChatStatus1 { get; set; }
    }

    public class UserChatHistoryWeb
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("warnings")]
        public List<string> Warnings { get; set; }

        [JsonProperty("history")]
        public Dictionary<string, List<ChatHistory>> History { get; set; }
    }
    
    public class ContactDto
    {
        public string UserName { get; set; }
        public bool IsOnline { get; set; } 
    }

}
