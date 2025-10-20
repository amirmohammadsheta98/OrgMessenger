using OrgMessenger.DTO;
using Shop.Services;
using SocketIOClient;

public class SocketService
{
    private readonly AccessTokenService _tokenService;
    private SocketIOClient.SocketIO? _client;

    public SocketService(AccessTokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public async Task ConnectAsync()
    {
        var token = await _tokenService.GetToken(); // حالا JS interop آزاد شده
        _client = new SocketIOClient.SocketIO("http://92.115.25.140:3000/", new SocketIOOptions
        {
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket,
            AutoUpgrade = true, // 👈 اجازه میده از polling به websocket بره
            Reconnection = true,
            ConnectionTimeout = TimeSpan.FromSeconds(10),
            ExtraHeaders = new Dictionary<string, string>
            {
                { "authorization", $"Bearer {token}" }
            }
        });

        _client.On("myInfo", res => MyInfoReceived?.Invoke(res.GetValue<MyInfoDto>()));
        _client.On("getUsers", res => UsersReceived?.Invoke(res.GetValue<List<UserItemDto>>()));
        _client.On("privateChat", res => PrivateChatReceived?.Invoke(res.GetValue<PrivateChatDto>()));
        Console.WriteLine("Auth Header: " + _client.Options.ExtraHeaders["authorization"]);

        await _client.ConnectAsync();
        await _client.EmitAsync("getUsers");
    }

    public event Action<MyInfoDto>? MyInfoReceived;
    public event Action<List<UserItemDto>>? UsersReceived;
    public event Action<PrivateChatDto>? PrivateChatReceived;
}
