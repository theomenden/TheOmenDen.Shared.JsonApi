using System.Collections;

namespace TheOmenDen.Shared.JsonApi.Models.Links;
public record PaginationLink : Link
{
    private PaginationLink(String name, String href)
        : base(name, href)
    { }

    public static PaginationLink First(String href) => new(nameof(First).ToLowerInvariant(), href);
    public static PaginationLink Next(String href) => new(nameof(Next).ToLowerInvariant(), href);
    public static PaginationLink Prev(String href) => new(nameof(Prev).ToLowerInvariant(), href);
    public static PaginationLink Last(String href) => new(nameof(Last).ToLowerInvariant(), href);
}
