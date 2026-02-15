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
app.UseStaticFiles();

app.MapGet("/", async (TmdbService service) =>
{
    MovieResponse response = await service.GetMoviesAsync();
    string html = HtmlParts.RenderPage(HtmlParts.RenderMovieList(response.Results));

    return Results.Content(html, "text/html");
});

app.MapGet("/search", async (TmdbService service, string query) =>
{
    MovieResponse response = await service.SearchMoviesAsync(query);
    string html = HtmlParts.RenderPage(HtmlParts.RenderMovieList(response.Results));

    return Results.Content(html, "text/html");
});

app.MapGet("/details/Id={id:int}", async (TmdbService service, int id) =>
{
    MovieDetails? movie = await service.GetMovieDetailsAsync(id);
    MovieResponse? similarResponse = await service.GetSimilarMoviesAsync(id);

    IEnumerable<Movie> similarMovies = similarResponse?.Results?.Take(5) ?? Array.Empty<Movie>();

    if (movie == null)
    {
        return Results.NotFound("Movie not found");
    }

    string html = HtmlParts.RenderMovieDetails(movie, similarMovies);
    return Results.Content(html, "text/html");
});

app.Run();
