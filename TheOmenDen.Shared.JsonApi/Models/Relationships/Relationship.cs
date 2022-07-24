namespace TheOmenDen.Shared.JsonApi.Models.Relationships;
#nullable disable
/// <summary>
/// Defines a relationship between resources
/// </summary>
public class Relationship: IRelationship
{
    private List<Link> _links;

    /// <summary>
    /// Creates a relationship for the provided type <typeparamref name="TData"/>
    /// </summary>
    /// <typeparam name="TData">The underlying data type</typeparam>
    /// <param name="data">The supplied data</param>
    /// <returns>A new relationship</returns>
    public static Relationship<TData> Create<TData>(TData data)
    {
        return new()
        {
            Data = data
        };
    }

    public IEnumerable<Link> Links
    {
        get => _links ?? new List<Link>(2);
        set => SetLinks(value);
    }

    private void SetLinks(IEnumerable<Link> links)
    {
        _links = links?.ToList() ?? new(2);
    }

    public Meta Meta { get; set; }

    public void InitializeLinks()
    {
        _links ??= new (2);
    }

    public Link AddLink(RelationLink relationLink)
    {
        _links.Add(relationLink);

        return relationLink;
    }

    public Link AddLink(String name, String href)
    {
        var linkToAdd = new Link(name, href);
        
        _links.Add(linkToAdd);

        return linkToAdd;
    }
}

/// <summary>
/// <inheritdoc cref="Relationship"/>
/// </summary>
/// <typeparam name="TData">The underlying data encompassed by the relationship</typeparam>
public class Relationship<TData>: Relationship
{
    /// <summary>
    /// Underlying information for a relationship that allows a client to issue a single request as opposed to many
    /// </summary>
    public TData Data { get; set; }
}
