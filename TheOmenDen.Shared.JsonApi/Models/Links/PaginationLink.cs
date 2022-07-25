namespace TheOmenDen.Shared.JsonApi.Models.Links;

/// <summary>
/// A strict following of the Pagination section of the <see cref="JsonApi"/> standard
/// </summary>
public record PaginationLink : Link
{
    private PaginationLink(String name, String href)
        : base(name, href)
    {}

    /// <summary>
    /// A link that specifies the first page of results in a paged collection
    /// </summary>
    /// <param name="href">The url</param>
    /// <returns>The created <see cref="PaginationLink"/></returns>
    public static PaginationLink First(String href) => new(nameof(First).ToLowerInvariant(), href);
    
    /// <summary>
    /// A link that specifies moving towards the next page of results in a paged collection
    /// </summary>
    /// <param name="href">The url</param>
    /// <returns></returns>
    public static PaginationLink Next(String href) => new(nameof(Next).ToLowerInvariant(), href);
    
    /// <summary>
    /// A link that specifies moving towards the previous page in a paged collection
    /// </summary>
    /// <param name="href">The url</param>
    /// <returns>The created <see cref="PaginationLink"/></returns>
    public static PaginationLink Prev(String href) => new(nameof(Prev).ToLowerInvariant(), href);
    
    /// <summary>
    /// A link that specifies moving towards the last page in a paged collection
    /// </summary>
    /// <param name="href">The url</param>
    /// <returns>The created <see cref="PaginationLink"/></returns>
    public static PaginationLink Last(String href) => new(nameof(Last).ToLowerInvariant(), href);
}
