using Asp.NetHw5.Models;
using Asp.NetHw5.Parts;
using Asp.NetHw5.Services;

var builder = WebApplication.CreateBuilder(args);
string accessToken = builder.Configuration["ApiSettings:AccessToken"];
builder.Services.AddHttpClient<TmdbService>(client =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
});

var app = builder.Build();

app.MapGet("/", async (TmdbService service) =>
{
    MovieResponse response = await service.GetMoviesAsync();
    string html = HtmlParts.RenderPage(HtmlParts.RenderMovieList(response.Results));

    return Results.Content(html, "text/html");
});

app.UseStaticFiles();
app.Run();
