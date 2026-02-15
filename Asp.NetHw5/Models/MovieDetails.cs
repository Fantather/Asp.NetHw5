namespace Asp.NetHw5.Models
{
    public record class MovieDetails(
        int Id,
        string Title,
        string OriginalTitle,
        string Overview,
        string PosterPath,
        string BackdropPath,
        string ReleaseDate,
        float VoteAverage,
        int Runtime,
        Genre[] Genres,
        ProductionCountry[] ProductionCountries,
        VideosResponse Videos
    )
    { }
}