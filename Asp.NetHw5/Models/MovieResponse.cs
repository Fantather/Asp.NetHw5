using System.Text.Json.Serialization;

namespace Asp.NetHw5.Models
{
    public record class MovieResponse(
        int Page,
        Movie[] Results,
        int TotalPages,
        int TotalResults
    )
    {}
}
