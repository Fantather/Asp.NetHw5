using Asp.NetHw5.Services;

var builder = WebApplication.CreateBuilder(args);
string accessToken = builder.Configuration["ApiSettings:AccessToken"];
builder.Services.AddHttpClient<TmdbService>(client =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
});

var app = builder.Build();

app.MapGet("", () =>
{
    
});

app.Run();
