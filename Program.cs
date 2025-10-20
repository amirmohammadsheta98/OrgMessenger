using Microsoft.AspNetCore.Components.Authorization;
using OrgMessenger.Components;
using Shop.Security;
using Shop.Services.Requests;
using Shop.Services;
using Radzen;
using OrgMessenger.Services.ApiReq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<CookieService>();
builder.Services.AddScoped<AccessTokenService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddScoped<ResourceService>();
builder.Services.AddScoped<ChatApi>();
builder.Services.AddHttpClient("ApiClient", opt =>
{
    //opt.BaseAddress = new Uri("https://localhost:7171/api/");
    opt.BaseAddress = new Uri("http://82.115.25.140:5233/");
});
builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddScheme<CustomOption, JWTAuthenticationHandler>
    (
    "JWTAuth", options => { }
    );
builder.Services.AddScoped<JWTAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>();
builder.Services.AddScoped<SocketService>();

//builder.Services.AddScoped<JWTAuthenticationStateProvider>();
//builder.Services.AddScoped<AuthenticationStateProvider,JWTAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

