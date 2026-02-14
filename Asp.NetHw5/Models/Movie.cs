using System.Text.Json.Serialization;

namespace Asp.NetHw5.Models
{
    public record class Movie (
        bool Adult,
        string BackdropPath,
        int[] GenreIds,
        int Id,
        string OriginalLanguage,
        string OriginalTitle,
        string Overview,
        float Popularity,
        string PosterPath,
        string ReleaseDate,
        string Title,
        bool Video,
        float VoteAverage,
        int VoteCount
    )
    {}
}
