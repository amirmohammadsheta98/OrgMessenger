using System.Text.Json.Serialization;

namespace OrgMessenger.DTO
{
    public class MyInfoDto
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;

        [JsonPropertyName("socketId")]
        public string SocketId { get; set; } = string.Empty;
    }

    public class UserItemDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;
    }
    public class PrivateChatDto
    {
        [JsonPropertyName("fromUserName")]
        public string FromUserName { get; set; } = string.Empty;

        [JsonPropertyName("lastMessage")]
        public string LastMessage { get; set; } = string.Empty;

        [JsonPropertyName("createDate")]
        public long CreateDate { get; set; }

        [JsonPropertyName("isRtl")]
        public bool IsRtl { get; set; }

        [JsonPropertyName("countOfUnreadMessage")]
        public int CountOfUnreadMessage { get; set; }

        [JsonPropertyName("pkEmployee")]
        public string PkEmployee { get; set; } = string.Empty;

        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("sentUser")]
        public string SentUser { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("lastMessageId")]
        public string LastMessageId { get; set; } = string.Empty;

        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        [JsonPropertyName("roomType")]
        public string RoomType { get; set; } = string.Empty;

        [JsonPropertyName("forwardedBy")]
        public string? ForwardedBy { get; set; }

        [JsonPropertyName("replyOf")]
        public string? ReplyOf { get; set; }
    }
}
