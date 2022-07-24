namespace TheOmenDen.Shared.JsonApi.Models.Relationships;
#nullable disable
/// <summary>
/// Defines a relationship between resources
/// </summary>
public class Relationship : IRelationship
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

    public Meta Meta { get; set; }

    #region Private Methods
    private void SetLinks(IEnumerable<Link> links)
    {
        InitializeLinks();

        _links.AddRange(links);
    }


    private void InitializeLinks()
    {
        _links ??= new(2);
    }
    #endregion
    #region Add link Methods
    /// <summary>
    /// Adds a <see cref="Link"/> to the relationship
    /// </summary>
    /// <param name="link">The <see cref="Link"/> we want to add</param>
    /// <returns>The created <see cref="Link"/></returns>
    public Link AddLink(Link link)
    {
        InitializeLinks();

        _links.Add(link);

        return link;
    }

    /// <summary>
    /// Adds a <see cref="RelationLink"/> to the relationship
    /// </summary>
    /// <param name="relationLink">The <see cref="RelationLink"/> we want to add</param>
    /// <returns>The created <see cref="RelationLink"/></returns
    public Link AddLink(RelationLink relationLink)
    {
        InitializeLinks();

        _links.Add(relationLink);

        return relationLink;
    }

    /// <summary>
    /// Adds a <see cref="Link"/> to the relationship
    /// </summary>
    /// <param name="name">The human readable name of the link</param>
    /// <param name="href">The url</param>
    /// <returns>The created <see cref="Link"/></returns>
    public Link AddLink(String name, String href)
    {
        InitializeLinks();

        var linkToAdd = new Link(name, href);

        _links.Add(linkToAdd);

        return linkToAdd;
    }
    #endregion
}

/// <summary>
/// <inheritdoc cref="Relationship"/>
/// </summary>
/// <typeparam name="TData">The underlying data encompassed by the relationship</typeparam>
public class Relationship<TData> : Relationship
{
    /// <summary>
    /// Underlying information for a relationship that allows a client to issue a single request as opposed to many
    /// </summary>
    public TData Data { get; set; }
}
