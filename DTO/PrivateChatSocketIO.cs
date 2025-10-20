using System.Text.Json.Serialization;

namespace OrgMessenger.DTO
{
    public class PrivateChatSocketIODto
    {
        [JsonPropertyName("commandName")]
        public string CommandName { get; set; } = "privateChat";

        [JsonPropertyName("data")]
        public ChatCommandDataDto Data { get; set; } = new ChatCommandDataDto();
    }

    public class ChatCommandDataDto
    {
        [JsonPropertyName("to")] public string To { get; set; } = string.Empty;
        [JsonPropertyName("message")] public string Message { get; set; } = string.Empty;
        [JsonPropertyName("isRtl")] public bool IsRtl { get; set; } = true;
        [JsonPropertyName("clientTime")] public long ClientTime { get; set; }
        [JsonPropertyName("attachmentId")] public long AttachmentId { get; set; }
        [JsonPropertyName("forwardedBy")] public string ForwardedBy { get; set; } = string.Empty;
        [JsonPropertyName("replyOf")] public string ReplyOf { get; set; } = string.Empty;
    }


    
}
